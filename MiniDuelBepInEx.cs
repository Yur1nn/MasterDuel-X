using System;
using BepInEx;
using BepInEx.Unity.IL2CPP;
using System.Runtime.InteropServices;
using System.Reflection;
using System.Linq;
using System.Collections.Generic;
using System.IO;

namespace MiniDuelBepInEx
{
    [BepInPlugin("MiniDuelBepInEx", "MiniDuelBepInEx", "1.0.0")]
    public class MiniDuelBepInExPlugin : BasePlugin
    {
        public override void Load()
        {
            // TODO: Support "live"
            string targetDir = null;
            string[] args = Environment.GetCommandLineArgs();
            if (args != null)
            {
                string targetArg = "--MiniDuelDir=";
                foreach (string arg in args)
                {
                    if (arg.StartsWith(targetArg))
                    {
                        try
                        {
                            DirectoryInfo dirInfo = new DirectoryInfo(arg.Substring(targetArg.Length).Trim('\"'));
                            if (!dirInfo.Exists)
                            {
                                return;
                            }
                            targetDir = dirInfo.Name;
                            Console.WriteLine("MiniDuelDir: '" + targetDir + "'");
                        }
                        catch
                        {
                        }
                    }
                }
            }
            if (string.IsNullOrEmpty(targetDir))
            {
                return;
            }
            string miniDuelLoaderFile = Path.Combine(targetDir, "MiniDuelLoader.dll");
            string miniDuelClientFile = Path.Combine(targetDir, "MiniDuelClient.exe");
            if (!File.Exists(miniDuelLoaderFile))
            {
                Console.WriteLine("Failed to find '" + miniDuelLoaderFile + "'");
                return;
            }
            if (!File.Exists(miniDuelClientFile))
            {
                Console.WriteLine("Failed to find '" + miniDuelClientFile + "'");
                return;
            }
            Console.WriteLine("Loading MiniDuelLoader.dll");
            IntPtr handle = LoadLibrary(miniDuelLoaderFile);
            Console.WriteLine("MiniDuelLoader handle: " + handle);
            if (handle == IntPtr.Zero)
            {
                return;
            }
            Assembly assembly = Assembly.LoadFile(Path.GetFullPath(miniDuelClientFile));
            string dllMainArg = null;//"live";
            assembly.GetType("MiniDuelClient.Program").GetMethod("DllMain").Invoke(null, new object[] { dllMainArg });
        }
        
        [DllImport("kernel32")]
        static extern IntPtr LoadLibrary(string lpFileName);
    }
}
