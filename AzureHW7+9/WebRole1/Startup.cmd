REM ===================DEFINE MSI,MST,UPN,log file & folder here ==================
SET MSINAME=ChromeSetup.exe
SET MSTNAME=ChromeSetup.exe
REM ================================================================================
REM ===================Check if the Product exists already==========================
SET "PRODUCTKEY=HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Uninstall"
REG QUERY "%PRODUCTKEY%\Google Chrome"
IF NOT %ERRORLEVEL% EQU 0 (GOTO :INSTALL) ELSE GOTO :ERROR 
REM ================================================================================
:INSTALL
REM =======================Install  the application=================================
MSIexec.exe /I "%~dp0ChromeSetup.exe" TRANSFORMS="%~ChromeSetup.exe" /QR /quiet
REM ======MSIEXEC.EXE /I "%~dp0ChromeSetup.exe" /TRANSFORMS="%~dp0ChromeSetup.exe" /QB! /L*V /quiet======
set MSIERROR=%errorlevel%
if %MSIERROR%==0 GOTO :ENDHERE
if %MSIERROR%==1641 GOTO :ENDHERE
if %MSIERROR%==3010 GOTO :ENDHERE
GOTO :ERROR
REM ================================================================================
REM ================ Installation successful. Write to Event Log====================
:ENDHERE
EVENTCREATE /l Application /so GoogleChrome-Install-SUCCESS /t SUCCESS /id 1000 /d "Application installed successfully."
Exit 0
REM ================================================================================
:ERROR
Exit 0