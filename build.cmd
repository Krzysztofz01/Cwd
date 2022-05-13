@echo off
title Cwd instalation...

REM Compile the program and store the output to build folder
dotnet publish .\Cwd\Cwd\Cwd.csproj --runtime win-x64 --output ./build --self-contained true --configuration Release /p:PublishSingleFile=true /p:IncludeNativeLibrariesForSelfExtract=true

REM Create directory for executable
MKDIR bin

REM Copy the executable file to main directory 
COPY build\Cwd.exe bin\cwd.exe

REM Delete the build directory
RMDIR /s /q build

REM Remove the source code directory
RMDIR /s /q Cwd

REM Remove the .git hidden directory
RMDIR /s /q .git

REM Remove the .gitignore file
DEL /q .gitignore

REM Remove the installer scripts
DEL /q build.cmd
DEL /q build.sh