@echo off 

echo Compiling MiniDuelFiddler
echo.

call %WINDIR%\Microsoft.NET\Framework\v4.0.30319\MSBuild.exe MiniDuelFiddler.csproj /p:Configuration=Debug

:done
echo.
pause
