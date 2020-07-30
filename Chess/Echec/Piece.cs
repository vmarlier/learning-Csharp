using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace Echec
{
    public abstract class Piece
    {
        public enum Color { white, black, indice}
        public Color c;
        public string id;

        public Piece(Color c)
        {
            this.c = c;
        }
        
        public virtual List<Coord> GetPossibleMoves(Piece[,] gameBoard, Coord coord)
        {
            return new List<Coord>(); 
        }
    }
}