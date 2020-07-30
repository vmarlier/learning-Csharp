using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace Echec
{
    public class Pawn : Piece
    {
        public Pawn(Color c) : base(c)
        {
            if (c == Color.white)
                id = "\u265F";
            else
                id = "\u2659";
        }

        public override List<Coord> GetPossibleMoves(Piece[,] gameBoard, Coord coord)
        {
            List<Coord> coords = new List<Coord>(); 

            Color ColorAdversary;
            int Movement;

            if (c == Color.black)
            {
                ColorAdversary = Color.white;
                Movement =  1;
            }
            else
            {
                ColorAdversary = Color.black;
                Movement = -1;
            }


            if (Movement == 1)
            {
                if (coord.y < 8)
                {
                    Piece CaseMovement = gameBoard[coord.x, coord.y + Movement];
                    if (CaseMovement == null)
                        coords.Add(new Coord(coord.x, coord.y + Movement));
                }
                if (coord.x > 1 && coord.y < 8)
                {
                    Piece CaseAttackLeft = gameBoard[coord.x - 1, coord.y + Movement];
                    if (CaseAttackLeft != null && CaseAttackLeft.c == ColorAdversary)
                        coords.Add(new Coord(coord.x - 1, coord.y + Movement));
                }
                if (coord.x < 8 && coord.y < 8)
                {
                    Piece CaseAttackRight = gameBoard[coord.x + 1, coord.y + Movement];
                    if (CaseAttackRight != null && CaseAttackRight.c == ColorAdversary)
                        coords.Add(new Coord(coord.x + 1, coord.y + Movement));
                }
            }
            else if (Movement == -1)
            {
                if (coord.y > 1)
                {
                    Piece CaseMovement = gameBoard[coord.x, coord.y + Movement];
                    if (CaseMovement == null)
                          coords.Add(new Coord(coord.x, coord.y + Movement));
                    
                }
                if (coord.x > 1 && coord.y > 1)
                {
                    Piece CaseAttackLeft = gameBoard[coord.x - 1, coord.y + Movement];
                    if (CaseAttackLeft != null && CaseAttackLeft.c == ColorAdversary)
                        coords.Add(new Coord(coord.x - 1, coord.y + Movement));
                }
                if (coord.x < 8 && coord.y > 1)
                {
                    Piece CaseAttackRight = gameBoard[coord.x + 1, coord.y + Movement];
                    if (CaseAttackRight != null && CaseAttackRight.c == ColorAdversary)
                        coords.Add(new Coord(coord.x + 1, coord.y + Movement));
                }
            }
            return coords;
        }
    }
}