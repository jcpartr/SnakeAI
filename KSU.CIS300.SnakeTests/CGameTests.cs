using System;
using NUnit.Framework;
using KSU.CIS300.Snake;

namespace KSU.CIS300.SnakeTests
{
    public class CGameTests
    {
        Game g;
        
        [SetUp]
        public void Setup()
        {
            g = new Game(10, 150, false);
        }

        [Test]
        [Category("B-Constructor")]
        public void TestCB4Game_Construct()
        {
            Assert.AreEqual(10, g.Size);
            Assert.AreEqual(true, g.Play);
            Assert.AreEqual(2, g.Score);
            Assert.AreEqual(100, g.Board.Grid.Length);
        }


        [Test]
        [Category("G-BasicGameMethods")]
        public void TestCG1Game_GetSnakePath()
        {
            Assert.AreEqual(2, g.GetSnakePath().Count);
        }

        [Test]
        [Category("G-BasicGameMethods")]
        public void TestCG2Game_GetFood()
        {
            Assert.AreSame(g.Board.Food, g.GetFood());
        }

        [Test]
        [Category("G-BasicGameMethods")]
        public void TestCG3Game_MoveUp()
        {
            g.MoveUp();
            Assert.AreEqual(Direction.Up, g.KeyPress);
        }

        [Test]
        [Category("G-BasicGameMethods")]
        public void TestCG4Game_MoveDown()
        {
            g.MoveDown();
            Assert.AreEqual(Direction.Down, g.KeyPress);
        }

        [Test]
        [Category("G-BasicGameMethods")]
        public void TestCG5Game_MoveLeft()
        {
            g.MoveLeft();
            Assert.AreEqual(Direction.Left, g.KeyPress);
        }

        [Test]
        [Category("G-BasicGameMethods")]
        public void TestCG6Game_MoveRight()
        {
            g.MoveRight();
            Assert.AreEqual(Direction.Right, g.KeyPress);
        }

    }
}
