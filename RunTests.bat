SET config=Release
nunit3-console "src\FlaUI.Core.UnitTests\FlaUI.Core.UnitTests.csproj" --config=%config% --output=UnitTestResult.xml
nunit3-console "src\FlaUI.Core.UITests\FlaUI.Core.UITests.csproj" --config=%config% --params=uia=2 --output=UIA2TestResult.xml
nunit3-console "src\FlaUI.Core.UITests\FlaUI.Core.UITests.csproj" --config=%config% --params=uia=3 --output=UIA3TestResult.xml