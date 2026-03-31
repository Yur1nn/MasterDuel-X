# MiniDuel

Offline Yu-Gi-Oh! Master Duel (PC)

*Progress is not shared with the live game.*

## Features

- Create decks
- Open packs
- Solo content
- Custom CPU duels
- [PvP duels / friends / trading](Docs/PvP.md)
- Duel replays
- YDK / YDKe support
- Card collection stats / deck editor sub menu improvements

## Requirements

- .NET Framework 4.8
- The game downloaded on Steam (complete the in-game tutorial to download all data)

MiniDuel is portable and can be used on any machine without Steam installed after being fully downloaded

## Usage

- Download the latest release from https://github.com/pixeltris/YgoMaster/releases
- Put the mod folder anywhere you want and name it whatever you want
- Set `Data/Client/ClientSettings.json` -> `GameDirectory` to your Master Duel install folder
- Set `Data/Server/Settings.json` -> `GameDirectory` to the same Master Duel install folder when running the server separately
- If the client should auto-start a separate server package, set `Data/Client/ClientSettings.json` -> `ServerExecutablePath`
- Run `MiniDuel.exe` first
- Run `MiniDuelClient.exe` after the server is already running
- *[If you see file load error popups, infinite loading screens, corrupt screens, etc follow these instructions](Docs/FileLoadError.md)*

Additionally...

- [It's recommended that you tailor the server settings to your preferences](Docs/Settings.md)
- Download [VG.TCG.Decks.7z](https://github.com/pixeltris/YgoMaster/releases/download/v1.4/VG.TCG.Decks.7z) for ~6000 decks from the YGO video games
- The custom duel starter UI can be accessed using the DUEL button on the home screen
- When updating copy your `/MiniDuel/Data/Players/` folder
- [How to change language](Docs/ChangingLanguage.md)
- [How to run on Linux](Docs/Linux.md)

## Data Layout

- `MiniDuel/Data/Common` contains data used by both the server and client
- `MiniDuel/Data/Client` contains client-only config and custom client assets
- `MiniDuel/Data/Server` contains server-only config and player save data

## Compiling from source

- Install Visual Studio with C++ compilers
- Run `Build.Server.bat` to build the server
- Run `Build.Client.bat` to build the client
- Run `Build.bat` to build both plus the loader
- Run `Package.Server.bat` to create a server-only distributable in `dist/Server`
- Run `Package.Client.bat` to create a client-only distributable in `dist/Client`
- Point each package at the real game install using the `GameDirectory` setting instead of placing it inside the game folder

Running the build scripts is the equivilant of:

- Compiling `MiniDuelServer.sln` or `MiniDuelClient.sln` with Visual Studio
- Compiling `MiniDuelLoader.cpp` with `cl` to produce `MiniDuelLoader.dll`

## Related

- https://www.nexusmods.com/yugiohmasterduel/mods - community mods
- https://www.nexusmods.com/yugiohmasterduel/articles/3 - modding guide
- https://github.com/SethPDA/MasterDuel-Modding/wiki - modding guide
- https://github.com/crazydoomy/MD-Replay-Editor - save / load replays
- https://github.com/Nauder/ygomd-rush-frames - Rush Duel card frames mod
- https://code.moenext.com/sherry_chaos/MDPro3 - forked YGOPro2 with Master Duel assets

## Screenshots

![Alt text](Docs/Pics/ss1.jpg)
![Alt text](Docs/Pics/ss2.jpg)
![Alt text](Docs/Pics/ss3.jpg)
![Alt text](Docs/Pics/ss4.jpg)
![Alt text](Docs/Pics/ss5.jpg)
![Alt text](Docs/Pics/ss6.jpg)
![Alt text](Docs/Pics/ss7.jpg)
