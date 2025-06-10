@echo off
setlocal enabledelayedexpansion
REM This script runs the API tests and saves the results to a timestamped file.

REM Get UTC date/time using WMIC and format as yyyyMMdd_HHmmss
for /f "skip=1 tokens=1 delims=." %%a in ('wmic os get localdatetime') do (
    if not defined UTCTIME set UTCTIME=%%a
)
set UTCTIME=!UTCTIME:~0,8!_!UTCTIME:~8,6!

echo !UTCTIME!

dotnet test ./API_TEST/API_BDD_Test_Project.csproj > test_results_API_TEST_!UTCTIME!.txt

endlocal