nuget.exe install opencover -Version 4.6.519 -OutputDirectory .\
nuget.exe install ReportGenerator -Version 2.4.5 -OutputDirectory .\
nuget.exe install NUnit.Console -OutputDirectory .\
.\OpenCover.4.6.519\tools\OpenCover.Console.exe -register:user -returntargetcode -output:CoverageResults.xml -target:.\NUnit.ConsoleRunner.3.5.0\tools\nunit3-console.exe -targetargs:"..\src\FlaUI.Core.UITests\bin\Debug\FlaUI.Core.UITests.dll ..\src\FlaUI.Core.UnitTests\bin\Debug\FlaUI.Core.UnitTests.dll"
.\ReportGenerator.2.4.5.0\tools\ReportGenerator.exe -reports:CoverageResults.xml -targetdir:CoverageReport -reporttypes:Html;Badges
pause