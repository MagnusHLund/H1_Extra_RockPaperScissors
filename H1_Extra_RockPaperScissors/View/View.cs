using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H1_Extra_RockPaperScissors.View
{
    internal class View
    {
        /// <summary>
        /// This method writes a custom message based on the parameter
        /// </summary>
        /// <param name="message"></param>
        internal void Message(string message)
        {
            Console.WriteLine(message);
        }

        /// <summary>
        /// The Color() method switches colors based on a parameter.
        /// It changes the color between grey and white, every time the method gets called, from the same if statement.
        /// </summary>
        /// <param name="value"></param>
        internal void Color(byte value)
        {
            if (value % 2 == 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        /// <summary>
        /// Resets the text color back to white
        /// </summary>
        internal void ResetColor()
        {
            Console.ResetColor();
        }

        /// <summary>
        /// Clears the console window
        /// </summary>
        internal void Clear()
        {
            Console.Clear();
        }

        /// <summary>
        /// Returns a Console.ReadLine, to wherever its called from
        /// </summary>
        /// <returns></returns>
        internal string ReadLine()
        {
            return Console.ReadLine();
        }

        /// <summary>
        /// Changes the console color, based on the parameter
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        internal void ResultColor(string result)
        {
            if (result == "draw")
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            else if (result == "win")
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            else if (result == "loss")
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
}
