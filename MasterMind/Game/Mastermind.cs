using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Mastermind;



namespace Game
{
    public class Mastermind
    {

        // Fields
        private string _instructions = "What's the sequence? Each item can be either RED, BLUE, GREEN, OR YELLOW.";
        private bool _solved;
        
        private int _numTries;

        // Contructor
        public Mastermind()
        {
            _solved = false;
            _numTries = 1;

        }

        // Play
        public void Play()
        {
            Console.Clear();
            Console.WriteLine("\r\n==============================================");
            Console.WriteLine(" MASTERMIND");
            Console.WriteLine("==============================================");

            //Display Instructions
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(_instructions);
            Console.ResetColor();

            //Generate Sequence
            Console.WriteLine("------------------------");
            int size = validateInt("How many colors should the sequence contain? ");

            
            Sequence sequence = new Sequence(size);
            sequence.Display();

            // Play until solved
            while (!_solved)
            {
                Console.Write("Please guess the sequence: ");
                string[] guess = Console.ReadLine().ToUpper().Split();

                // Compare sequence to guess
                int numCorrect = sequence.Display(guess);
                if (numCorrect < sequence.Size)
                {
                    Console.WriteLine($"{numCorrect } Correct, try again.");
                    Console.WriteLine("==============================================");
                    Console.WriteLine("");
                    _numTries++;
                }
                else
                {
                    _solved = true;
                }
            }

            //Solved message
            Console.WriteLine("==============================================");
            Console.WriteLine(" Congrats, you've solved the sequence!");
            Console.WriteLine($"Score: {Score(sequence)} ");
            Console.WriteLine("==============================================");

        }


        // Calcualte Score
        private int Score(Sequence sequence)
        {
            int points;
            points = (sequence.Size * 1000) / _numTries;
            // 4 * 1000 = 4000
            // 4000 / 4 = 1000
            // 4 guesses = 1000 points

            return points;


        }



        // Validate Integer
        private static int validateInt(string message)
        {
            Console.Write(message);
            string input = Console.ReadLine();
            int guess;

            while (!Int32.TryParse(input, out guess))
            {
                Console.Write(" Invalid input, Please enter a number! ");
                input = Console.ReadLine();

            }

            return guess;
        }


    // End class
    }
}
