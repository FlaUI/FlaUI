#tool nuget:?package=NuGet.CommandLine&version=6.13.2
#tool nuget:?package=NUnit.ConsoleRunner&version=3.19.2

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
    DotNetClean(slnFile);
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
        ToolVersion = MSBuildToolVersion.VS2022,
        Configuration = configuration,
        PlatformTarget = PlatformTarget.MSIL,
    }.AddFileLogger(new MSBuildFileLogger {
        LogFile = buildLogFile.ToString(),
        MSBuildFileLoggerOutput = MSBuildFileLoggerOutput.All
    });

    // Updates workloads to the newest available versions
    DotNetWorkloadUpdate()

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
    NUnit3(@"src\FlaUI.Core.UnitTests\bin\Release\net9.0-windows\FlaUI.Core.UnitTests.dll", new NUnit3Settings {
        Results = new[] {
            new NUnit3Result { FileName = resultFile, Format = "nunit3" }
        }
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
    var uia2ExitCode = 0;
    NUnit3(@"src\FlaUI.Core.UITests\bin\Release\net9.0-windows\FlaUI.Core.UITests.dll", new NUnit3Settings {
        Results = new[] {
            new NUnit3Result { FileName = resultFile, Format = "nunit3" }
        },
        ArgumentCustomization = args => args.Append("--testparam:uia=2"),
        HandleExitCode = exitCode => { uia2ExitCode = exitCode; return true; }
    });
    Information("Finished UIA2 Tests");
    if (AppVeyor.IsRunningOnAppVeyor) {
        AppVeyor.UploadTestResults(resultFile, AppVeyorTestResultsType.NUnit3);
    }

    resultFile = artifactDir.CombineWithFilePath("UIA3TestResult.xml");
    var uia3ExitCode = 0;
    NUnit3(@"src\FlaUI.Core.UITests\bin\Release\net9.0-windows\FlaUI.Core.UITests.dll", new NUnit3Settings {
        Results = new[] {
            new NUnit3Result { FileName = resultFile, Format = "nunit3" }
        },
        ArgumentCustomization = args => args.Append("--testparam:uia=3"),
        HandleExitCode = exitCode => { uia3ExitCode = exitCode; return true; }
    });
    Information("Finished UIA3 Tests");
    if (AppVeyor.IsRunningOnAppVeyor) {
        AppVeyor.UploadTestResults(resultFile, AppVeyorTestResultsType.NUnit3);
    }

    // Error if any tests failed
    if (uia2ExitCode != 0 || uia3ExitCode != 0) {
        throw new Exception("Some tests failed, aborting");
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

Task("Push-To-Nuget")
    .Does(() =>
{
    var apiKey = System.IO.File.ReadAllText(".nugetapikey");

    // Get the paths to the packages
    var packages = GetFiles($"{artifactDir}/*.nupkg");

    // Push the packages
    foreach (var package in packages) {
        Information($"Pushing {package}");
        NuGetPush(package, new NuGetPushSettings {
            Source = "https://nuget.org/api/v2/package",
            ApiKey = apiKey
        });
    }
});

 Task("Push-To-SymbolSource")
    .Does(() =>
{
    var apiKey = System.IO.File.ReadAllText(".nugetapikey");

    // Get the paths to the packages
    var packages = GetFiles($"{artifactDir}/*.snupkg");

    // Push the packages
    foreach (var package in packages) {
        Information($"Pushing {package}");
        NuGetPush(package, new NuGetPushSettings {
            Source = "https://nuget.smbsrc.net",
            ApiKey = apiKey
        });
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
