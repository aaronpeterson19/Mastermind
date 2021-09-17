using System;


namespace Game
{
    class Program
    {

        // Application entry point
        static void Main(string[] args)
        {
            bool play = true;
            while (play)
            {
                //Play game
                Mastermind game = new Mastermind();
                game.Play();

                //Play Again?
                play = PlayAgain();
            }
        }

        //Allow user to run application again
        private static bool PlayAgain()
        {
            Console.WriteLine(" \r\n=======================================");
            Console.Write(" Would you like to play again? [Y/N]: ");

            string response = Console.ReadLine().ToUpper();
            return (response == "Y") ? true : false;
        }



    // End class
    }
}
