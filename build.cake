#tool nuget:?package=NuGet.CommandLine&version=7.3.0

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
    DotNetRestore(slnFile);
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
    var unitTestProject = @"src\FlaUI.Core.UnitTests\FlaUI.Core.UnitTests.csproj";
    var framework = "net10.0-windows";
    var resultFileName = $"UnitTestResult-{framework}.trx";
    var resultFile = artifactDir.CombineWithFilePath(resultFileName);
    DotNetTest(unitTestProject, new DotNetTestSettings {
        Configuration = configuration,
        Framework = framework,
        NoBuild = true,
        NoRestore = true,
        NoLogo = true,
        ResultsDirectory = artifactDir,
        Loggers = new[] { $"trx;LogFileName={resultFileName}" }
    });
    if (AppVeyor.IsRunningOnAppVeyor) {
        AppVeyor.UploadTestResults(resultFile, AppVeyorTestResultsType.MSTest);
    }
});

Task("Run-UI-Tests")
    .IsDependentOn("Build")
    .Does(() =>
{
    // UI automation requires an interactive Windows desktop. The CI agent must
    // provide one when it runs this net10.0-windows test target.
    var uiTestProject = @"src\FlaUI.Core.UITests\FlaUI.Core.UITests.csproj";
    var framework = "net10.0-windows";
    foreach (var uiaVersion in new[] { 2, 3 }) {
        var resultFileName = $"UIA{uiaVersion}TestResult-{framework}.trx";
        var resultFile = artifactDir.CombineWithFilePath(resultFileName);
        DotNetTest(uiTestProject, new DotNetTestSettings {
            Configuration = configuration,
            Framework = framework,
            NoBuild = true,
            NoRestore = true,
            NoLogo = true,
            ResultsDirectory = artifactDir,
            Loggers = new[] { $"trx;LogFileName={resultFileName}" },
            ArgumentCustomization = args => args
                .Append("--")
                .Append($"NUnit.TestParameters.uia={uiaVersion}")
        });
        Information($"Finished UIA{uiaVersion} Tests");
        if (AppVeyor.IsRunningOnAppVeyor) {
            AppVeyor.UploadTestResults(resultFile, AppVeyorTestResultsType.MSTest);
        }
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
    .IsDependentOn("Run-Tests");

//////////////////////////////////////////////////////////////////////
// EXECUTION
//////////////////////////////////////////////////////////////////////

RunTarget(target);
