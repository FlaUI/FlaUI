using FlaUI.Core.Logging;
using Moq;
using NUnit.Framework;
using System;
using System.Globalization;

namespace FlaUI.Core.UnitTests.Logging
{
    [TestFixture]
    public class AbstractBaseLoggerTests
    {
        [Test]
        public void IsTraceEnabled_False_TraceLoggingIsDisabled()
        {
            // Arrange
            var mock = new Mock<AbstractBaseLogger>();
            mock.CallBase = true;

            // This gets us an instance of AbstractBase which has instrumentation
            // on the abstract trace/debug/info...etc methods.
            var instance = mock.Object;
            instance.IsTraceEnabled = false;

            // Act
            instance.Trace("");
            instance.Trace("", new Exception());
            instance.TraceFormat("{0}", 1);
            instance.TraceFormat(new Exception(), "{0}", 1);
            instance.TraceFormat(CultureInfo.CurrentCulture, "{0}", 1);
            instance.TraceFormat(new Exception(), "{0}", 1);

            // Assert
            mock.Verify(x => x.GatedTrace(It.IsAny<string>()), Times.Never);
        }

        [Test]
        public void IsTraceEnabled_True_TraceLoggingIsEnabled()
        {
            // Arrange
            var mock = new Mock<AbstractBaseLogger>();
            mock.CallBase = true;

            // This gets us an instance of AbstractBase which has instrumentation
            // on the abstract trace/debug/info...etc methods.
            var instance = mock.Object;
            instance.IsTraceEnabled = true;

            // Act
            instance.Trace("");
            instance.Trace("", new Exception());
            instance.TraceFormat("{0}", 1);
            instance.TraceFormat(new Exception(), "{0}", 1);
            instance.TraceFormat(CultureInfo.CurrentCulture, "{0}", 1);
            instance.TraceFormat(new Exception(), "{0}", 1);

            // Assert
            mock.Verify(x => x.GatedTrace(It.IsAny<string>()), Times.Exactly(6));
        }

        [Test]
        public void IsDebugEnabled_False_DebugLoggingIsDisabled()
        {
            // Arrange
            var mock = new Mock<AbstractBaseLogger>();
            mock.CallBase = true;

            // This gets us an instance of AbstractBase which has instrumentation
            // on the abstract trace/debug/info...etc methods.
            var instance = mock.Object;
            instance.IsDebugEnabled = false;

            // Act
            instance.Debug("");
            instance.Debug("", new Exception());
            instance.DebugFormat("{0}", 1);
            instance.DebugFormat(new Exception(), "{0}", 1);
            instance.DebugFormat(CultureInfo.CurrentCulture, "{0}", 1);
            instance.DebugFormat(new Exception(), "{0}", 1);

            // Assert
            mock.Verify(x => x.GatedDebug(It.IsAny<string>()), Times.Never);
        }

        [Test]
        public void IsDebugEnabled_True_DebugLoggingIsEnabled()
        {
            // Arrange
            var mock = new Mock<AbstractBaseLogger>();
            mock.CallBase = true;

            // This gets us an instance of AbstractBase which has instrumentation
            // on the abstract trace/debug/info...etc methods.
            var instance = mock.Object;
            instance.IsDebugEnabled = true;

            // Act
            instance.Debug("");
            instance.Debug("", new Exception());
            instance.DebugFormat("{0}", 1);
            instance.DebugFormat(new Exception(), "{0}", 1);
            instance.DebugFormat(CultureInfo.CurrentCulture, "{0}", 1);
            instance.DebugFormat(new Exception(), "{0}", 1);

            // Assert
            mock.Verify(x => x.GatedDebug(It.IsAny<string>()), Times.Exactly(6));
        }

        [Test]
        public void IsInfoEnabled_False_InfoLoggingIsDisabled()
        {
            // Arrange
            var mock = new Mock<AbstractBaseLogger>();
            mock.CallBase = true;

            // This gets us an instance of AbstractBase which has instrumentation
            // on the abstract trace/debug/info...etc methods.
            var instance = mock.Object;
            instance.IsInfoEnabled = false;

            // Act
            instance.Info("");
            instance.Info("", new Exception());
            instance.InfoFormat("{0}", 1);
            instance.InfoFormat(new Exception(), "{0}", 1);
            instance.InfoFormat(CultureInfo.CurrentCulture, "{0}", 1);
            instance.InfoFormat(new Exception(), "{0}", 1);

            // Assert
            mock.Verify(x => x.GatedInfo(It.IsAny<string>()), Times.Never);
        }

        [Test]
        public void IsInfoEnabled_True_InfoLoggingIsEnabled()
        {
            // Arrange
            var mock = new Mock<AbstractBaseLogger>();
            mock.CallBase = true;

            // This gets us an instance of AbstractBase which has instrumentation
            // on the abstract trace/debug/info...etc methods.
            var instance = mock.Object;
            instance.IsInfoEnabled = true;

            // Act
            instance.Info("");
            instance.Info("", new Exception());
            instance.InfoFormat("{0}", 1);
            instance.InfoFormat(new Exception(), "{0}", 1);
            instance.InfoFormat(CultureInfo.CurrentCulture, "{0}", 1);
            instance.InfoFormat(new Exception(), "{0}", 1);

            // Assert
            mock.Verify(x => x.GatedInfo(It.IsAny<string>()), Times.Exactly(6));
        }

        [Test]
        public void IsWarnEnabled_False_WarnLoggingIsDisabled()
        {
            // Arrange
            var mock = new Mock<AbstractBaseLogger>();
            mock.CallBase = true;

            // This gets us an instance of AbstractBase which has instrumentation
            // on the abstract trace/debug/info...etc methods.
            var instance = mock.Object;
            instance.IsWarnEnabled = false;

            // Act
            instance.Warn("");
            instance.Warn("", new Exception());
            instance.WarnFormat("{0}", 1);
            instance.WarnFormat(new Exception(), "{0}", 1);
            instance.WarnFormat(CultureInfo.CurrentCulture, "{0}", 1);
            instance.WarnFormat(new Exception(), "{0}", 1);

            // Assert
            mock.Verify(x => x.GatedWarn(It.IsAny<string>()), Times.Never);
        }

        [Test]
        public void IsWarnEnabled_True_WarnLoggingIsEnabled()
        {
            // Arrange
            var mock = new Mock<AbstractBaseLogger>();
            mock.CallBase = true;

            // This gets us an instance of AbstractBase which has instrumentation
            // on the abstract trace/debug/info...etc methods.
            var instance = mock.Object;
            instance.IsWarnEnabled = true;

            // Act
            instance.Warn("");
            instance.Warn("", new Exception());
            instance.WarnFormat("{0}", 1);
            instance.WarnFormat(new Exception(), "{0}", 1);
            instance.WarnFormat(CultureInfo.CurrentCulture, "{0}", 1);
            instance.WarnFormat(new Exception(), "{0}", 1);

            // Assert
            mock.Verify(x => x.GatedWarn(It.IsAny<string>()), Times.Exactly(6));
        }

        [Test]
        public void IsErrorEnabled_False_ErrorLoggingIsDisabled()
        {
            // Arrange
            var mock = new Mock<AbstractBaseLogger>();
            mock.CallBase = true;

            // This gets us an instance of AbstractBase which has instrumentation
            // on the abstract trace/debug/info...etc methods.
            var instance = mock.Object;
            instance.IsErrorEnabled = false;

            // Act
            instance.Error("");
            instance.Error("", new Exception());
            instance.ErrorFormat("{0}", 1);
            instance.ErrorFormat(new Exception(), "{0}", 1);
            instance.ErrorFormat(CultureInfo.CurrentCulture, "{0}", 1);
            instance.ErrorFormat(new Exception(), "{0}", 1);

            // Assert
            mock.Verify(x => x.GatedError(It.IsAny<string>()), Times.Never);
        }

        [Test]
        public void IsErrorEnabled_True_ErrorLoggingIsEnabled()
        {
            // Arrange
            var mock = new Mock<AbstractBaseLogger>();
            mock.CallBase = true;

            // This gets us an instance of AbstractBase which has instrumentation
            // on the abstract trace/debug/info...etc methods.
            var instance = mock.Object;
            instance.IsErrorEnabled = true;

            // Act
            instance.Error("");
            instance.Error("", new Exception());
            instance.ErrorFormat("{0}", 1);
            instance.ErrorFormat(new Exception(), "{0}", 1);
            instance.ErrorFormat(CultureInfo.CurrentCulture, "{0}", 1);
            instance.ErrorFormat(new Exception(), "{0}", 1);

            // Assert
            mock.Verify(x => x.GatedError(It.IsAny<string>()), Times.Exactly(6));
        }

        [Test]
        public void IsFatalEnabled_False_FatalLoggingIsDisabled()
        {
            // Arrange
            var mock = new Mock<AbstractBaseLogger>();
            mock.CallBase = true;

            // This gets us an instance of AbstractBase which has instrumentation
            // on the abstract trace/debug/info...etc methods.
            var instance = mock.Object;
            instance.IsFatalEnabled = false;

            // Act
            instance.Fatal("");
            instance.Fatal("", new Exception());
            instance.FatalFormat("{0}", 1);
            instance.FatalFormat(new Exception(), "{0}", 1);
            instance.FatalFormat(CultureInfo.CurrentCulture, "{0}", 1);
            instance.FatalFormat(new Exception(), "{0}", 1);

            // Assert
            mock.Verify(x => x.GatedFatal(It.IsAny<string>()), Times.Never);
        }

        [Test]
        public void IsFatalEnabled_True_FatalLoggingIsEnabled()
        {
            // Arrange
            var mock = new Mock<AbstractBaseLogger>();
            mock.CallBase = true;

            // This gets us an instance of AbstractBase which has instrumentation
            // on the abstract trace/debug/info...etc methods.
            var instance = mock.Object;
            instance.IsFatalEnabled = true;

            // Act
            instance.Fatal("");
            instance.Fatal("", new Exception());
            instance.FatalFormat("{0}", 1);
            instance.FatalFormat(new Exception(), "{0}", 1);
            instance.FatalFormat(CultureInfo.CurrentCulture, "{0}", 1);
            instance.FatalFormat(new Exception(), "{0}", 1);

            // Assert
            mock.Verify(x => x.GatedFatal(It.IsAny<string>()), Times.Exactly(6));
        }
    }
}
