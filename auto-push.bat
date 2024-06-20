@echo off
cd "C:\Users\VC\Documents\Projects\Intern100"

set LOG_FILE="C:\Users\VC\Documents\Projects\Intern100\push-log.txt"

set commit_message=%DATE% updates pushed at %TIME%

echo %commit_message% >> %LOG_FILE%

git add . >> %LOG_FILE%
git add .

git commit -m "%commit_message%" >> %LOG_FILE%

git push origin main
