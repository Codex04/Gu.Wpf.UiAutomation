set VS=%VS140COMNTOOLS%
set WINSDK=C:\Program Files (x86)\Windows Kits\10\Include\10.0.14393.0\um\
set ASMVERSION=4.5
SET TEMP=tmp
call "%VS%vsvars32.bat"

mkdir %TEMP%

@REM Create Type Libraries
midl.exe /nologo /out %TEMP% /char signed /tlb UIAutomationClient.tlb /h UIAutomationClient_h.h "%WINSDK%UIAutomationClient.idl"
midl.exe /nologo /out %TEMP% /char signed /tlb UIAutomationCore.tlb /h UIAutomationCore_h.h "%WINSDK%UIAutomationCore.idl"
http://stackoverflow.com/questions/5615206/windows-batch-files-setting-variable-in-for-loop
FOR %%A IN (3.5 4.5) DO (
	mkdir %TEMP%\%%A
	@REM Create the original dlls from the tlbs
	%%A\tlbimp.exe /machine:Agnostic /silent /asmversion:%%A /out:%%A\Interop.UIAutomationClient.dll %TEMP%\UIAutomationClient.tlb
	%%A\tlbimp.exe /machine:Agnostic /silent /asmversion:%%A /out:%TEMP%\%%A\Interop.UIAutomationCore.dll %TEMP%\UIAutomationCore.tlb
	REM %%A\tlbimp.exe /machine:Agnostic /silent /asmversion:%%A /out:%TEMP%\%%A\Interop.UIAutomationClient.dll %TEMP%\UIAutomationClient.tlb /keyfile:..\..\Gu.Wpf.UiAutomation.snk"
	REM %%A\tlbimp.exe /machine:Agnostic /silent /asmversion:%%A /out:%TEMP%\%%A\Interop.UIAutomationCore.dll %TEMP%\UIAutomationCore.tlb /keyfile:..\..\Gu.Wpf.UiAutomation.snk"
	@REM Fix Core by IL Code
	ildasm.exe %TEMP%\%%A\Interop.UIAutomationCore.dll /out=%TEMP%\%%A\UIAutomationCore.il /nobar
	powershell -File "FixAutomationCore.ps1" "%TEMP%\%%A\UIAutomationCore.il"
	ilasm /dll /output=%%A\Interop.UIAutomationCore.dll %TEMP%\%%A\UIAutomationCore.il /res:%TEMP%\%%A\UIAutomationCore.res
)
RMDIR /S /Q %TEMP%
pause
