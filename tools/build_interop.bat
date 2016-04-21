"tlbimp.exe" %windir%\system32\UIAutomationCore.dll /out:interop.UIAutomationCore.dll"
rem "x64/midl.exe" /cpp_cmd "x64/cl.exe" ShObjIdl.idl
"tlbimp.exe" ShObjIdl.tlb /out:interop.ShObjIdl.dll"
pause