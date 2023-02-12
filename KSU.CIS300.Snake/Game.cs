/* Game.cs
 * Author: Johnathan Partridge
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.ComponentModel;

namespace KSU.CIS300.Snake
{
    public class Game : INotifyPropertyChanged
    {

        //Fields
        /// <summary>
        /// Keeps track of how many points the player has
        /// </summary>
        private int _score;

        /// <summary>
        /// How fast the snake moves (tick delay)
        /// </summary>
        private int _delay;

        /// <summary>
        /// Indicates if the game is controlled by AI
        /// </summary>
        private bool _isAI;

        /// <summary>
        /// Stores the AI path if enabled
        /// </summary>
        private GameNodeLinkedList _aiPath;

        //Properties

        /// <summary>
        /// If the game is currently being played
        /// </summary>
        public bool Play;
        
        /// <summary>
        /// Score Property for the game
        /// </summary>
        public int Score
        {
            get { return _score; }
            set 
            { 
                if (value != _score)
                {
                    _score = value;
                    OnPropertyChanged("Score");
                }
            }
        }

        /// <summary>
        /// GameBoard Object
        /// </summary>
        public GameBoard Board;
        
        /// <summary>
        /// Size of the game to create
        /// </summary>
        public int Size { get; private set; }

        /// <summary>
        /// Last Direction that the snake succesfuully moved
        /// </summary>
        public Direction LastDirection { get; private set; }

        /// <summary>
        /// Direction Reported by the UI
        /// </summary>
        public Direction KeyPress { get; private set; }

        /// <summary>
        /// Current SnakeStatus
        /// </summary>
        public SnakeStatus Status { get; private set; }

        /// <summary>
        /// Used in implementing Interface
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        //Methods

        /// <summary>
        /// Initilaizes the Game
        /// </summary>
        /// <param name="size"></param>
        /// <param name="speed"></param>
        /// <param name="isAI"></param>
        public Game(int size, int speed, bool isAI)
        {
            Size = size;
            Score = 2;
            Play = true;
            _delay = speed;
            
            //Builds a different gameboard for the ai
            if (isAI)
            {
                Board = new GameBoard(Size, isAI);
                _aiPath = Board.BuildPath();
            } else
            {
                Board = new GameBoard(Size);
            }

        }
        /// <summary>
        /// Asyncronos method that keeps the snake moving
        /// </summary>
        /// <param name="Progress"></param>
        /// <param name="cancelToken"></param>
        /// <returns></returns>
        public async Task StartMoving(IProgress<SnakeStatus> progress, CancellationToken cancelToken)
        {
            SnakeStatus snakeStatus;
            while (Play)
            {
                if (cancelToken.IsCancellationRequested) 
                {
                    Play = false;
                    break;
                }
                snakeStatus = Board.MoveSnake(KeyPress);
                if (snakeStatus == SnakeStatus.Collision)
                {
                    Play = false;
                }
                if (snakeStatus == SnakeStatus.Moving)
                {
                    LastDirection = KeyPress;
                }
                if (snakeStatus == SnakeStatus.Eating)
                {
                    Score++;
                }
                if (snakeStatus == SnakeStatus.InvalidDirection)
                {
                    snakeStatus = Board.MoveSnake(LastDirection);
                    if (snakeStatus == SnakeStatus.Collision)
                    {
                        Play = false;
                    }
                    if (snakeStatus == SnakeStatus.Eating)
                    {
                        Score++;
                    }
                }
                if (snakeStatus == SnakeStatus.Win)
                {
                    Score++;
                    Play = false;
                }
                progress.Report(snakeStatus);
                //Set Tick Speed
                await Task.Delay(_delay);
            }
        }

        /// <summary>
        /// Same method as above but uses the _aiPath linkedlist as the key input
        /// </summary>
        /// <param name="progress"></param>
        /// <param name="cancelToken"></param>
        /// <param name="delay"></param>
        /// <returns></returns>
        public async Task StartMoving_AI(IProgress<SnakeStatus> progress, CancellationToken cancelToken, int delay)
        {
            SnakeStatus snakeStatus;
            GameNodeLinkedList move = _aiPath;
            while (Play)
            {
                if (cancelToken.IsCancellationRequested)
                {
                    Play = false;
                    break;
                }
                snakeStatus = Board.MoveSnake(move.Direction);
                move = move.Next;
                if (snakeStatus == SnakeStatus.Collision)
                {
                    Play = false;
                }
                if (snakeStatus == SnakeStatus.Moving)
                {
                    LastDirection = move.Direction;
                }
                if (snakeStatus == SnakeStatus.Eating)
                {
                    Score++;
                }
                if (snakeStatus == SnakeStatus.InvalidDirection)
                {
                    snakeStatus = Board.MoveSnake(LastDirection);
                    if (snakeStatus == SnakeStatus.Collision)
                    {
                        Play = false;
                    }
                    if (snakeStatus == SnakeStatus.Eating)
                    {
                        Score++;
                    }
                }
                if (snakeStatus == SnakeStatus.Win)
                {
                    Score++;
                    Play = false;
                }
                progress.Report(snakeStatus);
                //Set Tick Speed
                await Task.Delay(delay);
            }
        }

        /// <summary>
        /// Property Changed handler
        /// </summary>
        /// <param name="propertyName"></param>
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Returns the result of getsnakepath in gameboard class
        /// </summary>
        /// <returns></returns>
        public List<GameNode> GetSnakePath()
        {
            return Board.GetSnakePath();
        }
        /// <summary>
        /// Gets the node with the food token
        /// </summary>
        /// <returns>Null if game is over</returns>
        public GameNode GetFood()
        {
            return Board.Food;
        }
        /// <summary>
        /// Sets KeyPress to the Up Direction
        /// </summary>
        public void MoveUp()
        {
            KeyPress = Direction.Up;
        }
        /// <summary>
        /// Sets KeyPress to the Down Direction
        /// </summary>
        public void MoveDown()
        {
            KeyPress = Direction.Down;
        }
        /// <summary>
        /// Sets KeyPress to the Left Direction
        /// </summary>
        public void MoveLeft()
        {
            KeyPress = Direction.Left;
        }
        /// <summary>
        /// sets KeyPress to the Right Direction
        /// </summary>
        public void MoveRight()
        {
            KeyPress = Direction.Right;
        }
    }
}
