using System;
using System.Diagnostics;
using FlaUI.Core;
using NUnit.Framework;

namespace FlaUI.Core.UnitTests
{
    [TestFixture]
    public class ApplicationTests
    {
        [Test]
        public void DisposeDoesNotDisposeProcessProvidedToConstructor()
        {
            using (var process = Process.GetCurrentProcess())
            {
                using (new Application(process))
                {
                }

                AssertProcessCanStillBeUsed(process);
            }
        }

        [Test]
        public void DisposeDoesNotDisposeProcessProvidedToAttach()
        {
            using (var process = Process.GetCurrentProcess())
            {
                using (Application.Attach(process))
                {
                }

                AssertProcessCanStillBeUsed(process);
            }
        }

        [Test]
        public void WaitWhileMainHandleIsMissingDoesNotDisposeProcessProvidedToAttach()
        {
            using (var process = Process.GetCurrentProcess())
            {
                using (var app = Application.Attach(process))
                {
                    app.WaitWhileMainHandleIsMissing(TimeSpan.Zero);
                }

                AssertProcessCanStillBeUsed(process);
            }
        }

        [Test]
        public void WaitWhileMainHandleIsMissingCanRefreshMultipleTimesWithoutDisposingOriginalProcess()
        {
            using (var process = StartLongRunningProcess())
            {
                var processId = process.Id;
                try
                {
                    using (var app = Application.Attach(process))
                    {
                        app.WaitWhileMainHandleIsMissing(TimeSpan.FromMilliseconds(150));
                    }

                    AssertProcessCanStillBeUsed(process);
                }
                finally
                {
                    KillProcess(process, processId);
                }
            }
        }

        [Test]
        public void DisposeAfterWaitWhileMainHandleIsMissingDoesNotDisposeOriginalProcess()
        {
            using (var process = StartLongRunningProcess())
            {
                var processId = process.Id;
                try
                {
                    var app = Application.Attach(process);
                    app.WaitWhileMainHandleIsMissing(TimeSpan.Zero);
                    app.Dispose();

                    AssertProcessCanStillBeUsed(process);
                }
                finally
                {
                    KillProcess(process, processId);
                }
            }
        }

        [Test]
        public void AttachByProcessIdDoesNotAffectExistingProcessInstance()
        {
            using (var process = StartLongRunningProcess())
            {
                var processId = process.Id;
                try
                {
                    using (var app = Application.Attach(process.Id))
                    {
                        app.WaitWhileMainHandleIsMissing(TimeSpan.Zero);
                    }

                    AssertProcessCanStillBeUsed(process);
                }
                finally
                {
                    KillProcess(process, processId);
                }
            }
        }

        [Test]
        public void KillStillTerminatesTargetProcessWhenProcessObjectIsExternal()
        {
            using (var process = StartLongRunningProcess())
            {
                var processId = process.Id;
                try
                {
                    using (var app = Application.Attach(process))
                    {
                        app.Kill();
                    }

                    Assert.That(process.HasExited, Is.True);
                    Assert.That(process.ExitCode, Is.Not.EqualTo(Int32.MinValue));
                }
                finally
                {
                    KillProcess(process, processId);
                }
            }
        }

        private static void AssertProcessCanStillBeUsed(Process process)
        {
            Assert.DoesNotThrow(() =>
            {
                Assert.That(process.Id, Is.GreaterThan(0));
                Assert.That(process.HasExited, Is.False);
            });
        }

        private static Process StartLongRunningProcess()
        {
            var process = Process.Start(new ProcessStartInfo
            {
                FileName = Environment.GetEnvironmentVariable("ComSpec") ?? "cmd.exe",
                Arguments = "/c ping 127.0.0.1 -n 6 > nul",
                CreateNoWindow = true,
                UseShellExecute = false
            });

            if (process == null)
            {
                throw new InvalidOperationException("Failed to start test process.");
            }

            return process;
        }

        private static void KillProcess(Process process, int processId)
        {
            try
            {
                if (process.HasExited)
                {
                    return;
                }

                process.Kill();
                process.WaitForExit();
            }
            catch (InvalidOperationException)
            {
                KillProcessById(processId);
            }
        }

        private static void KillProcessById(int processId)
        {
            try
            {
                using (var process = Process.GetProcessById(processId))
                {
                    if (process.HasExited)
                    {
                        return;
                    }

                    process.Kill();
                    process.WaitForExit();
                }
            }
            catch (ArgumentException)
            {
            }
        }
    }
}
