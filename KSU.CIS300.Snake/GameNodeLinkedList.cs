/* GameNodeLinkedList.cs
 * Author: Johnathan Partridge
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSU.CIS300.Snake
{
    public class GameNodeLinkedList
    {
        /// <summary>
        /// Node of the current cell
        /// </summary>
        public GameNode Node { get; set; }
        
        /// <summary>
        /// Direction to go to the next node
        /// </summary>
        public Direction Direction { get; set; }

        /// <summary>
        /// Next node in the chain
        /// </summary>
        public GameNodeLinkedList Next { get; set; }

        /// <summary>
        /// Constructor for the linkedlist cell
        /// </summary>
        /// <param name="node"></param>
        /// <param name="dir"></param>
        public GameNodeLinkedList(GameNode node)
        {
            Node = node;
        }
    }
}