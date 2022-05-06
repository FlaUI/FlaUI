using System;
using System.Collections.Generic;
using FlaUI.Core.Tools;
using FluentAssertions;
using NUnit.Framework;

namespace FlaUI.Core.UnitTests
{
    [TestFixture]
    public class RetryTests
    {
        [Test]
        public void RetryWhileTrue()
        {
            var start = DateTime.UtcNow;
            var result = Retry.WhileTrue(() => DateTime.UtcNow - start < TimeSpan.FromSeconds(1), timeout: TimeSpan.FromSeconds(2), throwOnTimeout: false);
            AssertTookAtLeast(start, TimeSpan.FromSeconds(1));
            AssertSuccess(result);
            result.Result.Should().BeTrue();
        }

        [Test]
        public void RetryWhileTrueFails()
        {
            var start = DateTime.UtcNow;
            var result = Retry.WhileTrue(() => DateTime.UtcNow - start < TimeSpan.FromSeconds(4), timeout: TimeSpan.FromSeconds(1), throwOnTimeout: false);
            AssertTookAtLeast(start, TimeSpan.FromSeconds(1));
            AssertTimedOut(result);
            result.Result.Should().BeFalse();
        }

        [Test]
        public void RetryWhileTrueTimeouts()
        {
            var start = DateTime.UtcNow;
            Assert.Throws<TimeoutException>(() =>
            {
                Retry.WhileTrue(() => DateTime.UtcNow - start < TimeSpan.FromSeconds(4), timeout: TimeSpan.FromSeconds(1), throwOnTimeout: true);
            });
        }

        [Test]
        public void RetryWhileTrueThrowsOnException()
        {
            var start = DateTime.UtcNow;
            Assert.Throws<Exception>(() =>
            {
                Retry.WhileTrue(() => throw new Exception(), timeout: TimeSpan.FromSeconds(1), throwOnTimeout: true, ignoreException: false);
            });
        }

        [Test]
        public void RetryWhileTrueIgnoresException()
        {
            var start = DateTime.UtcNow;
            var exceptionCount = 0;
            var result = Retry.WhileTrue(() =>
            {
                var runtime = DateTime.UtcNow - start;
                if (runtime < TimeSpan.FromSeconds(1))
                {
                    exceptionCount++;
                    throw new Exception();
                }
                return false;
            }, timeout: TimeSpan.FromSeconds(2), throwOnTimeout: true, ignoreException: true);
            exceptionCount.Should().BeGreaterThan(0);
            AssertTookAtLeast(start, TimeSpan.FromSeconds(1));
            AssertHasException(result);
            AssertSuccess(result);
            result.Result.Should().BeTrue();
        }

        public void RetryWhileFalse()
        {
            var start = DateTime.UtcNow;
            var result = Retry.WhileFalse(() => DateTime.UtcNow - start > TimeSpan.FromSeconds(1), timeout: TimeSpan.FromSeconds(2), throwOnTimeout: false);
            AssertTookAtLeast(start, TimeSpan.FromSeconds(1));
            AssertSuccess(result);
            result.Result.Should().BeTrue();
        }

        [Test]
        public void RetryWhileFalseFails()
        {
            var start = DateTime.UtcNow;
            var result = Retry.WhileFalse(() => DateTime.UtcNow - start > TimeSpan.FromSeconds(4), timeout: TimeSpan.FromSeconds(1), throwOnTimeout: false);
            AssertTookAtLeast(start, TimeSpan.FromSeconds(1));
            AssertTimedOut(result);
            result.Result.Should().BeFalse();
        }

        [Test]
        public void RetryWhileException()
        {
            var start = DateTime.UtcNow;
            var exceptionCount = 0;
            var result = Retry.WhileException(() =>
            {
                var runtime = DateTime.UtcNow - start;
                if (runtime < TimeSpan.FromSeconds(1))
                {
                    exceptionCount++;
                    throw new Exception();
                }
            }, timeout: TimeSpan.FromSeconds(2), throwOnTimeout: true);
            exceptionCount.Should().BeGreaterThan(0);
            AssertTookAtLeast(start, TimeSpan.FromSeconds(1));
            AssertHasException(result);
            result.Result.Should().BeTrue();
        }

        [Test]
        public void RetryWhileExceptionFails()
        {
            var start = DateTime.UtcNow;
            var exceptionCount = 0;
            var result = Retry.WhileException(() =>
            {
                var runtime = DateTime.UtcNow - start;
                if (runtime < TimeSpan.FromSeconds(4))
                {
                    exceptionCount++;
                    throw new Exception();
                }
            }, timeout: TimeSpan.FromSeconds(1), throwOnTimeout: false);
            exceptionCount.Should().BeGreaterThan(0);
            AssertTookAtLeast(start, TimeSpan.FromSeconds(1));
            AssertHasException(result);
            AssertTimedOut(result);
            result.Result.Should().BeFalse();
        }

        [Test]
        public void RetryWhileExceptionTimeouts()
        {
            var start = DateTime.UtcNow;
            var exceptionCount = 0;
            var exception = Assert.Throws<TimeoutException>(() =>
            {
                var result = Retry.WhileException(() =>
                {
                    var runtime = DateTime.UtcNow - start;
                    if (runtime < TimeSpan.FromSeconds(4))
                    {
                        exceptionCount++;
                        throw new Exception();
                    }
                }, timeout: TimeSpan.FromSeconds(1), throwOnTimeout: true);
            });
            exception.InnerException.Should().NotBeNull();
            exceptionCount.Should().BeGreaterThan(0);
            AssertTookAtLeast(start, TimeSpan.FromSeconds(1));
        }

        [Test]
        public void RetryWhileExceptionWithObject()
        {
            var start = DateTime.UtcNow;
            var exceptionCount = 0;
            var result = Retry.WhileException(() =>
            {
                var runtime = DateTime.UtcNow - start;
                if (runtime < TimeSpan.FromSeconds(1))
                {
                    exceptionCount++;
                    throw new Exception();
                }
                return 1;
            }, timeout: TimeSpan.FromSeconds(2), throwOnTimeout: true);
            exceptionCount.Should().BeGreaterThan(0);
            AssertTookAtLeast(start, TimeSpan.FromSeconds(1));
            AssertHasException(result);
            AssertSuccess(result);
            result.Result.Should().Be(1);
        }

        [Test]
        public void RetryWhileExceptionWithObjectFails()
        {
            var start = DateTime.UtcNow;
            var exceptionCount = 0;
            var result = Retry.WhileException(() =>
            {
                var runtime = DateTime.UtcNow - start;
                if (runtime < TimeSpan.FromSeconds(4))
                {
                    exceptionCount++;
                    throw new Exception();
                }
                return 1;
            }, timeout: TimeSpan.FromSeconds(1), throwOnTimeout: false);
            exceptionCount.Should().BeGreaterThan(0);
            AssertTookAtLeast(start, TimeSpan.FromSeconds(1));
            AssertHasException(result);
            AssertTimedOut(result);
            result.Result.Should().Be(0);
        }

        [Test]
        public void RetryWhileExceptionWithObjectTimeouts()
        {
            var start = DateTime.UtcNow;
            var exceptionCount = 0;
            var exception = Assert.Throws<TimeoutException>(() =>
            {
                var result = Retry.WhileException(() =>
                {
                    var runtime = DateTime.UtcNow - start;
                    if (runtime < TimeSpan.FromSeconds(4))
                    {
                        exceptionCount++;
                        throw new Exception();
                    }
                    return 1;
                }, timeout: TimeSpan.FromSeconds(1), throwOnTimeout: true);
            });
            exception.InnerException.Should().NotBeNull();
            exceptionCount.Should().BeGreaterThan(0);
            AssertTookAtLeast(start, TimeSpan.FromSeconds(1));
        }

        [Test]
        public void RetryWhileNull()
        {
            var start = DateTime.UtcNow;
            var result = Retry.WhileNull(() =>
            {
                var runtime = DateTime.UtcNow - start;
                if (runtime < TimeSpan.FromSeconds(1))
                {
                    return null;
                }
                return new object();
            }, timeout: TimeSpan.FromSeconds(2), throwOnTimeout: true);
            AssertTookAtLeast(start, TimeSpan.FromSeconds(1));
            AssertSuccess(result);
            result.Result.Should().NotBeNull();
        }

        [Test]
        public void RetryWhileNullFails()
        {
            var start = DateTime.UtcNow;
            var result = Retry.WhileNull(() =>
            {
                var runtime = DateTime.UtcNow - start;
                if (runtime < TimeSpan.FromSeconds(4))
                {
                    return null;
                }
                return new object();
            }, timeout: TimeSpan.FromSeconds(1), throwOnTimeout: false);
            AssertTookAtLeast(start, TimeSpan.FromSeconds(1));
            AssertTimedOut(result);
            result.Result.Should().BeNull();
        }

        [Test]
        public void RetryWhileNotNull()
        {
            var start = DateTime.UtcNow;
            var result = Retry.WhileNotNull(() =>
            {
                var runtime = DateTime.UtcNow - start;
                if (runtime < TimeSpan.FromSeconds(1))
                {
                    return new object();
                }
                return null;
            }, timeout: TimeSpan.FromSeconds(2), throwOnTimeout: true);
            AssertTookAtLeast(start, TimeSpan.FromSeconds(1));
            AssertSuccess(result);
            result.Result.Should().BeTrue();
        }

        [Test]
        public void RetryWhileNotNullFails()
        {
            var start = DateTime.UtcNow;
            var result = Retry.WhileNotNull(() =>
            {
                var runtime = DateTime.UtcNow - start;
                if (runtime < TimeSpan.FromSeconds(4))
                {
                    return new object();
                }
                return null;
            }, timeout: TimeSpan.FromSeconds(1), throwOnTimeout: false);
            AssertTookAtLeast(start, TimeSpan.FromSeconds(1));
            AssertTimedOut(result);
            result.Result.Should().BeFalse();
        }

        [Test]
        public void RetryWhileNotNullException()
        {
            var start = DateTime.UtcNow;
            var result = Retry.WhileNotNull<object>(() =>
            {
                var runtime = DateTime.UtcNow - start;
                if (runtime < TimeSpan.FromSeconds(4))
                {
                    throw new Exception();
                }
                return null;
            }, timeout: TimeSpan.FromSeconds(1), throwOnTimeout: false, ignoreException: true);
            AssertTookAtLeast(start, TimeSpan.FromSeconds(1));
            AssertHasException(result);
            AssertTimedOut(result);
            result.Result.Should().BeFalse();
        }

        [Test]
        public void RetryWhileEmpty()
        {
            var start = DateTime.UtcNow;
            var result = Retry.WhileEmpty(() =>
            {
                var runtime = DateTime.UtcNow - start;
                if (runtime < TimeSpan.FromSeconds(1))
                {
                    return null;
                }
                return new List<int>() { 1, 2 };
            }, timeout: TimeSpan.FromSeconds(2), throwOnTimeout: true);
            AssertTookAtLeast(start, TimeSpan.FromSeconds(1));
            AssertSuccess(result);
            result.Result.Should().HaveCount(2);
        }

        [Test]
        public void RetryWhileEmptyFails()
        {
            var start = DateTime.UtcNow;
            var result = Retry.WhileEmpty(() =>
            {
                var runtime = DateTime.UtcNow - start;
                if (runtime < TimeSpan.FromSeconds(4))
                {
                    return null;
                }
                return new List<int>() { 1, 2 };
            }, timeout: TimeSpan.FromSeconds(1), throwOnTimeout: false);
            AssertTookAtLeast(start, TimeSpan.FromSeconds(1));
            AssertTimedOut(result);
            result.Result.Should().BeNull();
        }

        [Test]
        public void RetryWhileEmptyString()
        {
            var start = DateTime.UtcNow;
            var result = Retry.WhileEmpty(() =>
            {
                var runtime = DateTime.UtcNow - start;
                if (runtime < TimeSpan.FromSeconds(1))
                {
                    return null;
                }
                return "Test";
            }, timeout: TimeSpan.FromSeconds(2), throwOnTimeout: true);
            AssertTookAtLeast(start, TimeSpan.FromSeconds(1));
            AssertSuccess(result);
            result.Result.Should().Be("Test");
        }

        [Test]
        public void RetryWhileEmptyStringFails()
        {
            var start = DateTime.UtcNow;
            var result = Retry.WhileEmpty(() =>
            {
                var runtime = DateTime.UtcNow - start;
                if (runtime < TimeSpan.FromSeconds(4))
                {
                    return null;
                }
                return "Test";
            }, timeout: TimeSpan.FromSeconds(1), throwOnTimeout: false);
            AssertTookAtLeast(start, TimeSpan.FromSeconds(1));
            AssertTimedOut(result);
            result.Result.Should().BeNull();
        }

        private void AssertTookAtLeast(DateTime start, TimeSpan minTime)
        {
            (DateTime.UtcNow - start).Should().BeGreaterThanOrEqualTo(minTime);
        }

        private void AssertSuccess<T>(RetryResult<T> retryResult)
        {
            retryResult.Success.Should().BeTrue();
            retryResult.TimedOut.Should().BeFalse();
        }

        private void AssertTimedOut<T>(RetryResult<T> retryResult)
        {
            retryResult.Success.Should().BeFalse();
            retryResult.TimedOut.Should().BeTrue();
        }

        private void AssertHasException<T>(RetryResult<T> retryResult)
        {
            retryResult.HadException.Should().BeTrue();
            retryResult.LastException.Should().NotBeNull();
        }
    }
}
