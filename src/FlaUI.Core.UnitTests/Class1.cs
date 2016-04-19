using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlaUI.Core.UnitTests
{
    [TestFixture]
    public class Class1
    {
        [Test]
        public void Test()
        {
            var app = Application.Launch(@"C:\Windows\System32\calc.exe");
            var window = app.GetWindow("");
            Console.WriteLine(window.Title);
            app.Close();
        }
    }
}
