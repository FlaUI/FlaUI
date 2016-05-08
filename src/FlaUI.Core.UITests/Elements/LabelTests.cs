using System.IO;
using FlaUI.Core.Conditions;
using FlaUI.Core.Definitions;
using NUnit.Framework;

namespace FlaUI.Core.UITests.Elements
{
    [TestFixture]
    public class LabelTests
    {
        private Application _application;

        [SetUp]
        public void Setup()
        {
            _application = Application.Launch(Path.Combine(TestContext.CurrentContext.TestDirectory, @"..\..\..\TestApplications\WpfApplication\bin\debug\WpfApplication.exe"));
        }

        [Test]
        public void GetText()
        {
            
            var window = _application.GetMainWindow();
            var label = window.FindFirst(TreeScope.Descendants, ConditionFactory.ByText("Test Label")).AsLabel();

            Assert.That(label.Text(), Is.EqualTo("Test Label"));
            _application.Close();
        }
    }
}
