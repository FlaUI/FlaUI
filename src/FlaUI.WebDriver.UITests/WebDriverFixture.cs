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

            var webDriverProcessStartInfo = new ProcessStartInfo($"..\\..\\..\\..\\FlaUI.WebDriver\\bin\\{buildConfigurationName}\\FlaUI.WebDriver.exe", $"--urls={WebDriverUrl}")
            {
                RedirectStandardError = true,
                RedirectStandardOutput = true
            };
            _webDriverProcess = new Process()
            {
                StartInfo = webDriverProcessStartInfo
            };
            _webDriverProcess.Start();

            System.Threading.Thread.Sleep(5000);
            if (_webDriverProcess.HasExited)
            {
                throw new Exception($"Could not start WebDriver: {_webDriverProcess.StandardError.ReadToEnd()}");
            }
        }

        [OneTimeTearDown]
        public void Dispose()
        {
            if (_webDriverProcess.HasExited)
            {
                Console.WriteLine("WebDriver has exited");
            }
            _webDriverProcess.Kill();
            _webDriverProcess.Dispose();
        }
    }
}