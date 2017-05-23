#!/bin/bash
pwd
echo "Doing dotnet restore"
dotnet restore
echo "Doing dotnet build"
dotnet build
echo "end of travis-build"
