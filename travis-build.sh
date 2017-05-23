#!/bin/bash
pwd
echo "Doing dotnet restore"
dotnet restore
echo "Doing dotnet build"
dotnet build ./AcademicMarketplace/Application.AcademicMarketplace.csproj
echo "end of travis-build"
