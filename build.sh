#!/bin/bash
set -xe

# Compile the program and store the output to build folder
dotnet publish ./Cwd/Cwd/Cwd.csproj --runtime linux-x64 --output ./build --self-contained true --configuration Release /p:PublishSingleFile=true /p:IncludeNativeLibrariesForSelfExtract=true

# Create directory for executable
mkdir ./bin

# Copy the executable file to main directory 
cp -r ./build/Cwd ./bin/cwd

# Delete the build directory
rm -rf build

# Delete the source code directory
rm -rf Cwd

# Remove the .git hidden directory
rm -rf .git

# Remove the .gitignore file
rm -f .gitignore

# Remove the installer
rm -f build.sh
rm -f build.cmd