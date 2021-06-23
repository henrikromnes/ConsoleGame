using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace blitzCodeDraft
{
    //Instance of specific GameSetup
    class GameSetup
    {
        public List<Figure> GameFigures = new List<Figure>();
        public List<Card> Deck = new List<Card>();
        private Difficulty _difficulty;

        public GameSetup(Difficulty difficulty)
        {
            _difficulty = difficulty;
        }

        //Create figure pool
        public void CreateFigures()
        {
            List<Color> colorsChosen = new List<Color>();
            List<Shape> shapesChosen = new List<Shape>();

            int numberOfFigures = (int)_difficulty;
            for (int i = 0; i < numberOfFigures; i++)
            {
                Shape shapeFound;
                Color colorFound;
                while (true)//Find free shape
                {
                    var random = new Random();
                    int randomSha = random.Next(0, 9);
                    Shape shape = (Shape)randomSha;
                    if (!shapesChosen.Contains(shape))
                    {
                        shapesChosen.Add(shape);
                        shapeFound = shape;
                        break;
                    }

                }
                while (true)//Find free color
                {
                    var random = new Random();
                    int randomCol = random.Next(0, 9);
                    Color color = (Color)randomCol;
                    if (!colorsChosen.Contains(color))
                    {
                        colorsChosen.Add(color);
                        colorFound = color;
                        break;
                    }
                }

                GameFigures.Add(new Figure(shapeFound, colorFound));
            }            
        }

        //Creates card
        public Card CreateCard(bool fullyRepresented) 
        {
            List<Figure> cardFigures = new List<Figure>();           

            var random = new Random();
            int randomSol = random.Next(0, GameFigures.Count);
            Figure figureSolution = GameFigures[randomSol];                   

            List<Color> colorsTaken = new List<Color>();
            List<Shape> shapesTaken = new List<Shape>();
            colorsTaken.Add(figureSolution.Color);
            shapesTaken.Add(figureSolution.Shape);

            if (fullyRepresented)
            {
                cardFigures.Add(figureSolution);
            }       

            while (true)
            {
                Shape shapeFound;
                Color colorFound;
                while (true)//Find free shape
                {
                    int figureNumber = random.Next(0, (int)_difficulty);
                    Shape shape = GameFigures[figureNumber].Shape;
                    if (!shapesTaken.Contains(shape))
                    {
                        shapesTaken.Add(shape);
                        colorsTaken.Add(GameFigures[figureNumber].Color);
                        shapeFound = shape;
                        break;
                    }
                }

                while (true)//Find free color
                {
                    int figureNumber = random.Next(0, (int)_difficulty);
                    Color color = GameFigures[figureNumber].Color;
                    if (!colorsTaken.Contains(color))
                    {
                        colorsTaken.Add(color);
                        shapesTaken.Add(GameFigures[figureNumber].Shape);
                        colorFound = color;
                        break;
                    }
                }

                cardFigures.Add(new Figure(shapeFound, colorFound));       
                if (cardFigures.Count == ((int)_difficulty - 1) / 2)
                {
                    break;
                }
            }
        
            cardFigures = cardFigures.OrderBy(i => Guid.NewGuid()).ToList();
     
            return new Card(cardFigures, figureSolution);
        }

        //Creates deck
        public void CreateDeck(int deckSize)
        {
            for (int i = 0; i < deckSize; i++)
            {
                var random = new Random();
                int randomCardType = random.Next(1, 101);

                if (randomCardType <= 41)
                {
                    Deck.Add(CreateCard(true));
                }
                else
                {
                    Deck.Add(CreateCard(false));
                }
            }
        }
    }
}
