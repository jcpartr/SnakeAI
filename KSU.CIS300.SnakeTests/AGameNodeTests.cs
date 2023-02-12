using System;
using NUnit.Framework;
using KSU.CIS300.Snake;

namespace KSU.CIS300.SnakeTests
{
    public class AGameNodeTests
    {
        

        [Test]
        [Category("B-Constructor")]
        public void TestBA1GameNodeConstruct()
        {
            GameNode gn = new GameNode(1, 2);
            Assert.AreEqual(1, gn.X);
            Assert.AreEqual(2, gn.Y);
            Assert.AreEqual(GridData.Empty, gn.Data);
            Assert.AreEqual(null, gn.SnakeEdge);
        }
    }
}
