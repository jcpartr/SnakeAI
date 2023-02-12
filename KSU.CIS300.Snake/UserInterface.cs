/* UserInterface.cs
 * Author: Johnathan Partridge
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;


namespace KSU.CIS300.Snake
{
    public partial class uxInterface : Form
    {

        //Fields
        /// <summary>
        /// Calculated size of a game square
        /// </summary>
        private int _squareWidth;

        /// <summary>
        /// Width and height of the game in number of nodes/game squares
        /// </summary>
        private int _size;

        /// <summary>
        /// Game object
        /// </summary>
        private Game _game;

        /// <summary>
        /// Used to give the snake color
        /// </summary>
        private SolidBrush _bodyBrush = new SolidBrush(Color.Brown);

        /// <summary>
        /// Used to give the food color
        /// </summary>
        private SolidBrush _foodBrush = new SolidBrush(Color.Green);
        
        /// <summary>
        /// Gives each snake square an outline
        /// </summary>
        private Pen _pen = new Pen(Brushes.Black, 2);

        /// <summary>
        /// Allows UI to cancel or stop the async StopMoving in Game class
        /// </summary>
        private CancellationTokenSource _cancelSource;

        /// <summary>
        /// Construct the UI
        /// </summary>
        public uxInterface()
        {
            InitializeComponent();
            KeyPreview = true;

            KeyDown += uxInterface_KeyDown;
            uxCheckBox_AIPlayer.PreviewKeyDown += uxInterface_PreviewKeyDown;
        }
        /// <summary>
        /// Enables the use of arrow keys to move the snake
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxInterface_KeyDown(object sender, KeyEventArgs e)
        {
            if(_game == null) { return; }
            if (_game.Play)
            {
                if (e.KeyCode == Keys.Up)
                {
                    _game.MoveUp();
                } else if (e.KeyCode == Keys.Down)
                {
                    _game.MoveDown();
                } else if (e.KeyCode == Keys.Right)
                {
                    _game.MoveRight();
                } else if (e.KeyCode == Keys.Left)
                {
                    _game.MoveLeft();
                }
            }
            uxPictureBox_Game.Refresh();
        }

        /// <summary>
        /// Creates a new Easy Game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxToolStrip_Easy_Click(object sender, EventArgs e)
        {
            NewGame(10, 250);
        }

        /// <summary>
        /// Creates a new Normal Game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxToolStrip_Normal_Click(object sender, EventArgs e)
        {
            NewGame(20, 150);
        }

        /// <summary>
        /// Createsa a new Hard Game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxToolStrip_Hard_Click(object sender, EventArgs e)
        {
            NewGame(30, 100);
        }
        /// <summary>
        /// Creates a new game with the given settings
        /// </summary>
        /// <param name="size"></param>
        /// <param name="speed"></param>
        private void NewGame(int size, int speed)
        {
            _cancelSource = new CancellationTokenSource();

            //Cancels Previous Games
            _cancelSource.Cancel();

            _size = size;

            _game = new Game(size, speed, uxCheckBox_AIPlayer.Checked);

            uxPictureBox_Game.Width = 600;
            uxPictureBox_Game.Height = 600;

            uxPictureBox_Game.Padding = new Padding(25, 25, 25, 25);

            this.Size = new Size(650, 675);

            _squareWidth = uxPictureBox_Game.Width / size;

            uxLabel_Score.DataBindings.Clear();
            uxLabel_Score.DataBindings.Add(new Binding("Text", _game, "Score"));

            Progress<SnakeStatus> progress = new Progress<SnakeStatus>();
            progress.ProgressChanged += new EventHandler<SnakeStatus>(CheckProgress);

            _cancelSource = new CancellationTokenSource();

            if (uxCheckBox_AIPlayer.Checked)
            {
                _game.StartMoving_AI(progress, _cancelSource.Token, Convert.ToInt32(uxNum_AISpeed.Value));
            } else
            {
                _game.StartMoving(progress, _cancelSource.Token);
            }


        }
        /// <summary>
        /// Checks the async task to determine the game status
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="status"></param>
        private void CheckProgress(object sender, SnakeStatus status)
        {
            //Note that the Refresh call invalidates the state of the controls, forcing them to be redrawn.
            Refresh();
            if (status == SnakeStatus.Collision)
            {
                MessageBox.Show("Game over!");
            }
            else if (status == SnakeStatus.Win)
            {
                MessageBox.Show("Game Completed!");
            }
            uxPictureBox_Game.Refresh();
        }
        /// <summary>
        /// Draws the gameboard
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxPictureBox_Game_Paint(object sender, PaintEventArgs e)
        {
            if (_game != null)
            {
                Graphics g = e.Graphics;
                foreach (GameNode node in _game.GetSnakePath())
                {
                    Rectangle r = new Rectangle(node.X * _squareWidth, node.Y * _squareWidth, _squareWidth, _squareWidth);
                    g.FillRectangle(_bodyBrush, r);
                    g.DrawRectangle(_pen, r);
                }

                GameNode food = _game.GetFood();

                if (food != null)
                {
                    Rectangle f = new Rectangle(food.X * _squareWidth, food.Y * _squareWidth, _squareWidth, _squareWidth);
                    g.FillEllipse(_foodBrush, f);
                }
            }
        }

        /// <summary>
        /// Helper function for keys
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxInterface_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            e.IsInputKey = true;
        }
    }
}
