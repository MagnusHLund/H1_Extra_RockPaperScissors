using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H1_Extra_RockPaperScissors.Model
{
    internal class Display
    {
        /// <summary>
        /// This array contains 1 line of the menu each. 
        /// A for loop then goes through each of the strings in the array and outputs it in different colors.
        /// </summary>
        internal string[] lines =
        {
            "Press any of the following numbers, to choose ROCK, PAPER or SCISSORS", 
            "1.\tRock",
            "2.\tPaper",
            "3.\tScissors"
        };

        /// <summary>
        /// String array containing each of the 3 possible choices, which gets used in the Countdown() method, in the MainController class.
        /// </summary>
        internal string[] countdown =
        {
            "Rock",
            "Paper",
            "Scissors"
        };
    }
}
