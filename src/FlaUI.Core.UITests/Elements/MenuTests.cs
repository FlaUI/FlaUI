using System;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.UITests.TestFramework;
using FluentAssertions;
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
            var window = Application.GetMainWindow(Automation);
            var menu = window.FindFirstChild(cf => cf.Menu()).AsMenu();
            menu.Should().NotBeNull();
            var items = menu.Items;
            items.Should().HaveCount(2);
            items[0].Properties.Name.Value.Should().Be("File");
            items[1].Properties.Name.Value.Should().Be("Edit");
            var subitems1 = items[0].Items;
            subitems1.Should().HaveCount(1);
            subitems1[0].Properties.Name.Value.Should().Be("Exit");
            var subitems2 = items[1].Items;
            if (ApplicationType == TestApplicationType.WinForms)
            {
                // WinForms test application remained unchanged, 
                // "Edit" menu has 2 menu items: "Copy" and "Paste"
                subitems2.Should().HaveCount(2);
            }
            else
            {
                // On WPF test application has been added a new menu item "Show Label"
                // under "Edit" menu, so now "Edit" menu has 3 menu items
                subitems2.Should().HaveCount(3);
            }
            subitems2[0].Properties.Name.Value.Should().Be("Copy");
            subitems2[1].Properties.Name.Value.Should().Be("Paste");
            if (ApplicationType != TestApplicationType.WinForms)
            {
                subitems2[2].Properties.Name.Value.Should().Be("Show Label");
            }
            var subsubitems1 = subitems2[0].Items;
            subsubitems1.Should().HaveCount(2);
            subsubitems1[0].Properties.Name.Value.Should().Be("Plain");
            subsubitems1[1].Properties.Name.Value.Should().Be("Fancy");
        }

        [Test]
        public void TestMenuWithSubMenusByName()
        {
            var window = Application.GetMainWindow(Automation);
            var menu = window.FindFirstChild(cf => cf.Menu()).AsMenu();
            var edit = menu.Items["Edit"];
            edit.Should().NotBeNull();
            edit.Properties.Name.Value.Should().Be("Edit");
            var copy = edit.Items["Copy"];
            copy.Should().NotBeNull();
            copy.Properties.Name.Value.Should().Be("Copy");
            var fancy = copy.Items["Fancy"];
            fancy.Should().NotBeNull();
            fancy.Properties.Name.Value.Should().Be("Fancy");
        }

        [Test]
        public void TestCheckedMenuItem()
        {
            if (ApplicationType == TestApplicationType.WinForms)
            {
                Assert.Ignore("UI Automation currently does not support Toggle pattern on menu items in WinForms applications.");
                return;
            }
            var window = Application.GetMainWindow(Automation);
            var menu = window.FindFirstChild(cf => cf.Menu()).AsMenu();
            var edit = menu.Items["Edit"];
            edit.Should().NotBeNull();
            var showLabel = edit.Items["Show Label"];
            showLabel.Should().NotBeNull();
            showLabel.IsChecked.Should().BeTrue();
            showLabel.IsChecked = false;
            showLabel.IsChecked.Should().Be(false);
            showLabel.IsChecked = true;
            showLabel.IsChecked.Should().Be(true);
        }
    }
}
