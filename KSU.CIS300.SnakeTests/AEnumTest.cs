using System;
using NUnit.Framework;
using KSU.CIS300.Snake;

namespace KSU.CIS300.SnakeTests
{
    class AEnumTest
    {
        [Test]
        [Category("A-Enum")]
        public void TestA1GridDataEnum()
        {
            try
            {
                GridData temp;
                temp = GridData.Empty;
                temp = GridData.Empty;
                temp = GridData.Empty;
                temp = GridData.Empty;
            }
            catch (Exception e)
            {
                Assert.Fail("Enum does not contain all values");
            }
        }

        [Test]
        [Category("A-Enum")]
        public void TestBA1SnakeStatusEnum()
        {
            try
            {
                SnakeStatus temp;
                temp = SnakeStatus.Moving;
                temp = SnakeStatus.InvalidDirection;
                temp = SnakeStatus.Eating;
                temp = SnakeStatus.Collision;
            }
            catch (Exception e)
            {
                Assert.Fail("Enum does not contain all values");
            }
        }

        [Test]
        [Category("A-Enum")]
        public void TestCA2Game_DirectionEnum()
        {
            try
            {
                Direction temp;
                temp = Direction.Up;
                temp = Direction.Down;
                temp = Direction.Left;
                temp = Direction.Right;
            }
            catch (Exception e)
            {
                Assert.Fail("Enum does not contain all values");
            }
        }
    }
}
