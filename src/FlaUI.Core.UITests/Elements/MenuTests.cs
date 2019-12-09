using FlaUI.Core.AutomationElements;
using FlaUI.Core.UITests.TestFramework;
using NUnit.Framework;

namespace FlaUI.Core.UITests.Elements
{
    [TestFixture(AutomationType.UIA2, TestApplicationType.WinForms)]
    [TestFixture(AutomationType.UIA2, TestApplicationType.Wpf)]
    [TestFixture(AutomationType.UIA3, TestApplicationType.WinForms)]
    [TestFixture(AutomationType.UIA3, TestApplicationType.Wpf)]
    public class MenuTests : UITestBase
    {
        public MenuTests(AutomationType automationType, TestApplicationType appType)
            : base(automationType, appType)
        {
        }

        [Test]
        public void TestMenuWithSubMenus()
        {
            var window = App.GetMainWindow(Automation);
            var menu = window.FindFirstChild(cf => cf.Menu()).AsMenu();
            Assert.That(menu, Is.Not.Null);
            var items = menu.Items;
            Assert.That(items, Has.Length.EqualTo(2));
            Assert.That(items[0].Properties.Name, Is.EqualTo("File"));
            Assert.That(items[1].Properties.Name, Is.EqualTo("Edit"));
            var subitems1 = items[0].Items;
            Assert.That(subitems1, Has.Length.EqualTo(1));
            Assert.That(subitems1[0].Properties.Name, Is.EqualTo("Exit"));
            var subitems2 = items[1].Items;
            if (ApplicationType == TestApplicationType.WinForms)
            {
                // WinForms test application remained unchanged, 
                // "Edit" menu has 2 menu items: "Copy" and "Paste"
                Assert.That(subitems2, Has.Length.EqualTo(2));
            }
            else
            {
                // On WPF test application has been added a new menu item "Show Label"
                // under "Edit" menu, so now "Edit" menu has 3 menu items
                Assert.That(subitems2, Has.Length.EqualTo(3));
            }
            Assert.That(subitems2[0].Properties.Name, Is.EqualTo("Copy"));
            Assert.That(subitems2[1].Properties.Name, Is.EqualTo("Paste"));
            if (ApplicationType != TestApplicationType.WinForms)
            {
                Assert.That(subitems2[2].Properties.Name, Is.EqualTo("Show Label"));
            }
            var subsubitems1 = subitems2[0].Items;
            Assert.That(subsubitems1, Has.Length.EqualTo(2));
            Assert.That(subsubitems1[0].Properties.Name, Is.EqualTo("Plain"));
            Assert.That(subsubitems1[1].Properties.Name, Is.EqualTo("Fancy"));
        }

        [Test]
        public void TestMenuWithSubMenusByName()
        {
            var window = App.GetMainWindow(Automation);
            var menu = window.FindFirstChild(cf => cf.Menu()).AsMenu();
            var edit = menu.Items["Edit"];
            Assert.That(edit, Is.Not.Null);
            Assert.That(edit.Properties.Name.Value, Is.EqualTo("Edit"));
            var copy = edit.Items["Copy"];
            Assert.That(copy, Is.Not.Null);
            Assert.That(copy.Properties.Name.Value, Is.EqualTo("Copy"));
            var fancy = copy.Items["Fancy"];
            Assert.That(fancy, Is.Not.Null);
            Assert.That(fancy.Properties.Name.Value, Is.EqualTo("Fancy"));
        }
        
        [Test]
        public void TestCheckedMenuItem()
        {
            if (ApplicationType == TestApplicationType.WinForms)
            {
                Assert.Ignore("UI Automation currently does not support Toggle pattern on menu items in WinForms applications.");
                return;
            }
            var window = App.GetMainWindow(Automation);
            var menu = window.FindFirstChild(cf => cf.Menu()).AsMenu();
            var edit = menu.Items["Edit"];
            Assert.That(edit, Is.Not.Null);
            var showLabel = edit.Items["Show Label"];
            Assert.That(showLabel, Is.Not.Null);
            Assert.That(showLabel.IsChecked, Is.EqualTo(true));
            showLabel.IsChecked = false;
            Assert.That(showLabel.IsChecked, Is.EqualTo(false));
            showLabel.IsChecked = true;
            Assert.That(showLabel.IsChecked, Is.EqualTo(true));
        }
    }
}
