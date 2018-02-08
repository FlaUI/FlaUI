using System;
using System.Collections.Generic;
using FlaUI.Core.Tools;
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
            Assert.That(DateTime.UtcNow - start, Is.GreaterThanOrEqualTo(TimeSpan.FromSeconds(1)));
            Assert.That(result, Is.True);
        }

        [Test]
        public void RetryWhileTrueFails()
        {
            var start = DateTime.UtcNow;
            var result = Retry.WhileTrue(() => DateTime.UtcNow - start < TimeSpan.FromSeconds(4), timeout: TimeSpan.FromSeconds(1), throwOnTimeout: false);
            Assert.That(DateTime.UtcNow - start, Is.GreaterThanOrEqualTo(TimeSpan.FromSeconds(1)));
            Assert.That(result, Is.False);
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
            Assert.That(DateTime.UtcNow - start, Is.GreaterThanOrEqualTo(TimeSpan.FromSeconds(1)));
            Assert.That(exceptionCount, Is.GreaterThan(0));
            Assert.That(result, Is.True);
        }

        public void RetryWhileFalse()
        {
            var start = DateTime.UtcNow;
            var result = Retry.WhileFalse(() => DateTime.UtcNow - start > TimeSpan.FromSeconds(1), timeout: TimeSpan.FromSeconds(2), throwOnTimeout: false);
            Assert.That(DateTime.UtcNow - start, Is.GreaterThanOrEqualTo(TimeSpan.FromSeconds(1)));
            Assert.That(result, Is.True);
        }

        [Test]
        public void RetryWhileFalseFails()
        {
            var start = DateTime.UtcNow;
            var result = Retry.WhileFalse(() => DateTime.UtcNow - start > TimeSpan.FromSeconds(4), timeout: TimeSpan.FromSeconds(1), throwOnTimeout: false);
            Assert.That(DateTime.UtcNow - start, Is.GreaterThanOrEqualTo(TimeSpan.FromSeconds(1)));
            Assert.That(result, Is.False);
        }

        [Test]
        public void RetryWhileException()
        {
            var start = DateTime.UtcNow;
            var exceptionCount = 0;
            var success = Retry.WhileException(() =>
            {
                var runtime = DateTime.UtcNow - start;
                if (runtime < TimeSpan.FromSeconds(1))
                {
                    exceptionCount++;
                    throw new Exception();
                }
            }, timeout: TimeSpan.FromSeconds(2), throwOnTimeout: true);
            Assert.That(DateTime.UtcNow - start, Is.GreaterThanOrEqualTo(TimeSpan.FromSeconds(1)));
            Assert.That(success, Is.True);
            Assert.That(exceptionCount, Is.GreaterThan(0));
        }

        [Test]
        public void RetryWhileExceptionFails()
        {
            var start = DateTime.UtcNow;
            var exceptionCount = 0;
            var success = Retry.WhileException(() =>
            {
                var runtime = DateTime.UtcNow - start;
                if (runtime < TimeSpan.FromSeconds(4))
                {
                    exceptionCount++;
                    throw new Exception();
                }
            }, timeout: TimeSpan.FromSeconds(1), throwOnTimeout: false);
            Assert.That(DateTime.UtcNow - start, Is.GreaterThanOrEqualTo(TimeSpan.FromSeconds(1)));
            Assert.That(success, Is.False);
            Assert.That(exceptionCount, Is.GreaterThan(0));
        }

        [Test]
        public void RetryWhileExceptionTimeouts()
        {
            var start = DateTime.UtcNow;
            var exceptionCount = 0;
            var exception = Assert.Throws<TimeoutException>(() =>
            {
                var success = Retry.WhileException(() =>
                {
                    var runtime = DateTime.UtcNow - start;
                    if (runtime < TimeSpan.FromSeconds(4))
                    {
                        exceptionCount++;
                        throw new Exception();
                    }
                }, timeout: TimeSpan.FromSeconds(1), throwOnTimeout: true);
            });
            Assert.That(exception.InnerException, Is.Not.Null);
            Assert.That(DateTime.UtcNow - start, Is.GreaterThanOrEqualTo(TimeSpan.FromSeconds(1)));
            Assert.That(exceptionCount, Is.GreaterThan(0));
        }

        [Test]
        public void RetryWhileExceptionWithObject()
        {
            var start = DateTime.UtcNow;
            var exceptionCount = 0;
            var retValue = Retry.WhileException(() =>
            {
                var runtime = DateTime.UtcNow - start;
                if (runtime < TimeSpan.FromSeconds(1))
                {
                    exceptionCount++;
                    throw new Exception();
                }
                return 1;
            }, timeout: TimeSpan.FromSeconds(2), throwOnTimeout: true);
            Assert.That(DateTime.UtcNow - start, Is.GreaterThanOrEqualTo(TimeSpan.FromSeconds(1)));
            Assert.That(retValue, Is.EqualTo(1));
            Assert.That(exceptionCount, Is.GreaterThan(0));
        }

        [Test]
        public void RetryWhileExceptionWithObjectFails()
        {
            var start = DateTime.UtcNow;
            var exceptionCount = 0;
            var retValue = Retry.WhileException(() =>
            {
                var runtime = DateTime.UtcNow - start;
                if (runtime < TimeSpan.FromSeconds(4))
                {
                    exceptionCount++;
                    throw new Exception();
                }
                return 1;
            }, timeout: TimeSpan.FromSeconds(1), throwOnTimeout: false);
            Assert.That(DateTime.UtcNow - start, Is.GreaterThanOrEqualTo(TimeSpan.FromSeconds(1)));
            Assert.That(retValue, Is.EqualTo(0));
            Assert.That(exceptionCount, Is.GreaterThan(0));
        }

        [Test]
        public void RetryWhileExceptionWithObjectTimeouts()
        {
            var start = DateTime.UtcNow;
            var exceptionCount = 0;
            var exception = Assert.Throws<TimeoutException>(() =>
            {
                var retValue = Retry.WhileException(() =>
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
            Assert.That(exception.InnerException, Is.Not.Null);
            Assert.That(DateTime.UtcNow - start, Is.GreaterThanOrEqualTo(TimeSpan.FromSeconds(1)));
            Assert.That(exceptionCount, Is.GreaterThan(0));
        }

        [Test]
        public void RetryWhileNull()
        {
            var start = DateTime.UtcNow;
            var retValue = Retry.WhileNull(() =>
            {
                var runtime = DateTime.UtcNow - start;
                if (runtime < TimeSpan.FromSeconds(1))
                {
                    return null;
                }
                return new object();
            }, timeout: TimeSpan.FromSeconds(2), throwOnTimeout: true);
            Assert.That(DateTime.UtcNow - start, Is.GreaterThanOrEqualTo(TimeSpan.FromSeconds(1)));
            Assert.That(retValue, Is.Not.Null);
        }

        [Test]
        public void RetryWhileNullFails()
        {
            var start = DateTime.UtcNow;
            var retValue = Retry.WhileNull(() =>
            {
                var runtime = DateTime.UtcNow - start;
                if (runtime < TimeSpan.FromSeconds(4))
                {
                    return null;
                }
                return new object();
            }, timeout: TimeSpan.FromSeconds(1), throwOnTimeout: false);
            Assert.That(DateTime.UtcNow - start, Is.GreaterThanOrEqualTo(TimeSpan.FromSeconds(1)));
            Assert.That(retValue, Is.Null);
        }

        [Test]
        public void RetryWhileEmpty()
        {
            var start = DateTime.UtcNow;
            var retValue = Retry.WhileEmpty(() =>
            {
                var runtime = DateTime.UtcNow - start;
                if (runtime < TimeSpan.FromSeconds(1))
                {
                    return null;
                }
                return new List<int>() { 1, 2 };
            }, timeout: TimeSpan.FromSeconds(2), throwOnTimeout: true);
            Assert.That(DateTime.UtcNow - start, Is.GreaterThanOrEqualTo(TimeSpan.FromSeconds(1)));
            Assert.That(retValue, Has.Count.EqualTo(2));
        }

        [Test]
        public void RetryWhileEmptyFails()
        {
            var start = DateTime.UtcNow;
            var retValue = Retry.WhileEmpty(() =>
            {
                var runtime = DateTime.UtcNow - start;
                if (runtime < TimeSpan.FromSeconds(4))
                {
                    return null;
                }
                return new List<int>() { 1, 2 };
            }, timeout: TimeSpan.FromSeconds(1), throwOnTimeout: false);
            Assert.That(DateTime.UtcNow - start, Is.GreaterThanOrEqualTo(TimeSpan.FromSeconds(1)));
            Assert.That(retValue, Is.Null);
        }
    }
}
