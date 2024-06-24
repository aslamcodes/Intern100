@echo off
cd "C:\Users\VC\Documents\Projects\Intern100"
setlocal

:: PowerShell script embedded in batch script
set "psCommand=Add-Type -AssemblyName Microsoft.VisualBasic; $result = [Microsoft.VisualBasic.Interaction]::MsgBox('Push Intern Repo? This is a scheduled operation, delete the task in task scheduled if the operation is no longer needed.', [Microsoft.VisualBasic.MsgBoxStyle]::YesNoCancel, 'Push Intern Repo?'); Write-Output $result"

:: Call the PowerShell script and capture the result
for /f "tokens=*" %%i in ('powershell -NoProfile -ExecutionPolicy Bypass -Command "%psCommand%"') do set result=%%i

:: Store the user selection in a variable
set "userSelection=%result%"

:: Process the result
if "%userSelection%"=="6" (
    set "LOG_FILE=C:\Users\VC\Documents\Projects\Intern100\push-log.txt"
    set "commit_message=%DATE% updates pushed at %TIME%"
    echo %commit_message% >> %LOG_FILE%
    git add . >> %LOG_FILE%
    git add .
    git commit -m "%commit_message%" >> %LOG_FILE%
    git push origin main
) else if "%userSelection%"=="7" (
    echo User clicked No
) else if "%userSelection%"=="2" (
    echo User clicked Cancel
) else (
    echo Unexpected result: %userSelection%
)

endlocal
