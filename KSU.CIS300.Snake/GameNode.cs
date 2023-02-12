/* GameNode.cs
 * Author: Johnathan Partridge
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSU.CIS300.Snake
{
    /// <summary>
    /// Enumerator for what each GameNode is
    /// </summary>
    public enum GridData
    {
        Empty,
        SnakeHead,
        SnakeBody,
        SnakeFood
    }
    /// <summary>
    /// Contains All Information regarding a GameNode
    /// </summary>
    public class GameNode
    {
        //Properties
        /// <summary>
        /// Y - Coordinate for this node
        /// </summary>
        public int Y;
        /// <summary>
        /// X - Coordinate for this node
        /// </summary>
        public int X;
        /// <summary>
        /// Information stored at this node
        /// </summary>
        public GridData Data;

        /// <summary>
        /// Used to connect snake pieces from the tail to the head
        /// </summary>
        public GameNode SnakeEdge;

        //Methods

        /// <summary>
        /// GameNode Constructor
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public GameNode(int x, int y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// Override to the To String Method for debugging
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "X: " + X.ToString() + " Y: " + Y.ToString() + " Data: " + Data.ToString();
        }
        
        /// <summary>
        /// Compares x and y coordinates to determine equality
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator == (GameNode a, GameNode b)
        {
            if (Equals(a, null))
            {
                return Equals(b, null);
            } else if (Equals(b, null))
            {
                return Equals(a, null);
            }

            if (Equals(a.X, b.X) && Equals(a.Y, b.Y))
            {
                return true;
            } else
            {
                return false;
            }
        }

        public static bool operator != (GameNode a, GameNode b)
        {
            return !(a == b);
        }

    }
}
