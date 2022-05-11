﻿using System;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.UITests.WordPad.Screens;
using FlaUI.TestUtilities;
using FlaUI.UIA3;
using FluentAssertions;
using NUnit.Framework;

namespace FlaUI.Core.UITests.WordPad
{
    [TestFixture]
    public class WordPadTests : FlaUITestBase
    {
        protected override AutomationBase GetAutomation()
        {
            var automation = new UIA3Automation();
            // Increase some timeouts
            automation.ConnectionTimeout = TimeSpan.FromSeconds(automation.ConnectionTimeout.TotalSeconds * 2);
            automation.TransactionTimeout = TimeSpan.FromSeconds(automation.TransactionTimeout.TotalSeconds * 2);
            return automation;
        }

        protected override Application StartApplication()
        {
            var application = Application.Launch("wordpad.exe");
            application.WaitWhileMainHandleIsMissing();
            // Give the application some additional time to start
            System.Threading.Thread.Sleep(1000);
            return application;
        }

        [Test]
        public void ZoomTest()
        {
            var mainScreen = Application.GetMainWindow(Automation).As<MainScreen>();
            mainScreen.GetCurrentZoomPercent().Should().Be(100);
            mainScreen.ZoomIn();
            mainScreen.GetCurrentZoomPercent().Should().Be(110);
            mainScreen.ZoomOut();
            mainScreen.ZoomOut();
            mainScreen.GetCurrentZoomPercent().Should().Be(90);
        }

        [Test]
        public void InfoScreenTest()
        {
            var mainScreen = Application.GetMainWindow(Automation).As<MainScreen>();

            Action act = () =>
            {
              var infoScreen = mainScreen.OpenAndGetInfoScreen();
              infoScreen.OkButton.Invoke();
            };

            act.Should().NotThrow();
        }
    }
}
