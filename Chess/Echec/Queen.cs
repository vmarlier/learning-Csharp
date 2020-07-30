using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace Echec
{
    public class Queen : Piece
    {
        public Queen(Color c) : base(c)
        {
            if (c == Color.white)
                id = "\u265B";
            else
                id = "\u2655";
        }
        
        public override List<Coord> GetPossibleMoves(Piece[,] gameBoard, Coord coord)
        {
            List<Coord> coords = new List<Coord>();

            int LimitY = 8 - coord.y;
            int LimitX = 8 - coord.x;
            
            Color ColorAdversary;

            if (c == Color.black)
                ColorAdversary = Color.white;
            else
                ColorAdversary = Color.black;
            
            for (int i = 1; i <= coord.y; i++)
            {
                Piece MoveBack = gameBoard[coord.x, coord.y - i];
                if (MoveBack == null)
                    coords.Add(new Coord(coord.x, coord.y - i));
                if (MoveBack != null && MoveBack.c == c)
                    break;
                if (MoveBack != null && MoveBack.c == ColorAdversary)
                {
                    coords.Add(new Coord(coord.x, coord.y - i));
                    break;
                }
            }

            for (int i = 1; i <= LimitY; i++)
            {
                Piece MoveFront = gameBoard[coord.x, coord.y + i];
                if (MoveFront == null)
                    coords.Add(new Coord(coord.x, coord.y + i));
                if (MoveFront != null && MoveFront.c == c)
                    break;
                if (MoveFront != null && MoveFront.c == ColorAdversary)
                {
                    coords.Add(new Coord(coord.x, coord.y + i));
                    break;
                }
            }
            
            for (int i = 1; i <= coord.x; i++)
            {
                Piece MoveLeft = gameBoard[coord.x - i, coord.y];
                if (MoveLeft == null)
                    coords.Add(new Coord(coord.x - i, coord.y));
                if (MoveLeft != null && MoveLeft.c == c)
                    break;
                if (MoveLeft != null && MoveLeft.c == ColorAdversary)
                {
                    coords.Add(new Coord(coord.x -i, coord.y));
                    break;
                }
            }
            
            for (int i = 1; i <= LimitX; i++)
            {
                Piece MoveRight = gameBoard[coord.x + i, coord.y];
                if (MoveRight == null)
                    coords.Add(new Coord(coord.x + i, coord.y));
                if (MoveRight != null && MoveRight.c == c)
                    break;
                if (MoveRight != null && MoveRight.c == ColorAdversary)
                {
                    coords.Add(new Coord(coord.x + i, coord.y));
                    break;
                }
            }
                
            
            
            return coords;
        }
    }
}