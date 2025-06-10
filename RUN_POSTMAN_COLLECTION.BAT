@echo off
setlocal enabledelayedexpansion
REM This script runs the Postman collection in the POSTMAN folder and saves the results to a timestamped file.

REM Get UTC date/time using WMIC and format as yyyyMMdd_HHmmss
for /f "skip=1 tokens=1 delims=." %%a in ('wmic os get localdatetime') do (
    if not defined UTCTIME set UTCTIME=%%a
)
set UTCTIME=!UTCTIME:~0,8!_!UTCTIME:~8,6!

echo Running Postman collection at !UTCTIME!

REM Run the collection with environment file
call newman run POSTMAN\ENSEK_API_Test_Collection_v6.postman_collection.json ^
    -e POSTMAN\ENSEK_API_Environment_v6.postman_environment.json ^
    > postman_results_!UTCTIME!.txt

endlocal