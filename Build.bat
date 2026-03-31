@echo off 

call Build.Server.bat
if errorlevel 1 goto done

echo.
call Build.Client.bat
if errorlevel 1 goto done

echo.
echo Compiling MiniDuel loader (C++)
echo.

REM Compile MiniDuelLoader using cl (requires Visual Studio with C++ compilers) (TODO: Improve this... maybe also check vswhere.exe)
set BATPATH=%ProgramW6432%\Microsoft Visual Studio\18\Community\VC\Auxiliary\Build\vcvarsall.bat
if exist "%BATPATH%" goto initCompiler
set BATPATH=%ProgramW6432%\Microsoft Visual Studio\2022\Community\VC\Auxiliary\Build\vcvarsall.bat
if exist "%BATPATH%" goto initCompiler
if defined VS190COMNTOOLS set BATPATH=%VS190COMNTOOLS%\..\..\VC\vcvarsall.bat
if exist "%BATPATH%" goto initCompiler
if defined VS180COMNTOOLS set BATPATH=%VS180COMNTOOLS%\..\..\VC\vcvarsall.bat
if exist "%BATPATH%" goto initCompiler
if defined VS170COMNTOOLS set BATPATH=%VS170COMNTOOLS%\..\..\VC\vcvarsall.bat
if exist "%BATPATH%" goto initCompiler
if defined VS160COMNTOOLS set BATPATH=%VS160COMNTOOLS%\..\..\VC\vcvarsall.bat
if exist "%BATPATH%" goto initCompiler
if defined VS150COMNTOOLS set BATPATH=%VS150COMNTOOLS%\..\..\VC\vcvarsall.bat
if exist "%BATPATH%" goto initCompiler
if defined VS140COMNTOOLS set BATPATH=%VS140COMNTOOLS%\..\..\VC\vcvarsall.bat
if exist "%BATPATH%" goto initCompiler
if defined VS130COMNTOOLS set BATPATH=%VS130COMNTOOLS%\..\..\VC\vcvarsall.bat
if exist "%BATPATH%" goto initCompiler
if defined VS120COMNTOOLS set BATPATH=%VS120COMNTOOLS%\..\..\VC\vcvarsall.bat
if exist "%BATPATH%" goto initCompiler
if defined VS110COMNTOOLS set BATPATH=%VS110COMNTOOLS%\..\..\VC\vcvarsall.bat
if exist "%BATPATH%" goto initCompiler
if defined VS100COMNTOOLS set BATPATH=%VS100COMNTOOLS%\..\..\VC\vcvarsall.bat
if exist "%BATPATH%" goto initCompiler
goto cppCompilerNotFound

:initCompiler
call "%BATPATH%" amd64

cd MiniDuelLoader
cl MiniDuelLoader.cpp /LD /DWITHDETOURS /Fe:../MiniDuel/MiniDuelLoader.dll
cl MonoRun.cpp /Fe:../MiniDuel/MonoRun.exe
cd ../
goto done

:cppCompilerNotFound
echo [ERROR] Failed to compile MiniDuel loader
echo.
echo Solutions:
echo 1) Ignore this error if you already have MiniDuelLoader.dll
echo 2) Download a release build from github
echo 3) Install Visual Studio with C++ compilers and re-run Build.bat
echo 4) Manually compile it by reading the top of MiniDuelLoader.cpp

:done
echo.
pause
