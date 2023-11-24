using NUnit.Framework;
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace FlaUI.WebDriver.UITests
{
    [SetUpFixture]
    public class WebDriverFixture
    {
        public static readonly Uri WebDriverUrl = new Uri("http://localhost:4723/");

        private Process _webDriverProcess;

        [OneTimeSetUp]
        public void Setup()
        {
            string assemblyDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            Directory.SetCurrentDirectory(assemblyDir);

            var assemblyConfigurationAttribute = Assembly.GetExecutingAssembly().GetCustomAttribute<AssemblyConfigurationAttribute>();
            var buildConfigurationName = assemblyConfigurationAttribute?.Configuration;

            var webDriverPath = $"..\\..\\..\\..\\FlaUI.WebDriver\\bin\\{buildConfigurationName}\\FlaUI.WebDriver.exe";
            var webDriverArguments = $"--urls={WebDriverUrl}";
            var webDriverProcessStartInfo = new ProcessStartInfo(webDriverPath, webDriverArguments)
            {
                RedirectStandardError = true,
                RedirectStandardOutput = true
            };
            _webDriverProcess = new Process()
            {
                StartInfo = webDriverProcessStartInfo
            };
            TestContext.Progress.WriteLine($"Attempting to start web driver with command {webDriverPath} {webDriverArguments}");
            _webDriverProcess.Start();

            System.Threading.Thread.Sleep(5000);
            if (_webDriverProcess.HasExited)
            {
                var error = _webDriverProcess.StandardError.ReadToEnd();
                if (error.Contains("address already in use"))
                {
                    // For manual debugging of FlaUI.WebDriver it is nice to be able to start it separately
                    TestContext.Progress.WriteLine("Using already running web driver instead");
                    return;
                }
                throw new Exception($"Could not start WebDriver: {error}");
            }
        }

        [OneTimeTearDown]
        public void Dispose()
        {
            if (_webDriverProcess.HasExited)
            {
                var error = _webDriverProcess.StandardError.ReadToEnd();
                Console.Error.WriteLine($"WebDriver has exited before end of the test: {error}");
            }
            else
            {
                TestContext.Progress.WriteLine("Killing web driver");
                _webDriverProcess.Kill(true);
            }
            TestContext.Progress.WriteLine("Disposing web driver");
            _webDriverProcess.Dispose();
            TestContext.Progress.WriteLine("Finished disposing web driver");
        }
    }
}