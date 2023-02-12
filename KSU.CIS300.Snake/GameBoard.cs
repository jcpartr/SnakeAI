/* GameBoard.cs
 * Author: Johnathan Partridge
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace KSU.CIS300.Snake
{
    //Enumerators
    /// <summary>
    /// Enumerator for Snake Directions
    /// </summary>
    public enum Direction
    {
        Up,
        Down,
        Left,
        Right,
        None
    }
    /// <summary>
    /// Enumerator to show the Snake's status
    /// </summary>
    public enum SnakeStatus
    {
        Moving,
        InvalidDirection,
        Eating,
        Collision,
        Win
    }

    public class GameBoard
    {

        //Properties
        /// <summary>
        /// Returns the gamenode that contains food
        /// </summary>
        public GameNode Food { get; set; }

        /// <summary>
        /// Array for storing nodes of the gameboard
        /// </summary>
        public GameNode[,] Grid { get; private set; }

        /// <summary>
        /// Reference to the head of the snake
        /// </summary>
        public GameNode Head { get; set; }

        /// <summary>
        /// Reference to the tail of the snake
        /// </summary>
        public GameNode Tail { get; set; }
        /// <summary>
        /// Keeps track of how big the snake is
        /// </summary>
        public int SnakeSize { get; private set; }

        //Fields
        /// <summary>
        /// Dimension of the board.
        /// </summary>
        private int _size;

        /// <summary>
        /// Contains all four possible directions for the ai 
        /// </summary>
        private Direction[] _aiDirection;

        /// <summary>
        /// Contains all direction left and right (used for hamiltonian path)
        /// </summary>
        private Direction[] _leftRight;

        /// <summary>
        /// Contains all directions up and down (used for hamiltonian path)
        /// </summary>
        private Direction[] _upDown;

        /// <summary>
        /// New Random object used for adding food
        /// </summary>
        private static Random _random;
        
        /// <summary>
        /// Bool used to detect the first move for adding the tail at the beginning
        /// </summary>
        private bool firstMove;

        private GameNode _start;

        /// <summary>
        /// Constructor used for making a non ai game
        /// </summary>
        /// <param name="size"></param>
        public GameBoard(int size)
        {
            _size = size;
            Grid = new GameNode[_size, _size];
            _random = new Random();
            for (int i = 0; i < _size; i++)
            {
                for (int j = 0; j < _size; j++)
                {
                    Grid[i, j] = new GameNode(i, j);
                }
            }

            int center = _size / 2;

            _start = Grid[center, center]; 
            _start.Data = GridData.SnakeHead;

            Head = _start;
            Tail = _start;

            SnakeSize = 2;
            firstMove = true;

            AddFood();
        }
        
        /// <summary>
        /// Constructor used to make an ai game
        /// </summary>
        /// <param name="size">Height and Width of the GameBoard</param>
        public GameBoard(int size, bool isAI)
        {
            _size = size;
            Grid = new GameNode[_size, _size];
            _random = new Random();
            
            for (int i = 0; i < _size; i++)
            {
                for(int j = 0; j < _size; j++)
                {
                    Grid[i, j] = new GameNode(i, j);
                }
            }

            int center = _size / 2;

            _start = Grid[0, 0];
            _start.Data = GridData.SnakeHead;
            Head = _start;
            Tail = _start;

            SnakeSize = 2;
            firstMove = true;

            AddFood();
        }

       


        /// <summary>
        /// Sets a random empty node to have food;
        /// </summary>
        public void AddFood()
        {
            int yRand;
            int xRand;
            do
            {
                yRand = _random.Next(_size);
                xRand = _random.Next(_size);
            } while (Grid[xRand, yRand].Data != GridData.Empty);

            Grid[xRand, yRand].Data = GridData.SnakeFood;
            Food = Grid[xRand, yRand];
        }

        /// <summary>
        /// Gets the next node in the given direction, returns null if off board 
        /// </summary>
        /// <param name="dir">Direction</param>
        /// <param name="current">Current Node</param>
        /// <returns></returns>
        public GameNode GetNextNode(Direction dir, GameNode current)
        {
            if (dir == Direction.Down && (current.Y + 1) < _size) 
            {
                return Grid[current.X, current.Y + 1];
            } else if (dir == Direction.Up && (current.Y - 1) >= 0)
            {
                return Grid[current.X, current.Y - 1];
            } else if (dir == Direction.Right && (current.X + 1) < _size)
            {
                return Grid[current.X + 1, current.Y];
            } else if (dir == Direction.Left && (current.X - 1) >= 0)
            {
                return Grid[current.X - 1, current.Y];
            } else
            {
                return null;
            }
        }

        /// <summary>
        /// Main Logic for moving the snake accross the board;
        /// </summary>
        /// <param name="Dir">Direction the snake is heading</param>
        /// <returns></returns>
        public SnakeStatus MoveSnake(Direction dir)
        {
            //Gets the next GameNode in the given direction
            GameNode next = GetNextNode(dir, Head);

            //Invalid Direction and Collision Detection
            if (next == null)
            {
                return SnakeStatus.Collision;
            }
            if (next.SnakeEdge == Head)
            {
                return SnakeStatus.InvalidDirection;
            } 
            if (next.Data == GridData.SnakeBody)
            {
                return SnakeStatus.Collision;
            }

            bool isFood = false;
            if (next.Data == GridData.SnakeFood)
            {
                isFood = true;
            }

            next.Data = GridData.SnakeHead;
            Head.SnakeEdge = next;
            Head.Data = GridData.SnakeBody;
            Head = next;

            if (isFood)
            {
                SnakeSize++;
                if (SnakeSize == (_size * _size))
                {
                    return SnakeStatus.Win;
                } else
                {
                    AddFood();
                    return SnakeStatus.Eating;
                }
            }
            if (!firstMove)
            {
                GameNode newTail = Tail.SnakeEdge;
                Tail.SnakeEdge = null;
                Tail.Data = GridData.Empty;
                Tail = newTail;
            } else
            {
                firstMove = false;
            }
            return SnakeStatus.Moving;


        }

        /// <summary>
        /// Return all nodes of the snake 
        /// </summary>
        /// <returns></returns>
        public List<GameNode> GetSnakePath()
        {

            List<GameNode> path = new List<GameNode>();

            GameNode search = Tail;

            while (search != null)
            {
                path.Add(search);
                search = search.SnakeEdge;
            }
            //Adds head
            //path.Add(search);

            return path;

        }

        //AI Methods
        /// <summary>
        /// Generates a default hamiltonian path and then searches it for the head node
        /// </summary>
        /// <param name="path"></param>
        /// <param name="dest"></param>
        /// <returns>Hamiltonian path starting at the head</returns>
        public GameNodeLinkedList BuildPath() 
        {
           
            GameNodeLinkedList path = GenHamiltonianPath();
            return path;
            
            while (path.Node != Head)
            {
                path = path.Next;
            }
            return path;
            
        }
        /// <summary>
        /// Helper function for the AI, not used
        /// </summary>
        /// <param name="dest"></param>
        /// <returns></returns>
        public List<Direction> FindShortestAiPath (GameNode dest)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Helper function for the AI, not used
        /// </summary>
        /// <returns></returns>
        public Queue<Direction> FindLongestAiPath()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Generates a hamiltonian path as a looped linkedlist starting at 0,0 for any even by even square using an algorithm I made up
        /// </summary>
        /// <returns>Hamiltonian Path starting at 0,0</returns>        
        private GameNodeLinkedList GenHamiltonianPath ()
        {
            GameNodeLinkedList path = new GameNodeLinkedList(Grid[0, 0]);
            GameNodeLinkedList search = path;

            //Phase 1
            for (int y = 1; y <= _size - 1; y++)
            {
                search.Direction = Direction.Down;
                search.Next = new GameNodeLinkedList(Grid[0, y]);
                search = search.Next;
            }
            //Phase 2
            int x = 0;
            for (int i = 1; i <= (_size-2)/2; i++)
            {
                search.Direction = Direction.Right;
                x++;
                search.Next = new GameNodeLinkedList(Grid[x, _size - 1]);
                search = search.Next;
                for (int y = _size - 1; y > 1; y--)
                {
                    search.Direction = Direction.Up;
                    search.Next = new GameNodeLinkedList(Grid[x, y]);
                    search = search.Next;
                }
                search.Direction = Direction.Right;
                x++;
                search.Next = new GameNodeLinkedList(Grid[x, _size - 1]);
                search = search.Next;
                for (int y = 1; y < _size - 1; y++)
                {
                    search.Direction = Direction.Down;
                    search.Next = new GameNodeLinkedList(Grid[x, y]);
                    search = search.Next;
                }
            }
            
            //Phase 3;
            search.Direction = Direction.Right;
            x++;
            search.Next = new GameNodeLinkedList(Grid[x, _size - 1]);
            search = search.Next;

            for (int y = _size - 1; y > 0; y--)
            {
                search.Direction = Direction.Up;
                search.Next = new GameNodeLinkedList(Grid[x, y]);
                search = search.Next;
            }

            for (int i = x; i > 1; i--)
            {
                search.Direction = Direction.Left;
                search.Next = new GameNodeLinkedList(Grid[i, 0]);
                search = search.Next;
                
            }

            //Phase 4: Link End to Beginning
            search.Direction = Direction.Left;
            search.Next = path;

            return path;
        }
    }
}
