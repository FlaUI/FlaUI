#tool nuget:?package=NUnit.ConsoleRunner&version=3.7.0
#addin Cake.FileHelpers&version=1.0.4
//////////////////////////////////////////////////////////////////////
// ARGUMENTS
//////////////////////////////////////////////////////////////////////

var target = Argument("target", "Default");
var configuration = Argument("configuration", "Release");

//////////////////////////////////////////////////////////////////////
// PREPARATION
//////////////////////////////////////////////////////////////////////

var slnFile = @"src\FlaUI.sln";
var artifactDir = new DirectoryPath("artifacts");

//////////////////////////////////////////////////////////////////////
// TASKS
//////////////////////////////////////////////////////////////////////

Task("Clean")
    .Does(() =>
{
    CleanDirectory(artifactDir);
});

Task("Restore-NuGet-Packages")
    .IsDependentOn("Clean")
    .Does(() =>
{
    NuGetRestore(slnFile);
});

Task("Build")
    .IsDependentOn("Restore-NuGet-Packages")
    .Does(() =>
{
    var buildLogFile = artifactDir.CombineWithFilePath("BuildLog.txt");
    var buildSettings = new MSBuildSettings {
        Verbosity = Verbosity.Minimal,
        ToolVersion = MSBuildToolVersion.VS2017,
        Configuration = configuration,
        PlatformTarget = PlatformTarget.MSIL,
    }.AddFileLogger(new MSBuildFileLogger {
        LogFile = buildLogFile.ToString(),
        MSBuildFileLoggerOutput = MSBuildFileLoggerOutput.All
    });
    // Hide informational warnings for now
    buildSettings.Properties.Add("WarningLevel", new[] { "3" });
    // Force restoring
    buildSettings.Properties.Add("RestoreForce", new[] { "true" });

    // First build with default settings
    buildSettings.Targets.Clear();
    buildSettings.WithTarget("Restore");
    MSBuild(slnFile, buildSettings);
    buildSettings.Targets.Clear();
    buildSettings.WithTarget("Build");
    MSBuild(slnFile, buildSettings);

    // Second build with signing enabled
    var buildLogSignedFile = artifactDir.CombineWithFilePath("BuildLogSigned.txt");
    buildSettings.FileLoggers.First().LogFile = buildLogSignedFile.ToString();
    buildSettings.Properties.Add("EnableSigning", new[] { "true" });
    buildSettings.Targets.Clear();
    buildSettings.WithTarget("Restore");
    MSBuild(slnFile, buildSettings);
    buildSettings.Targets.Clear();
    buildSettings.WithTarget("Build");
    MSBuild(slnFile, buildSettings);

    // Zip the logs
    Zip(artifactDir, artifactDir.CombineWithFilePath("BuildLog.zip"), new [] { buildLogFile, buildLogSignedFile });
});

Task("Run-Unit-Tests")
    .IsDependentOn("Build")
    .Does(() =>
{
    var resultFile = artifactDir.CombineWithFilePath("UnitTestResult.xml");
    NUnit3(@"src\FlaUI.Core.UnitTests\bin\FlaUI.Core.UnitTests.dll", new NUnit3Settings {
        Results = resultFile
    });
    if (AppVeyor.IsRunningOnAppVeyor) {
        AppVeyor.UploadTestResults(resultFile, AppVeyorTestResultsType.NUnit3);
    }
});

Task("Run-UI-Tests")
    .IsDependentOn("Build")
    .Does(() =>
{
    var resultFile = artifactDir.CombineWithFilePath("UIA2TestResult.xml");
    NUnit3(@"src\FlaUI.Core.UITests\bin\FlaUI.Core.UITests.dll", new NUnit3Settings {
        Results = resultFile,
        ArgumentCustomization = args => args.Append("--params=uia=2")
    });
    if (AppVeyor.IsRunningOnAppVeyor) {
        AppVeyor.UploadTestResults(resultFile, AppVeyorTestResultsType.NUnit3);
    }

    resultFile = artifactDir.CombineWithFilePath("UIA3TestResult.xml");
    NUnit3(@"src\FlaUI.Core.UITests\bin\FlaUI.Core.UITests.dll", new NUnit3Settings {
        Results = resultFile,
        ArgumentCustomization = args => args.Append("--params=uia=3")
    });
    if (AppVeyor.IsRunningOnAppVeyor) {
        AppVeyor.UploadTestResults(resultFile, AppVeyorTestResultsType.NUnit3);
    }
});

Task("Run-Tests")
    .IsDependentOn("Run-Unit-Tests")
    .IsDependentOn("Run-UI-Tests")
    .Does(() =>
{
});

Task("Package")
    .IsDependentOn("Run-Tests")
    .Does(() =>
{
    // Upload the artifacts to appveyor
    if (AppVeyor.IsRunningOnAppVeyor) {
        // Add the nuget packages
        foreach(var file in GetFiles(artifactDir.ToString() + "/*.nupkg"))
        {
            AppVeyor.UploadArtifact(file);
        }
        // Add the test xml files
        foreach(var file in GetFiles(artifactDir.ToString() + "/*.xml"))
        {
            AppVeyor.UploadArtifact(file);
        }
        // Add zip files
        foreach(var file in GetFiles(artifactDir.ToString() + "/*.zip"))
        {
            AppVeyor.UploadArtifact(file);
        }
    }
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
