using FlaUI.Core.Shapes;
using NUnit.Framework;

namespace FlaUI.Core.UnitTests
{
    [TestFixture]
    public class RectangleTests
    {
        [Test]
        public void CenterTest()
        {
            var rectangle = new Rectangle(10, 20, 30, 40);
            var center = rectangle.Center;
            Assert.That(center.X, Is.EqualTo(25));
            Assert.That(center.Y, Is.EqualTo(40));
        }
    }
}
