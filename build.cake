#tool nuget:?package=NUnit.ConsoleRunner&version=3.4.0
//////////////////////////////////////////////////////////////////////
// ARGUMENTS
//////////////////////////////////////////////////////////////////////

var target = Argument("target", "Default");
var configuration = Argument("configuration", "Release");

//////////////////////////////////////////////////////////////////////
// PREPARATION
//////////////////////////////////////////////////////////////////////

var slnFile = @"src\FlaUI.sln";

//////////////////////////////////////////////////////////////////////
// TASKS
//////////////////////////////////////////////////////////////////////

Task("Restore-NuGet-Packages")
    .Does(() =>
{
    NuGetRestore(slnFile);
});

Task("Build")
    .IsDependentOn("Restore-NuGet-Packages")
    .Does(() =>
{
    MSBuild(slnFile, new MSBuildSettings {
        Verbosity = Verbosity.Minimal,
        ToolVersion = MSBuildToolVersion.VS2017,
        Configuration = configuration,
        PlatformTarget = PlatformTarget.MSIL,
    }.AddFileLogger(new MSBuildFileLogger {
        LogFile = "./BuildLog.txt",
        MSBuildFileLoggerOutput = MSBuildFileLoggerOutput.All
    }));
});

Task("Run-Unit-Tests")
    .IsDependentOn("Build")
    .Does(() =>
{
    NUnit3(@"src\FlaUI.Core.UnitTests\bin\FlaUI.Core.UnitTests.dll", new NUnit3Settings {
        Results = "UnitTestResult.xml"
    });
});

Task("Run-UI-Tests")
    .IsDependentOn("Build")
    .Does(() =>
{
    NUnit3(@"src\FlaUI.Core.UITests\bin\FlaUI.Core.UITests.dll", new NUnit3Settings {
        Results = "UIA2TestResult.xml",
        ArgumentCustomization = args => args.Append("--params=uia=2")
    });

    NUnit3(@"src\FlaUI.Core.UITests\bin\FlaUI.Core.UITests.dll", new NUnit3Settings {
        Results = "UIA3TestResult.xml",
        ArgumentCustomization = args => args.Append("--params=uia=3")
    });
});

Task("Run-Tests")
    .IsDependentOn("Run-Unit-Tests")
    .IsDependentOn("Run-UI-Tests")
    .Does(() =>
{
});

//////////////////////////////////////////////////////////////////////
// TASK TARGETS
//////////////////////////////////////////////////////////////////////

Task("Default")
    .IsDependentOn("Run-Unit-Tests");

//////////////////////////////////////////////////////////////////////
// EXECUTION
//////////////////////////////////////////////////////////////////////

RunTarget(target);
