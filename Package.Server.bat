@echo off
setlocal

set "ROOT=%~dp0"
set "SOURCE=%ROOT%MiniDuel"
set "OUTPUT=%ROOT%dist\Server"

if not exist "%SOURCE%\MiniDuel.exe" (
    echo [ERROR] Missing "%SOURCE%\MiniDuel.exe"
    echo Build the server first with Build.Server.bat
    exit /b 1
)

if exist "%OUTPUT%" rmdir /s /q "%OUTPUT%"

mkdir "%OUTPUT%"
mkdir "%OUTPUT%\Data"

xcopy /E /I /Y "%SOURCE%\Data\Common" "%OUTPUT%\Data\Common\" >nul
xcopy /E /I /Y "%SOURCE%\Data\Server" "%OUTPUT%\Data\Server\" >nul

copy /Y "%SOURCE%\MiniDuel.exe" "%OUTPUT%\" >nul
copy /Y "%SOURCE%\MiniDuel.exe.config" "%OUTPUT%\" >nul

if exist "%SOURCE%\MiniDuel.pdb" copy /Y "%SOURCE%\MiniDuel.pdb" "%OUTPUT%\" >nul
if exist "%SOURCE%\MonoRun.exe" copy /Y "%SOURCE%\MonoRun.exe" "%OUTPUT%\" >nul

echo Server package created in "%OUTPUT%"
