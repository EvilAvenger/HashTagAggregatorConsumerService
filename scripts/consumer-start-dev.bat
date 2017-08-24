@echo off

echo Started

SET currentPath=%~dp0
SET consumerServicePath=%~dp0..\backend\HashTagAggregatorConsumer.Service

setx ASPNETCORE_ENVIRONMENT dev

cd %consumerServicePath%

echo %consumerServicePath%

dotnet run --no-launch-profile

cd %currentPath%

echo Finished


