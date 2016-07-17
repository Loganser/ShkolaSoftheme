@echo off 
powershell -command "Set-ExecutionPolicy Unrestricted" 2>> err.out  
powershell .\script.ps1 2>> err.out
REM   *** Exit batch file. ***
EXIT /b 0