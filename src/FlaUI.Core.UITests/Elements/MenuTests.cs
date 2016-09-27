using FlaUI.Core.UITests.TestFramework;
using FlaUI.UIA3.Conditions;
using FlaUI.UIA3.Definitions;
using FlaUI.UIA3.Elements;
using FlaUI.UIA3.Tools;
using NUnit.Framework;

namespace FlaUI.Core.UITests.Elements
{
    [TestFixture(TestApplicationType.WinForms)]
    [TestFixture(TestApplicationType.Wpf)]
    public class MenuTests : UITestBase
    {
        public MenuTests(TestApplicationType appType)
            : base(appType)
        {
        }

        [Test]
        public void TestMenuWithSubMenus()
        {
            var window = App.GetMainWindow(Uia3Automation);
            var menu = window.FindFirst(TreeScope.Children, ConditionFactory.Menu()).AsMenu();
            Assert.That(menu, Is.Not.Null);
            var items = menu.MenuItems;
            Assert.That(items, Has.Length.EqualTo(2));
            Assert.That(items[0].Current.Name, Is.EqualTo("File"));
            Assert.That(items[1].Current.Name, Is.EqualTo("Edit"));
            var subitems1 = items[0].SubMenuItems;
            Assert.That(subitems1, Has.Length.EqualTo(1));
            Assert.That(subitems1[0].Current.Name, Is.EqualTo("Exit"));
            var subitems2 = items[1].SubMenuItems;
            Assert.That(subitems2, Has.Length.EqualTo(2));
            Assert.That(subitems2[0].Current.Name, Is.EqualTo("Copy"));
            Assert.That(subitems2[1].Current.Name, Is.EqualTo("Paste"));
            var subsubitems1 = subitems2[0].SubMenuItems;
            Assert.That(subsubitems1, Has.Length.EqualTo(2));
            Assert.That(subsubitems1[0].Current.Name, Is.EqualTo("Plain"));
            Assert.That(subsubitems1[1].Current.Name, Is.EqualTo("Fancy"));
        }
    }
}
