using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace Echec
{
    public class Bishop : Piece
    {
        public Bishop(Color c) : base(c)
        {
            if (c == Color.white)
                id = "\u265D";
            else
                id = "\u2657";
        }
        
        public override List<Coord> GetPossibleMoves(Piece[,] gameBoard, Coord coord)
        {
            List<Coord> coords = new List<Coord>();

            int LimitX = 8 - coord.x;
            int LimitY = 8 - coord.y;

            //for (int i = 1; i <= 5; i++)
            //{
            //    for (int j = 1; j <= 5; j++)
            //    {
            //        Piece MoveTopLeft = gameBoard[coord.x - i, coord.y - j];
            //        if (MoveTopLeft == null)
            //            coords.Add(new Coord(coord.x - i, coord.y - j));
            //    }
            //}
            //bug: Affiche toutes les cases possibles mais aussi les cases 'étape' (exemple: pour aller a coord.x -1 et coord.y -1 l'étape coord.x -1 coord.y sera affiché
            //bug: Trouver le bon ratio pour la limite de la boucle for.
            
            return coords;
        }
    }
}