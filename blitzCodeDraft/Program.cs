using System;
using System.Collections.Generic;

namespace blitzCodeDraft
{
    class Program
    {       
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Welcome to MatchGame!\n\nChoose difficulty:");
                Console.WriteLine("Easy (5 figures)\n\nMedium (7 figures)\n\nHard (9 figures)");

                string diff = Console.ReadLine();
                int difficulty = Convert.ToInt32(diff);

                PlayGame((Difficulty)difficulty);
            }
        }
        public static void PlayGame(Difficulty difficulty)
        {
            GameSetup currentGameSetup = new GameSetup(difficulty);
            currentGameSetup.CreateFigures();
            currentGameSetup.CreateDeck(10);

            int points = 0;

            Console.WriteLine("Current Game Figures");
            foreach (var figure in currentGameSetup.GameFigures)
            {
                Console.WriteLine($"{figure.Shape}, {figure.Color}");
            }

            Console.WriteLine("\n\n");

            foreach (var Card in currentGameSetup.Deck)
            {
                foreach (var figure in Card.FiguresOnCard)
                {
                    Console.Write($"{figure.Shape}: ");
                    Console.WriteLine(figure.Color);
                }

                Console.Write("Input Answer: ");
                string answer = Console.ReadLine();
                if(answer == Card.CorrectFigure.Shape.ToString())
                {
                    points++;
                    Console.WriteLine("You chose the right answer!");
                }
                else
                {
                    Console.WriteLine("The correct answer was:");
                    Console.WriteLine($"{Card.CorrectFigure.Shape}, {Card.CorrectFigure.Color}");   
                }              
            }

            Console.WriteLine($"You got {points} points! Noob");

        }      
        

    }

    public enum Difficulty
    {
        Easy = 5, Intermidiate = 7, Advanced = 9
    }

    public enum Shape
    {
        Point, Line, Triangle, Square, Pentagon, Hexagon, Heptagon, Octagon, Circle
    }
    
    public enum Color
    {
        Red, Blue, Yellow, Green, Purple, Orange, Pink, Black, White
    }
}
