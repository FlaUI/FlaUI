using System;
using System.Windows.Automation.Peers;
using System.Windows.Controls;
using FlaUI.Custom;

namespace WpfApplication.Controls
{
    public class CustomLabel : Label
    {
        protected override AutomationPeer OnCreateAutomationPeer()
        {
            return new CustomLabelAutomationPeer(this);
        }

        private class CustomLabelAutomationPeer : LabelAutomationPeer, IStandalonePropertyProvider
        {
            public CustomLabelAutomationPeer(Label owner) : base(owner)
            {
            }

            public object GetPropertyValue(CustomProperty property)
            {
                if (property.Guid == CustomProperties.ForegroundProperty.Guid)
                {
                    return ((Label)Owner).Foreground.ToString();
                }
                if (property.Guid == CustomProperties.BackgroundProperty.Guid)
                {
                    return ((Label)Owner).Background.ToString();
                }

                return null;
            }
        }
    }
}
