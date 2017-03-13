SET /A errno=0
nunit3-console "src\FlaUI.Core.UnitTests\bin\FlaUI.Core.UnitTests.dll" --result=UnitTestResult.xml
SET /A errno=%errno%+%ERRORLEVEL%
nunit3-console "src\FlaUI.Core.UITests\bin\FlaUI.Core.UITests.dll" --params=uia=2 --result=UIA2TestResult.xml
SET /A errno=%errno%+%ERRORLEVEL%
nunit3-console "src\FlaUI.Core.UITests\bin\FlaUI.Core.UITests.dll" --params=uia=3 --result=UIA3TestResult.xml
SET /A errno=%errno%+%ERRORLEVEL%
EXIT /B %errno%