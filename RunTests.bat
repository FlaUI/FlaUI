SET config=Release
SET /A errno=0
nunit3-console "src\FlaUI.Core.UnitTests\FlaUI.Core.UnitTests.csproj" --config=%config% --result=UnitTestResult.xml
SET /A errno=%errno%+%ERRORLEVEL%
nunit3-console "src\FlaUI.Core.UITests\FlaUI.Core.UITests.csproj" --config=%config% --params=uia=2 --result=UIA2TestResult.xml
SET /A errno=%errno%+%ERRORLEVEL%
nunit3-console "src\FlaUI.Core.UITests\FlaUI.Core.UITests.csproj" --config=%config% --params=uia=3 --result=UIA3TestResult.xml
SET /A errno=%errno%+%ERRORLEVEL%
EXIT /B %errno%