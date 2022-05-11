using FlaUI.Core.Definitions;
using FlaUI.Core.Tools;
using FlaUI.Core.UITests.TestFramework;
using FluentAssertions;
using NUnit.Framework;

namespace FlaUI.Core.UITests
{
    [TestFixture]
    public class XPathTests
    {
        [Test]
        public void NotepadFindFirst()
        {
            using (var automation = UtilityMethods.GetAutomation(AutomationType.UIA3))
            {
                var app = Application.Launch("notepad.exe");
                var window = app.GetMainWindow(automation);
                window.Should().NotBeNull();
                window.Title.Should().NotBeNull();
                var file = window.FindFirstByXPath($"/MenuBar/MenuItem[@Name='{GetFileMenuText()}']");
                file.Should().NotBeNull();
                app.Close();
            }
        }

        [Test]
        public void NotePadFindAll()
        {
            using (var automation = UtilityMethods.GetAutomation(AutomationType.UIA3))
            {
                var app = Application.Launch("notepad.exe");
                var window = app.GetMainWindow(automation);
                window.Should().NotBeNull();
                window.Title.Should().NotBeNull();
                var items = window.FindAllByXPath("//MenuItem");
                items.Should().NotBeNull();
                items.Should().HaveCount(6);
                app.Close();
            }
        }

        [Test]
        public void NotepadFindByAutomationId()
        {
            using (var automation = UtilityMethods.GetAutomation(AutomationType.UIA3))
            {
                var app = Application.Launch("notepad.exe");
                var window = app.GetMainWindow(automation);
                var elem = window.FindAllByXPath("//*[@AutomationId=15]");
                elem.Should().HaveCount(1);
                elem[0].ControlType.Should().Be(ControlType.Document);
                app.Close();
            }
        }

        [Test]
        public void NotePadFindAllIndexed()
        {
            using (var automation = UtilityMethods.GetAutomation(AutomationType.UIA3))
            {
                var app = Application.Launch("notepad.exe");
                var window = app.GetMainWindow(automation);
                window.Should().NotBeNull();
                window.Title.Should().NotBeNull();
                var items = window.FindAllByXPath("(//MenuBar)[1]/MenuItem");
                items.Should().NotBeNull();
                items.Should().HaveCount(1);
                items = window.FindAllByXPath("(//MenuBar)[2]/MenuItem");
                items.Should().NotBeNull();
                items.Should().HaveCount(5);
                app.Close();
            }
        }

        [Test]
        public void PaintFindElementBelowUnknown()
        {
            using (var automation = UtilityMethods.GetAutomation(AutomationType.UIA3))
            {
                var app = Application.Launch("mspaint.exe");
                var window = app.GetMainWindow(automation);
                var button = window.FindFirstByXPath($"//Button[@Name='{GetPaintBrushName()}']");
                button.Should().NotBeNull();
                app.Close();
            }
        }

        [Test]
        public void PaintReferenceElementWithUnknownType()
        {
            using (var automation = UtilityMethods.GetAutomation(AutomationType.UIA3))
            {
                var app = Application.Launch("mspaint.exe");
                var window = app.GetMainWindow(automation);
                var unknown = window.FindFirstByXPath("//Custom");
                unknown.Should().NotBeNull();
                app.Close();
            }
        }

        private string GetFileMenuText()
        {
            switch (OperatingSystem.CurrentCulture.TwoLetterISOLanguageName)
            {
                case "de":
                    return "Datei";
                default:
                    return "File";
            }
        }

        private string GetPaintBrushName()
        {
            switch (OperatingSystem.CurrentCulture.TwoLetterISOLanguageName)
            {
                case "de":
                    return "Pinsel";
                default:
                    return "Brushes";
            }
        }
    }
}
