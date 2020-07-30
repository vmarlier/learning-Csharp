using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading.Tasks;

namespace Echec
{
    public class King : Piece
    {
        public King(Color c) : base(c)
        {
            if (c == Color.white)
                id = "\u265A";
            else
                id = "\u2654";
        }

        public override List<Coord> GetPossibleMoves(Piece[,] gameBoard, Coord coord)
        {
            List<Coord> coords = new List<Coord>();

            Color ColorAdversary;

            if (c == Color.black)
                ColorAdversary = Color.white;
            else
                ColorAdversary = Color.black;


            if (coord.y < 8)
            {
                Piece MoveFront = gameBoard[coord.x, coord.y + 1];
                if (MoveFront == null || MoveFront != null && MoveFront.c == ColorAdversary)
                    coords.Add(new Coord(coord.x, coord.y + 1));
            }
            if (coord.y > 1)
            {
                Piece MoveBack = gameBoard[coord.x, coord.y - 1];
                if (MoveBack == null || MoveBack != null && MoveBack.c == ColorAdversary)
                    coords.Add(new Coord(coord.x, coord.y - 1));
            }
            if (coord.x < 8)
            {
                Piece MoveRight = gameBoard[coord.x + 1, coord.y];
                if (MoveRight == null || MoveRight != null && MoveRight.c == ColorAdversary)
                    coords.Add(new Coord(coord.x + 1, coord.y));
            }
            if (coord.x > 1)
            {
                Piece MoveLeft = gameBoard[coord.x - 1, coord.y];
                if (MoveLeft == null || MoveLeft != null && MoveLeft.c == ColorAdversary)
                    coords.Add(new Coord(coord.x - 1, coord.y));
            }
           

            if (coord.x < 8 && coord.y < 8)
            {
                Piece MoveFrontRight = gameBoard[coord.x + 1, coord.y + 1];
                if (MoveFrontRight == null || MoveFrontRight != null && MoveFrontRight.c == ColorAdversary)
                    coords.Add(new Coord(coord.x + 1, coord.y + 1));
            }
            if (coord.x > 1 && coord.y < 8)
            {
                Piece MoveFrontLeft = gameBoard[coord.x - 1, coord.y + 1];
                if (MoveFrontLeft == null || MoveFrontLeft != null && MoveFrontLeft.c == ColorAdversary)
                    coords.Add(new Coord(coord.x -1 , coord.y + 1));
            }
            if (coord.x < 8 && coord.y > 1)
            {
                Piece MoveBackRight = gameBoard[coord.x + 1, coord.y - 1];
                if (MoveBackRight == null || MoveBackRight != null && MoveBackRight.c == ColorAdversary)
                    coords.Add(new Coord(coord.x + 1, coord.y - 1));
            }
            if (coord.x > 1 && coord.y > 1)
            {
                Piece MoveBackLeft = gameBoard[coord.x - 1, coord.y - 1];
                if (MoveBackLeft == null || MoveBackLeft != null && MoveBackLeft.c == ColorAdversary)
                    coords.Add(new Coord(coord.x - 1, coord.y - 1));
            }

            return coords;
        }
    }
}