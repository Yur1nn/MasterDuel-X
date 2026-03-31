@echo off

echo Compiling MiniDuel client (C#)
echo.
call %WINDIR%\Microsoft.NET\Framework\v4.0.30319\MSBuild.exe MiniDuelClient.sln /p:Configuration=Debug /p:Platform=x64
