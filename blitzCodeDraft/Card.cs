using System;
using System.Collections.Generic;
using System.Text;

namespace blitzCodeDraft
{
    class Card
    {
        public List<Figure> FiguresOnCard = new List<Figure>();
        public Figure CorrectFigure;
        public Card(List<Figure> figures, Figure correctFigure)
        {
            FiguresOnCard = figures;
            CorrectFigure = correctFigure;
        }
    }
}
