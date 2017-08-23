using Moq;
using NUnit.Framework;
using System;

namespace FlaUI.Core.UnitTests.Logging
{
    [TestFixture]
    public class TestLoggerTests
    {
        [Test]
        public void IsTraceEnabled_False_TraceLoggingIsDisabled()
        {
            // Arrange
            var mock = new Mock<TestLogger>
            {
                CallBase = true
            };

            // This gets us an instance of AbstractBase which has instrumentation
            // on the abstract trace/debug/info...etc methods.
            var instance = mock.Object;
            instance.IsTraceEnabled = false;

            // Act
            instance.Trace(String.Empty);
            instance.Trace(String.Empty, new Exception());
            instance.Trace("{0}", 1);
            instance.Trace("{0}", new Exception(), 1);

            // Assert
            mock.Verify(x => x.PublicTrace(It.IsAny<string>()), Times.Never);
        }

        [Test]
        public void IsTraceEnabled_True_TraceLoggingIsEnabled()
        {
            // Arrange
            var mock = new Mock<TestLogger>
            {
                CallBase = true
            };

            // This gets us an instance of AbstractBase which has instrumentation
            // on the abstract trace/debug/info...etc methods.
            var instance = mock.Object;
            instance.IsTraceEnabled = true;

            // Act
            instance.Trace(String.Empty);
            instance.Trace(String.Empty, new Exception());
            instance.Trace("{0}", 1);
            instance.Trace("{0}", new Exception(), 1);

            // Assert
            mock.Verify(x => x.PublicTrace(It.IsAny<string>()), Times.Exactly(4));
        }

        [Test]
        public void IsDebugEnabled_False_DebugLoggingIsDisabled()
        {
            // Arrange
            var mock = new Mock<TestLogger>
            {
                CallBase = true
            };

            // This gets us an instance of AbstractBase which has instrumentation
            // on the abstract trace/debug/info...etc methods.
            var instance = mock.Object;
            instance.IsDebugEnabled = false;

            // Act
            instance.Debug(String.Empty);
            instance.Debug(String.Empty, new Exception());
            instance.Debug("{0}", 1);
            instance.Debug("{0}", new Exception(), 1);

            // Assert
            mock.Verify(x => x.PublicDebug(It.IsAny<string>()), Times.Never);
        }

        [Test]
        public void IsDebugEnabled_True_DebugLoggingIsEnabled()
        {
            // Arrange
            var mock = new Mock<TestLogger>
            {
                CallBase = true
            };

            // This gets us an instance of AbstractBase which has instrumentation
            // on the abstract trace/debug/info...etc methods.
            var instance = mock.Object;
            instance.IsDebugEnabled = true;

            // Act
            instance.Debug(String.Empty);
            instance.Debug(String.Empty, new Exception());
            instance.Debug("{0}", 1);
            instance.Debug("{0}", new Exception(), 1);

            // Assert
            mock.Verify(x => x.PublicDebug(It.IsAny<string>()), Times.Exactly(4));
        }

        [Test]
        public void IsInfoEnabled_False_InfoLoggingIsDisabled()
        {
            // Arrange
            var mock = new Mock<TestLogger>
            {
                CallBase = true
            };

            // This gets us an instance of AbstractBase which has instrumentation
            // on the abstract trace/debug/info...etc methods.
            var instance = mock.Object;
            instance.IsInfoEnabled = false;

            // Act
            instance.Info(String.Empty);
            instance.Info(String.Empty, new Exception());
            instance.Info("{0}", 1);
            instance.Info("{0}", new Exception(), 1);

            // Assert
            mock.Verify(x => x.PublicInfo(It.IsAny<string>()), Times.Never);
        }

        [Test]
        public void IsInfoEnabled_True_InfoLoggingIsEnabled()
        {
            // Arrange
            var mock = new Mock<TestLogger>
            {
                CallBase = true
            };

            // This gets us an instance of AbstractBase which has instrumentation
            // on the abstract trace/debug/info...etc methods.
            var instance = mock.Object;
            instance.IsInfoEnabled = true;

            // Act
            instance.Info(String.Empty);
            instance.Info(String.Empty, new Exception());
            instance.Info("{0}", 1);
            instance.Info("{0}", new Exception(), 1);

            // Assert
            mock.Verify(x => x.PublicInfo(It.IsAny<string>()), Times.Exactly(4));
        }

        [Test]
        public void IsWarnEnabled_False_WarnLoggingIsDisabled()
        {
            // Arrange
            var mock = new Mock<TestLogger>
            {
                CallBase = true
            };

            // This gets us an instance of AbstractBase which has instrumentation
            // on the abstract trace/debug/info...etc methods.
            var instance = mock.Object;
            instance.IsWarnEnabled = false;

            // Act
            instance.Warn(String.Empty);
            instance.Warn(String.Empty, new Exception());
            instance.Warn("{0}", 1);
            instance.Warn("{0}", new Exception(), 1);

            // Assert
            mock.Verify(x => x.PublicWarn(It.IsAny<string>()), Times.Never);
        }

        [Test]
        public void IsWarnEnabled_True_WarnLoggingIsEnabled()
        {
            // Arrange
            var mock = new Mock<TestLogger>
            {
                CallBase = true
            };

            // This gets us an instance of AbstractBase which has instrumentation
            // on the abstract trace/debug/info...etc methods.
            var instance = mock.Object;
            instance.IsWarnEnabled = true;

            // Act
            instance.Warn(String.Empty);
            instance.Warn(String.Empty, new Exception());
            instance.Warn("{0}", 1);
            instance.Warn("{0}", new Exception(), 1);

            // Assert
            mock.Verify(x => x.PublicWarn(It.IsAny<string>()), Times.Exactly(4));
        }

        [Test]
        public void IsErrorEnabled_False_ErrorLoggingIsDisabled()
        {
            // Arrange
            var mock = new Mock<TestLogger>
            {
                CallBase = true
            };

            // This gets us an instance of AbstractBase which has instrumentation
            // on the abstract trace/debug/info...etc methods.
            var instance = mock.Object;
            instance.IsErrorEnabled = false;

            // Act
            instance.Error(String.Empty);
            instance.Error(String.Empty, new Exception());
            instance.Error("{0}", 1);
            instance.Error("{0}", new Exception(), 1);

            // Assert
            mock.Verify(x => x.PublicError(It.IsAny<string>()), Times.Never);
        }

        [Test]
        public void IsErrorEnabled_True_ErrorLoggingIsEnabled()
        {
            // Arrange
            var mock = new Mock<TestLogger>
            {
                CallBase = true
            };

            // This gets us an instance of AbstractBase which has instrumentation
            // on the abstract trace/debug/info...etc methods.
            var instance = mock.Object;
            instance.IsErrorEnabled = true;

            // Act
            instance.Error(String.Empty);
            instance.Error(String.Empty, new Exception());
            instance.Error("{0}", 1);
            instance.Error("{0}", new Exception(), 1);

            // Assert
            mock.Verify(x => x.PublicError(It.IsAny<string>()), Times.Exactly(4));
        }

        [Test]
        public void IsFatalEnabled_False_FatalLoggingIsDisabled()
        {
            // Arrange
            var mock = new Mock<TestLogger>
            {
                CallBase = true
            };

            // This gets us an instance of AbstractBase which has instrumentation
            // on the abstract trace/debug/info...etc methods.
            var instance = mock.Object;
            instance.IsFatalEnabled = false;

            // Act
            instance.Fatal(String.Empty);
            instance.Fatal(String.Empty, new Exception());
            instance.Fatal("{0}", 1);
            instance.Fatal("{0}", new Exception(), 1);

            // Assert
            mock.Verify(x => x.PublicFatal(It.IsAny<string>()), Times.Never);
        }

        [Test]
        public void IsFatalEnabled_True_FatalLoggingIsEnabled()
        {
            // Arrange
            var mock = new Mock<TestLogger>
            {
                CallBase = true
            };

            // This gets us an instance of AbstractBase which has instrumentation
            // on the abstract trace/debug/info...etc methods.
            var instance = mock.Object;
            instance.IsFatalEnabled = true;

            // Act
            instance.Fatal(String.Empty);
            instance.Fatal(String.Empty, new Exception());
            instance.Fatal("{0}", 1);
            instance.Fatal("{0}", new Exception(), 1);

            // Assert
            mock.Verify(x => x.PublicFatal(It.IsAny<string>()), Times.Exactly(4));
        }
    }
}
