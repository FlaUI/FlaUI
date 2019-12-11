using FlaUI.Core.Definitions;
using FlaUI.Core.Tools;
using FlaUI.Core.UITests.TestFramework;
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
                Assert.That(window, Is.Not.Null);
                Assert.That(window.Title, Is.Not.Null);
                var file = window.FindFirstByXPath($"/MenuBar/MenuItem[@Name='{GetFileMenuText()}']");
                Assert.That(file, Is.Not.Null);
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
                Assert.That(window, Is.Not.Null);
                Assert.That(window.Title, Is.Not.Null);
                var items = window.FindAllByXPath("//MenuItem");
                Assert.That(items, Is.Not.Null);
                Assert.That(items, Has.Length.EqualTo(6));
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
                Assert.That(elem.Length, Is.EqualTo(1));
                Assert.That(elem[0].ControlType, Is.EqualTo(ControlType.Document));
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
                Assert.That(window, Is.Not.Null);
                Assert.That(window.Title, Is.Not.Null);
                var items = window.FindAllByXPath("(//MenuBar)[1]/MenuItem");
                Assert.That(items, Is.Not.Null);
                Assert.That(items, Has.Length.EqualTo(1));
                items = window.FindAllByXPath("(//MenuBar)[2]/MenuItem");
                Assert.That(items, Is.Not.Null);
                Assert.That(items, Has.Length.EqualTo(5));
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

                Assert.That(button, Is.Not.Null);
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
                Assert.That(unknown, Is.Not.Null);
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
