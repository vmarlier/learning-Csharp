using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace Echec
{
    public class Knight : Piece
    {
        public Knight(Color c) : base(c)
        {
            if (c == Color.white)
                id = "\u265E";
            else
                id = "\u2658";
        }

        public override List<Coord> GetPossibleMoves(Piece[,] GameBoard, Coord coord)
        {
            List<Coord> coords = new List<Coord>();

            Color ColorAdversary;

            if (c == Color.black)
                ColorAdversary = Color.white;
            else
                ColorAdversary = Color.black;


            if (coord.x > 1 && coord.y < 7)
            {
                Piece MoveTopLeft = GameBoard[coord.x - 1, coord.y + 2];
                if (MoveTopLeft == null || MoveTopLeft != null && MoveTopLeft.c == ColorAdversary)
                    coords.Add(new Coord(coord.x - 1, coord.y + 2));
            }

            if (coord.x < 8 && coord.y < 7)
            {
                Piece MoveTopRight = GameBoard[coord.x + 1, coord.y + 2];
                if (MoveTopRight == null || MoveTopRight != null && MoveTopRight.c == ColorAdversary)
                    coords.Add(new Coord(coord.x + 1, coord.y + 2));
            }
            

            if (coord.x > 2 && coord.y < 8)
            {
                Piece MoveLeftTop = GameBoard[coord.x - 2, coord.y + 1];
                if (MoveLeftTop == null || MoveLeftTop != null && MoveLeftTop.c == ColorAdversary)
                    coords.Add(new Coord(coord.x - 2, coord.y + 1));
            }
            if (coord.x > 2 && coord.y > 1)
            {
                Piece MoveLeftBack = GameBoard[coord.x - 2, coord.y - 1];
                if (MoveLeftBack == null || MoveLeftBack != null && MoveLeftBack.c == ColorAdversary)
                    coords.Add(new Coord(coord.x - 2, coord.y - 1));
            }
            

            if (coord.x > 1 && coord.y > 2)
            {
                Piece MoveBackLeft = GameBoard[coord.x - 1, coord.y - 2];
                if (MoveBackLeft == null || MoveBackLeft != null && MoveBackLeft.c == ColorAdversary)
                    coords.Add(new Coord(coord.x - 1, coord.y - 2));
            }
            if (coord.x < 8 && coord.y > 2)
            {
                Piece MoveBackRight = GameBoard[coord.x + 1, coord.y - 2];
                if (MoveBackRight == null || MoveBackRight != null && MoveBackRight.c == ColorAdversary)
                    coords.Add(new Coord(coord.x + 1, coord.y - 2));
            }
            

            if (coord.x < 7 && coord.y < 8)
            {
                Piece MoveRightTop = GameBoard[coord.x + 2, coord.y + 1];
                if (MoveRightTop == null || MoveRightTop != null && MoveRightTop.c == ColorAdversary)
                    coords.Add(new Coord(coord.x + 2, coord.y + 1));
            }
            if (coord.x < 7 && coord.y > 1)
            {
                Piece MoveRightBack = GameBoard[coord.x + 2, coord.y - 1];
                if (MoveRightBack == null || MoveRightBack != null && MoveRightBack.c == ColorAdversary)
                    coords.Add(new Coord(coord.x + 2, coord.y - 1));
            }

            return coords;
        }
    }
}