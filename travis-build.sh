#!/bin/bash
pwd
ls -l /usr/share/dotnet/sdk/1.0.0/Microsoft/VisualStudio
ls -l /usr/share/dotnet/sdk/1.0.0/Microsoft
ls -l /usr/share/dotnet/sdk/1.0.0
ls -l /usr/share/dotnet/sdk
ls -l /usr/share/dotnet
echo "Doing dotnet restore"
dotnet restore
echo "Doing dotnet build"
dotnet build
echo "end of travis-build"
