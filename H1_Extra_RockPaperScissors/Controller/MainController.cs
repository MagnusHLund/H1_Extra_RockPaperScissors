using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H1_Extra_RockPaperScissors.Controller
{
    internal class MainController
    {
        View.View view = new View.View();
        Model.Display display = new Model.Display();

        /// <summary>
        /// This is the entry point for the program, once called from the Main() method inside the Program class.
        /// It is responsible for calling the other methods, which play the game, as well as storing some local variables for the Winner() method.
        /// </summary>
        internal void Start()
        {
            Menu();
            byte player = Player();
            Countdown();
            byte computer = Computer();
            Winner(player, computer);
            PlayAgain();
        }

        /// <summary>
        /// This method runs a for loop, which goes through each of the strings located in Model.Display.lines[]
        /// It then outputs hte strings and changes the color based on the value of 'i'
        /// Once the for loop is done, it resets the color back to default.
        /// </summary>
        private void Menu()
        {
            for (byte i = 0; i < display.lines.Length; i++)
            {
                view.Message(display.lines[i]);
                view.Color(i);
            }

            view.ResetColor();
        }

        /// <summary>
        /// This method is responsible for Player input.
        /// It runs an infinite loop, because its uncertain how many attempts it will take the user to write a correct input.
        /// Exception handling is used incase of errors in the input.
        /// The user input gets stored in a byte variable called 'input'.
        /// If the input is outside of the range, it throws an exception which gets caught by the exception handling.
        /// Once the input is valid, it returns the value to the Start() method and gets stored as a variable.
        /// </summary>
        /// <returns></returns>
        private byte Player()
        {
            while (true)
            {
                try
                {
                    byte input = byte.Parse(view.ReadLine());

                    // Check if the number is not 1, 2 or 3. If its not, then it throws an exception.
                    if (input < 1 || input > 3)
                    {
                        throw new Exception("Incorrect input range");
                    }

                    return input;
                }
                catch
                {
                    view.Message("Your input can only be 1, 2 or 3!");
                }
            }
        }

        /// <summary>
        /// This method goes through each of the strings inside the Model.Display.countdown[], using a foreach.
        /// It outputs "Rock", then "Paper", then "Scissors".
        /// After each output, it pauses the program for a second.
        /// </summary>
        private void Countdown()
        {
            foreach (string str in display.countdown)
            {
                view.Message(str);
                Thread.Sleep(1000);
            }
        }

        /// <summary>
        /// This method represents the computers choice.
        /// It gets a random value which can be either 1, 2 or 3.
        /// The value then gets returned to the Start() method and stored in a local variable.
        /// </summary>
        /// <returns></returns>
        private byte Computer()
        {
            Random random = new Random();
            return (byte)random.Next(1, 4);
        }

        /// <summary>
        /// This method is responsible for calculating the outcome of the match.
        /// It gets the 2 parameters from the Start() method, which have been stored from the Player() and Computer() methods.
        /// First it translates the computer result, to a string from a byte, which then gets output to the console.
        /// The method then figures out who the winner is, based on the parameter values.
        /// </summary>
        /// <param name="player"></param>
        /// <param name="computer"></param>
        private void Winner(byte player, byte computer)
        {
            string translate;

            // Translates the parameter value to a string, which gets output to the console view.
            if (computer == 1)
            {
                translate = "Rock";
            }
            else if (computer == 2)
            {
                translate = "Paper";
            }
            else
            {
                translate = "Scissors";
            }

            view.Message($"Computer: {translate}");

            // Checks if the match was a draw
            if (player == computer)
            {
                view.ResultColor("draw");
                view.Message("Draw, playing again!");
                Thread.Sleep(1000);
                view.ResetColor();
                Start();
            }

            // Checks if the player or computer won, based on the parameter values
            if (player > computer && player != 1 || player == 1 && computer == 3)
            {
                view.ResultColor("win");
                view.Message("Player won!");
            }
            else
            {
                view.ResultColor("loss");
                view.Message("Computer won!");
            }

            // Resets the color back to default and sleeps for 2 seconds
            view.ResetColor();
            Thread.Sleep(2000);
        }

        /// <summary>
        /// This method asks the user if they wanna play again or not.
        /// It runs in an infinite loop, because its uncertain how many attempts is needed for the user to give a valid input
        /// An if statement checks if the input indicate yes or no, which will then make them play again or not, based on the value.
        /// If the user has not correctly indicated if they wanna play or not, the loop repeats.
        /// </summary>
        private void PlayAgain()
        {
            bool again;

            while (true)
            {
                view.Message("Play again? y/n");

                // the input string gets the readline in lowercase, to prevent more checks in the if statement
                string input = view.ReadLine().ToLower();

                // Checks if the user input indicates yes, no or neither
                if (input == "y" || input == "yes")
                {
                    again = true;
                    break;
                }
                else if (input == "n" || input == "no")
                {
                    again = false;
                    break;
                }
                else
                {
                    view.Message("Please only write y, yes, n or no.");
                }
            }

            // Clears the console window
            view.Clear();
            
            // Plays again if the 'again' bool is true
            if (again)
            {
                Start();
            }
        }
    }
}
