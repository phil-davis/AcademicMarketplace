#!/bin/bash
pwd
ls -l /usr/share/dotnet/sdk/1.0.0-rc4-004771/Microsoft/VisualStudio
ls -l /usr/share/dotnet/sdk/1.0.0-rc4-004771/Microsoft
ls -l /usr/share/dotnet/sdk/1.0.0-rc4-004771
ls -l /usr/share/dotnet/sdk
ls -l /usr/share/dotnet
find / -name Microsoft.WebApplication.targets
echo "Doing dotnet restore"
dotnet restore
echo "Doing dotnet build"
dotnet build
echo "end of travis-build"
