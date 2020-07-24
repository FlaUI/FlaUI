using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlaUI.Custom
{
    public interface IStandalonePropertyProvider
    {
        object GetPropertyValue(CustomProperty property);
    }
}
