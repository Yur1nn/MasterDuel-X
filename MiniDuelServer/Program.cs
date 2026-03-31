using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Globalization;
using System.IO;
using System.Diagnostics;

namespace MiniDuelClient
{
    class Program
    {
        public static int DllMain(string arg)
        {
            try
            {
                MiniDuel.Program.IsMonoRun = true;
                Console.WriteLine("(MonoRun)");
                return MiniDuel.Program.Main(new string[0]);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return 0;
        }
    }
}

namespace MiniDuel
{
    class Program
    {
        public static bool IsMonoRun;
        public static string ServerExecutablePath { get { return RuntimePaths.ServerExecutablePath; } }
        public static string GameDirectory { get { return RuntimePaths.GameDirectory; } }

        static string GetExecutableDirectory()
        {
            string executablePath = RuntimePaths.ServerExecutablePath;
            if (string.IsNullOrEmpty(executablePath))
            {
                executablePath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            }
            return Path.GetDirectoryName(executablePath);
        }

        static void LoadRuntimeSettings()
        {
            if (string.IsNullOrEmpty(RuntimePaths.ServerExecutablePath))
            {
                RuntimePaths.ServerExecutablePath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            }

            string currentDir = GetExecutableDirectory();
            string dataRootDir = Utils.GetDataDirectory(true, currentDir);
            string serverDataDir = Utils.GetServerDataDirectory(dataRootDir);
            string settingsFile = Path.Combine(serverDataDir, "Settings.json");
            string configuredGameDirectory = "..";
            if (File.Exists(settingsFile))
            {
                Dictionary<string, object> values = MiniJSON.Json.DeserializeStripped(File.ReadAllText(settingsFile)) as Dictionary<string, object>;
                if (values != null)
                {
                    configuredGameDirectory = Utils.GetValue<string>(values, "GameDirectory", configuredGameDirectory);
                }
            }
            RuntimePaths.GameDirectory = Utils.ResolvePath(currentDir, configuredGameDirectory);
            Utils.EnsureGameDllDirectory(RuntimePaths.GameDirectory);
        }

        internal static int Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            RuntimePaths.ServerExecutablePath = System.Reflection.Assembly.GetExecutingAssembly().Location;

            if (IsMonoRun)
            {
                args = ProcessCommandLine.GetCommandLineArgs().Skip(2).ToArray();
            }

            LoadRuntimeSettings();

            for (int i = 0; i < args.Length; i++)
            {
                if (args[i].ToLowerInvariant() == "--pvp" && i < args.Length - 1)
                {
                    Pvp pvp = new Pvp();
                    pvp.Run(Encoding.UTF8.GetString(Convert.FromBase64String(args[i + 1])));
                    return 0;
                }
                if (args[i].ToLowerInvariant() == "--cpucontest-sim" && i < args.Length - 5)
                {
                    try
                    {
                        string deckFile1 = args[i + 1];
                        string deckFile2 = args[i + 2];
                        uint seed;
                        bool goFirst;
                        int iterationsBeforeIdle;
                        if (!uint.TryParse(args[i + 3], out seed) || !bool.TryParse(args[i + 4], out goFirst) ||
                            !int.TryParse(args[i + 5], out iterationsBeforeIdle) || !File.Exists(deckFile1) || !File.Exists(deckFile2))
                        {
                            return -1;
                        }
                        Process parentProcess = null;
                        int pid;
                        if (i < args.Length - 6 && int.TryParse(args[i + 6], out pid))
                        {
                            parentProcess = Process.GetProcessById(pid);
                        }
                        string dataRootDir = Utils.GetDataDirectory(true, GetExecutableDirectory());
                        string dataDir = Utils.GetSharedDataDirectory(dataRootDir);
                        YdkHelper.LoadIdMap(dataDir);
                        DuelSimulator sim = new DuelSimulator(dataDir);
                        if (!sim.InitContent())
                        {
                            return -1;
                        }
                        return sim.RunCpuVsCpu(deckFile1, deckFile2, seed, goFirst, iterationsBeforeIdle, parentProcess);
                    }
                    catch
                    {
                        // NOTE: This doesn't catch duel.dll access violations... TODO: Add some native error handler
                        return -2;
                    }
                }
            }

            GameServer server = new GameServer();
            server.Start();
            Process.GetCurrentProcess().WaitForExit();
            return 0;
        }
    }
}


