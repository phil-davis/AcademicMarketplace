#!/bin/bash
pwd
ls -l /usr/share/dotnet/sdk/1.0.4/Microsoft/VisualStudio
echo "Doing dotnet restore"
dotnet restore
echo "Doing dotnet build"
dotnet build
echo "end of travis-build"
