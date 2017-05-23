#!/bin/bash
pwd
ls -l /usr/share/dotnet/sdk/1.0.3/Microsoft/VisualStudio
ls -l /usr/share/dotnet/sdk/1.0.3/Microsoft
ls -l /usr/share/dotnet/sdk/1.0.3
ls -l /usr/share/dotnet/sdk
ls -l /usr/share/dotnet
echo "Doing dotnet restore"
dotnet restore
echo "Doing dotnet build"
dotnet build
echo "end of travis-build"
