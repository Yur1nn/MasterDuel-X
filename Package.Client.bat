@echo off
setlocal

set "ROOT=%~dp0"
set "SOURCE=%ROOT%MiniDuel"
set "OUTPUT=%ROOT%dist\Client"

if not exist "%SOURCE%\MiniDuelClient.exe" (
    echo [ERROR] Missing "%SOURCE%\MiniDuelClient.exe"
    echo Build the client first with Build.Client.bat
    exit /b 1
)

if not exist "%SOURCE%\MiniDuelLoader.dll" (
    echo [ERROR] Missing "%SOURCE%\MiniDuelLoader.dll"
    echo Build the loader first with Build.bat or manually compile MiniDuelLoader
    exit /b 1
)

if exist "%OUTPUT%" rmdir /s /q "%OUTPUT%"

mkdir "%OUTPUT%"
mkdir "%OUTPUT%\Data"

xcopy /E /I /Y "%SOURCE%\Data\Common" "%OUTPUT%\Data\Common\" >nul
xcopy /E /I /Y "%SOURCE%\Data\Client" "%OUTPUT%\Data\Client\" >nul

copy /Y "%SOURCE%\MiniDuelClient.exe" "%OUTPUT%\" >nul
copy /Y "%SOURCE%\MiniDuelClient.exe.config" "%OUTPUT%\" >nul
copy /Y "%SOURCE%\MiniDuelLoader.dll" "%OUTPUT%\" >nul

if exist "%SOURCE%\MiniDuelClient.pdb" copy /Y "%SOURCE%\MiniDuelClient.pdb" "%OUTPUT%\" >nul

echo Client package created in "%OUTPUT%"
