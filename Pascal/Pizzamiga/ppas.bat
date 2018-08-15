@echo off
SET THEFILE=c:\docume~1\admini~1\misdoc~1\aplica~1\pascal\pizzam~1\pizzam~1.exe
echo Linking %THEFILE%
c:\dev-pas\bin\ldw.exe  -s   -b base.$$$ -o c:\docume~1\admini~1\misdoc~1\aplica~1\pascal\pizzam~1\pizzam~1.exe link.res
if errorlevel 1 goto linkend
goto end
:asmend
echo An error occured while assembling %THEFILE%
goto end
:linkend
echo An error occured while linking %THEFILE%
:end
