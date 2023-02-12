using KSU.CIS300.Snake;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace KSU.CIS300.SnakeTests
{
    public class BGameBoardTests
    {
        private const int longestMaxTimeout = 1000;
        private const int shortestMaxTimeout = 1000;

        public GameBoard SetBoard(int boardSize)
        {
            GameBoard gb = new GameBoard(boardSize);
            return gb;
        }

        #region test for the GameBoard constructor
        [TestCase(10)]
        [Category("B-Constructor")]
        public void TestBB1GameBoard_ConstructBase(int boardSize)
        {
            GameBoard gb = SetBoard(boardSize);
            Assert.AreEqual(boardSize, gb.Grid.GetLength(0));
            Assert.AreEqual(boardSize, gb.Grid.GetLength(1));
            int count = 0;

            for (int x = 0; x < boardSize; x++)
            {
                for (int y = 0; y < boardSize; y++)
                {
                    Assert.AreEqual(x, gb.Grid[x, y].X);
                    Assert.AreEqual(y, gb.Grid[x, y].Y);
                    if (GridData.Empty == gb.Grid[x, y].Data)
                    {
                        count++;
                    }
                }
            }
            Assert.AreEqual(true, count >= boardSize * boardSize - 2, "Board should be empty except one food and the snake head");
        }

        [TestCase(10)]
        [Category("B-Constructor")]
        public void TestBB2GameBoard_ConstructHeadsNTails(int boardSize)
        {
            GameBoard gb = SetBoard(boardSize);
            Assert.AreEqual(GridData.SnakeHead, gb.Grid[5, 5].Data);
            Assert.AreSame(gb.Grid[5, 5], gb.Head);
            Assert.AreSame(gb.Grid[5, 5], gb.Tail);
        }

        [TestCase(10)]
        [Category("B-Constructor")]
        [Category("C-Food")]
        public void TestBC3GameBoard_ConstructFood(int boardSize)
        {
            GameBoard gb = SetBoard(boardSize);
            int food = 0;
            for (int x = 0; x < boardSize; x++)
            {
                for (int y = 0; y < boardSize; y++)
                {
                    if (gb.Grid[x, y].Data == GridData.SnakeFood)
                    {
                        food++;
                    }
                }
            }
            Assert.AreEqual(1, food, "Board should have only one piece of food");
        }

        #endregion

        [TestCase(10)]
        [Category("C-Food")]
        public void TestBC1GameBoard_AddFood(int boardSize)
        {
            GameBoard gb = SetBoard(boardSize);
            for (int i = 0; i < 90; i++)
            {
                gb.AddFood();
            }
            int food = 0;
            for (int x = 0; x < boardSize; x++)
            {
                for (int y = 0; y < boardSize; y++)
                {
                    if (gb.Grid[x, y].Data == GridData.SnakeFood)
                    {
                        food++;
                    }
                }
            }
            Assert.AreEqual(91, food);
        }

        #region tests for the GetNextNode method

        [TestCase(10)]
        [Category("D-GetNextNode")]
        public void TestBD1GameBoard_GetNextNodeDown(int boardSize)
        {
            GameBoard gb = SetBoard(boardSize);
            gb.Head = gb.Grid[0, 8];
            GameNode next = gb.GetNextNode(Direction.Down, gb.Head);
            Assert.AreEqual(gb.Grid[0, 9], next);
        }

        [TestCase(10)]
        [Category("D-GetNextNode")]
        public void TestBD2GameBoard_GetNextNodeUp(int boardSize)
        {
            GameBoard gb = SetBoard(boardSize);
            gb.Head = gb.Grid[0, 1];
            GameNode next = gb.GetNextNode(Direction.Up, gb.Head);
            Assert.AreEqual(gb.Grid[0, 0], next);
        }
        [TestCase(10)]
        [Category("D-GetNextNode")]
        public void TestBD3GameBoard_GetNextNodeRight(int boardSize)
        {
            GameBoard gb = SetBoard(boardSize);
            gb.Head = gb.Grid[8, 1];
            GameNode next = gb.GetNextNode(Direction.Right, gb.Head);
            Assert.AreEqual(gb.Grid[9, 1], next);
        }
        [TestCase(10)]
        [Category("D-GetNextNode")]
        public void TestBD4GameBoard_GetNextNodeLeft(int boardSize)
        {
            GameBoard gb = SetBoard(boardSize);
            gb.Head = gb.Grid[1, 0];
            GameNode next = gb.GetNextNode(Direction.Left, gb.Head);
            Assert.AreEqual(gb.Grid[0, 0], next);
        }


        [TestCase(10)]
        [Category("D-GetNextNode")]
        public void TestBD5GameBoard_GetNextNodeFailDown(int boardSize)
        {
            GameBoard gb = SetBoard(boardSize);
            gb.Head = gb.Grid[0, 9];
            GameNode next = gb.GetNextNode(Direction.Down, gb.Head);
            Assert.AreEqual(null, next);
        }
        [TestCase(10)]
        [Category("D-GetNextNode")]
        public void TestBD6GameBoard_GetNextNodeFailUp(int boardSize)
        {
            GameBoard gb = SetBoard(boardSize);
            gb.Head = gb.Grid[0, 0];
            GameNode next = gb.GetNextNode(Direction.Up, gb.Head);
            Assert.AreEqual(null, next);
        }
        [TestCase(10)]
        [Category("D-GetNextNode")]
        public void TestBD7GameBoard_GetNextNodeFailRight(int boardSize)
        {
            GameBoard gb = SetBoard(boardSize);
            gb.Head = gb.Grid[9, 1];
            GameNode next = gb.GetNextNode(Direction.Right, gb.Head);
            Assert.AreEqual(null, next);
        }
        [TestCase(10)]
        [Category("D-GetNextNode")]
        public void TestBD8GameBoard_GetNextNodeFailLeft(int boardSize)
        {
            GameBoard gb = SetBoard(boardSize);
            gb.Head = gb.Grid[0, 0];
            GameNode next = gb.GetNextNode(Direction.Left, gb.Head);
            Assert.AreEqual(null, next);
        }

        #endregion


        #region Tests for getting the path of the snake
        [TestCase(10)]
        [Category("E-GetSnakePath")]
        public void TestBE1GameBoard_Base(int boardSize)
        {
            GameBoard gb = SetBoard(boardSize);
            VerifyPathLength(1,gb);
        }

        [TestCase(10)]
        [Category("E-GetSnakePath")]
        public void TestBE2GameBoard_Simple(int boardSize)
        {
            GameBoard gb = SetBoard(boardSize);
            gb.Grid[5, 5].Data = GridData.SnakeBody;
            gb.Grid[5, 5].SnakeEdge = gb.Grid[5, 6];
            gb.Grid[5, 6].Data = GridData.SnakeHead;
            gb.Tail = gb.Grid[5, 5];
            gb.Head = gb.Grid[5, 6];
            VerifyPathLength(2,gb);
        }

        [TestCase(10)]
        [Category("E-GetSnakePath")]
        public void TestBE2GameBoard_Long(int boardSize)
        {
            GameBoard gb = SetBoard(boardSize);
            for (int i = 5; i >= 1; i--)
            {
                gb.Grid[i, 5].Data = GridData.SnakeBody;
                gb.Grid[i, 5].SnakeEdge = gb.Grid[i-1, 5];
            }
            gb.Grid[0, 5].Data = GridData.SnakeBody;
            gb.Grid[0, 5].SnakeEdge = gb.Grid[0, 4];

            gb.Grid[0, 4].Data = GridData.SnakeBody;
            gb.Grid[0, 4].SnakeEdge = gb.Grid[1, 4];

            gb.Grid[1, 4].Data = GridData.SnakeBody;
            gb.Grid[1, 4].SnakeEdge = gb.Grid[2, 4];

            gb.Grid[2, 4].Data = GridData.SnakeHead;            
            gb.Head = gb.Grid[2, 4];
            gb.Tail = gb.Grid[5, 5];
            VerifyPathLength(9,gb);
        }
        #endregion

        #region Test basic snake movements
        [TestCase(10)]
        [Category("F-MoveSnake")]
        public void TestBF1GameBoard_MoveSnakeWallCollision(int boardSize)
        {
            GameBoard gb = SetBoard(boardSize);
            ResetFood(0, 0, gb);

            gb.Head = gb.Grid[0, 0];
            SnakeStatus s = gb.MoveSnake(Direction.Up);
            Assert.AreEqual(SnakeStatus.Collision, s);
        }

        [TestCase(10)]
        [Category("F-MoveSnake")]
        public void TestBF2GameBoard_MoveSnakeNoCut(int boardSize)
        {
            GameBoard gb = SetBoard(boardSize);
            ResetFood(0, 0, gb);
            Assert.AreEqual(SnakeStatus.Moving, gb.MoveSnake(Direction.Right));
            Assert.AreEqual(gb.Head, gb.Grid[boardSize / 2 + 1, boardSize / 2]);
            Assert.AreNotEqual(gb.Head, gb.Tail);
            VerifyPathLength(2, gb);
        }

        [TestCase(10)]
        [Category("F-MoveSnake")]
        public void TestBF3GameBoard_MoveSnakeCutTail(int boardSize)
        {
            GameBoard gb = SetBoard(boardSize);
            ResetFood(0, 0, gb);
            Assert.AreEqual(SnakeStatus.Moving, gb.MoveSnake(Direction.Right));
            Assert.AreEqual(SnakeStatus.Moving, gb.MoveSnake(Direction.Up));
            Assert.AreNotEqual(gb.Head, gb.Tail);
            VerifyPathLength(2,gb);
        }

        [TestCase(10)]
        [Category("F-MoveSnake")]
        public void TestBF4GameBoard_MoveSnakeInvalid(int boardSize)
        {
            GameBoard gb = SetBoard(boardSize);
            ResetFood(0, 0, gb);
            Assert.AreEqual(SnakeStatus.Moving, gb.MoveSnake(Direction.Right));
            Assert.AreEqual(SnakeStatus.Moving, gb.MoveSnake(Direction.Right));
            Assert.AreEqual(SnakeStatus.InvalidDirection, gb.MoveSnake(Direction.Left));
            VerifyPathLength(2,gb);
        }

        [TestCase(10)]
        [Category("F-MoveSnake")]
        public void TestBF5GameBoard_MoveSnakeEatFood(int boardSize)
        {
            GameBoard gb = SetBoard(boardSize);
            Assert.AreEqual(SnakeStatus.Moving, gb.MoveSnake(Direction.Left));
            Assert.AreEqual(SnakeStatus.Moving, gb.MoveSnake(Direction.Up));
            ResetFood(4, 3, gb);
            Assert.AreEqual(SnakeStatus.Eating, gb.MoveSnake(Direction.Up));
            Assert.AreEqual(GridData.SnakeFood, gb.Food.Data);
            Assert.AreNotSame(gb.Grid[4, 3], gb.Food);
            VerifyPathLength(3,gb);
        }

        [TestCase(10)]
        [Category("F-MoveSnake")]
        public void TestBF6GameBoard_MoveSnakeBodyCollision(int boardSize)
        {
            GameBoard gb = SetBoard(boardSize);
            ResetFood(4,5, gb);

            Assert.AreEqual(SnakeStatus.Eating, gb.MoveSnake(Direction.Left));

            gb.Grid[3, 5].Data = GridData.SnakeFood;
            gb.Food = gb.Grid[3, 5];
            Assert.AreEqual(SnakeStatus.Eating, gb.MoveSnake(Direction.Left));

            gb.Grid[3, 6].Data = GridData.SnakeFood;
            gb.Food = gb.Grid[3, 6];
            Assert.AreEqual(SnakeStatus.Eating, gb.MoveSnake(Direction.Down));

            gb.Grid[3, 7].Data = GridData.SnakeFood;
            gb.Food = gb.Grid[3, 7];
            Assert.AreEqual(SnakeStatus.Eating, gb.MoveSnake(Direction.Down));

            gb.Grid[4, 7].Data = GridData.SnakeFood;
            gb.Food = gb.Grid[4, 7];
            Assert.AreEqual(SnakeStatus.Eating, gb.MoveSnake(Direction.Right));

            gb.Grid[4, 6].Data = GridData.SnakeFood;
            gb.Food = gb.Grid[4, 6];
            Assert.AreEqual(SnakeStatus.Eating, gb.MoveSnake(Direction.Up));
            Assert.AreEqual(SnakeStatus.Collision, gb.MoveSnake(Direction.Left));
            VerifyPathLength(7,gb);
        }

        #endregion

        #region Tests for finding the path for the AI
        [TestCase(4), TestCase(6), TestCase(8),
            TestCase(10), TestCase(12), TestCase(16), TestCase(26)]
        [Timeout(longestMaxTimeout)]
        [Category("H-AIPath")]
        public void TestBH1GameBoard_LongestAIpath(int boardSize)
        {
            GameBoard gb = SetBoard(boardSize);
            ResetFood(0, 0, gb);
            gb.MoveSnake(Direction.Up);

            Queue<Direction> path = gb.FindLongestAiPath();
            Assert.IsNotNull(path);
            Assert.AreEqual(gb.Grid.Length, path.Count);

            VerifyPath(gb.Head, new List<Direction>(path.ToArray()), gb);
        }

        [TestCase(3), TestCase(4), TestCase(5), TestCase(7), 
            TestCase(10), TestCase(20), TestCase(30)]
        [Timeout(shortestMaxTimeout)]
        [Category("H-AIPath")]
        public void TestBH3GameBoard_ShortestAIpath(int boardSize)
        {
            GameBoard gb = SetBoard(boardSize);
            ResetFood(0, 0, gb);
            gb.MoveSnake(Direction.Up);


            List<Direction> path = gb.FindShortestAiPath(gb.Food);
            Assert.IsNotNull(path);

            Assert.IsTrue(path.Count >= 1);
            VerifyPath(gb.Food, path, gb);
        }

        [TestCase(3), TestCase(4), TestCase(5), TestCase(7),
            TestCase(10), TestCase(20), TestCase(30)]
        [Timeout(shortestMaxTimeout)]
        [Category("H-AIPath")]
        public void TestBH4GameBoard_ShortestAIpath_Snake2(int boardSize)
        {
            GameBoard gb = SetBoard(boardSize);
            ResetFood(0, 0, gb);
            gb.MoveSnake(Direction.Up);

            List<Direction> path = gb.FindShortestAiPath(gb.Food);
            Assert.IsNotNull(path);

            Assert.IsTrue(path.Count >= 1);
            VerifyPath(gb.Food, path, gb);
        }
        #endregion

        /// <summary>
        /// Verifies that the given path leads to the destination from the snake's head
        /// </summary>
        /// <param name="destination"></param>
        /// <param name="path"></param>
        /// <param name="gb"></param>
        private void VerifyPath(GameNode destination, List<Direction> path, GameBoard gb)
        {
            bool[,] visited = new bool[gb.Grid.GetLength(0), gb.Grid.GetLength(0)];
            foreach(Direction dir in path)
            {                
                gb.MoveSnake(dir);
                Assert.IsFalse(visited[gb.Head.X, gb.Head.Y]);
                visited[gb.Head.X, gb.Head.Y] = true;
            }
            Assert.AreEqual(destination, gb.Head);
        }

        /// <summary>
        /// Verifies that the snake is of the specified length
        /// </summary>
        /// <param name="length"></param>
        /// <param name="gb"></param>
        private void VerifyPathLength(int length, GameBoard gb)
        {
            int x = gb.Tail.X;
            int y = gb.Tail.Y;
            List<GameNode> path = gb.GetSnakePath();

            Assert.AreEqual(length, path.Count);
            Assert.AreEqual(x, path[0].X);
            Assert.AreEqual(y, path[0].Y);
            for (int i = 1; i < path.Count; i++)
            {
                GameNode node = path[i];
                Assert.IsFalse(x == node.X && y == node.Y);
                Assert.IsFalse(Math.Abs(x - node.X) > 1);
                Assert.IsFalse(Math.Abs(y - node.Y) > 1);
                x = node.X;
                y = node.Y;
            }
            Assert.AreSame(gb.Tail, path[0]);
            Assert.AreSame(gb.Head, path[path.Count - 1]);
        }

        /// <summary>
        /// forces the food to the given location
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="gb"></param>
        private void ResetFood(int x, int y, GameBoard gb)
        {
            gb.Food.Data = GridData.Empty;
            gb.Food = gb.Grid[x, y];
            gb.Food.Data = GridData.SnakeFood;
        }

    }
}
