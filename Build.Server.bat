@echo off

echo Compiling MiniDuel server (C#)
echo.
call %WINDIR%\Microsoft.NET\Framework\v4.0.30319\MSBuild.exe MiniDuelServer.sln /p:Configuration=Debug /p:Platform=x64
