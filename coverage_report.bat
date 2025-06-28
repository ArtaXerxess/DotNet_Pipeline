@echo off
REM ================================================================
REM  coverage_report.bat
REM  Runs dotnet tests, collects coverage, and builds an HTML report
REM  Requirements:
REM    • coverlet.collector NuGet package in your test project(s)
REM    • dotnet-reportgenerator-globaltool installed
REM ================================================================

::-------------------------------------------------
:: Configuration – tweak if you want different paths
::-------------------------------------------------
set "RESULTS_DIR=TestResults"
set "REPORT_DIR=CoverageReport"

echo ================================================================
echo Cleaning previous coverage output…
echo ================================================================
if exist "%RESULTS_DIR%" (
    echo Deleting "%RESULTS_DIR%" …
    rmdir /S /Q "%RESULTS_DIR%"
)
if exist "%REPORT_DIR%" (
    echo Deleting "%REPORT_DIR%" …
    rmdir /S /Q "%REPORT_DIR%"
)

echo.
echo ================================================================
echo Running tests and collecting coverage…
echo ================================================================
dotnet test ^
  --collect:"XPlat Code Coverage" ^
  --results-directory "%RESULTS_DIR%" ^
  --verbosity minimal

IF ERRORLEVEL 1 (
    echo.
    echo Tests failed – skipping report generation.
    exit /b %ERRORLEVEL%
)

echo.
echo ================================================================
echo Generating HTML coverage report…
echo ================================================================
REM ---- If ReportGenerator is installed globally: ------------------
reportgenerator ^
  -reports:"%RESULTS_DIR%\**\coverage.cobertura.xml" ^
  -targetdir:"%REPORT_DIR%" ^
  -reporttypes:Html

REM ---- If you use a local tool‑manifest instead, comment the line   ----
REM ---- above and uncomment the two lines below:                     ----
REM dotnet tool run reportgenerator ^
REM   -reports:"%RESULTS_DIR%\**\coverage.cobertura.xml" -targetdir:"%REPORT_DIR%" -reporttypes:Html

echo.
echo ================================================================
echo ✔ Done!  Open "%REPORT_DIR%\index.html" in your browser.
echo ================================================================
start CoverageReport/index.html