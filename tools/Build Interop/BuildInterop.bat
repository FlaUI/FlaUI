set VS=%VS140COMNTOOLS%
set WINSDK=C:\Program Files (x86)\Windows Kits\10\Include\10.0.14393.0\um\
set ASMVERSION=4.5
SET TEMP=tmp
call "%VS%vsvars32.bat"

mkdir %TEMP%

@REM Create Type Libraries
midl.exe /nologo /out %TEMP% /char signed /tlb UIAutomationClient.tlb /h UIAutomationClient_h.h "%WINSDK%UIAutomationClient.idl"
midl.exe /nologo /out %TEMP% /char signed /tlb UIAutomationCore.tlb /h UIAutomationCore_h.h "%WINSDK%UIAutomationCore.idl"

set VERSION=3.5
%VERSION%\tlbimp.exe /machine:Agnostic /silent /asmversion:%VERSION% /out:%VERSION%\Interop.UIAutomationClient.dll %TEMP%\UIAutomationClient.tlb
%VERSION%\tlbimp.exe /machine:Agnostic /silent /asmversion:%VERSION% /out:%VERSION%\Interop.UIAutomationCore.dll %TEMP%\UIAutomationCore.tlb
REM %VERSION%\tlbimp.exe /machine:Agnostic /silent /asmversion:%VERSION% /out:%VERSION%\Interop.UIAutomationClient.dll %TEMP%\UIAutomationClient.tlb /keyfile:..\..\FlaUI.snk"
REM %VERSION%\tlbimp.exe /machine:Agnostic /silent /asmversion:%VERSION% /out:%VERSION%\Interop.UIAutomationCore.dll %TEMP%\UIAutomationCore.tlb /keyfile:..\..\FlaUI.snk"
set VERSION=4.5
%VERSION%\tlbimp.exe /machine:Agnostic /silent /asmversion:%VERSION% /out:%VERSION%\Interop.UIAutomationClient.dll %TEMP%\UIAutomationClient.tlb
%VERSION%\tlbimp.exe /machine:Agnostic /silent /asmversion:%VERSION% /out:%VERSION%\Interop.UIAutomationCore.dll %TEMP%\UIAutomationCore.tlb
REM %VERSION%\tlbimp.exe /machine:Agnostic /silent /asmversion:%VERSION% /out:%VERSION%\Interop.UIAutomationClient.dll %TEMP%\UIAutomationClient.tlb /keyfile:..\..\FlaUI.snk"
REM %VERSION%\tlbimp.exe /machine:Agnostic /silent /asmversion:%VERSION% /out:%VERSION%\Interop.UIAutomationCore.dll %TEMP%\UIAutomationCore.tlb /keyfile:..\..\FlaUI.snk"

RMDIR /S /Q %TEMP%
pause
