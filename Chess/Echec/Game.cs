using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Echec
{
    public class Game
    {
        public Piece[,] GameBoard;
        private bool GameOver = false;

        public void StartGame()
        {
            GameBoard = new Piece[9, 9];
            //Easiest Indice to find case
            GameBoard[1, 0] = new Indice(Piece.Color.indice, "A");
            GameBoard[2, 0] = new Indice(Piece.Color.indice, "B");
            GameBoard[3, 0] = new Indice(Piece.Color.indice, "C");
            GameBoard[4, 0] = new Indice(Piece.Color.indice, "D");
            GameBoard[5, 0] = new Indice(Piece.Color.indice, "E");
            GameBoard[6, 0] = new Indice(Piece.Color.indice, "F");
            GameBoard[7, 0] = new Indice(Piece.Color.indice, "G");
            GameBoard[8, 0] = new Indice(Piece.Color.indice, "H");

            GameBoard[0, 1] = new Indice(Piece.Color.indice, "1");
            GameBoard[0, 2] = new Indice(Piece.Color.indice, "2");
            GameBoard[0, 3] = new Indice(Piece.Color.indice, "3");
            GameBoard[0, 4] = new Indice(Piece.Color.indice, "4");
            GameBoard[0, 5] = new Indice(Piece.Color.indice, "5");
            GameBoard[0, 6] = new Indice(Piece.Color.indice, "6");
            GameBoard[0, 7] = new Indice(Piece.Color.indice, "7");
            GameBoard[0, 8] = new Indice(Piece.Color.indice, "8");
            //Black Side, First Line
            GameBoard[1, 1] = new Rook(Piece.Color.black);
            GameBoard[2, 1] = new Knight(Piece.Color.black);
            GameBoard[3, 1] = new Bishop(Piece.Color.black);
            GameBoard[4, 1] = new Queen(Piece.Color.black);
            GameBoard[5, 1] = new King(Piece.Color.black);
            GameBoard[6, 1] = new Bishop(Piece.Color.black);
            GameBoard[7, 1] = new Knight(Piece.Color.black);
            GameBoard[8, 1] = new Rook(Piece.Color.black);
            //Black Side, Second Line
            GameBoard[1, 2] = new Pawn(Piece.Color.black);
            GameBoard[2, 2] = new Pawn(Piece.Color.black);
            GameBoard[3, 2] = new Pawn(Piece.Color.black);
            GameBoard[4, 2] = new Pawn(Piece.Color.black);
            GameBoard[5, 2] = new Pawn(Piece.Color.black);
            GameBoard[6, 2] = new Pawn(Piece.Color.black);
            GameBoard[7, 2] = new Pawn(Piece.Color.black);
            GameBoard[8, 2] = new Pawn(Piece.Color.black);
            //White Side, Second Line
            GameBoard[1, 7] = new Pawn(Piece.Color.white);
            GameBoard[2, 7] = new Pawn(Piece.Color.white);
            GameBoard[3, 7] = new Pawn(Piece.Color.white);
            GameBoard[4, 7] = new Pawn(Piece.Color.white);
            GameBoard[5, 7] = new Pawn(Piece.Color.white);
            GameBoard[6, 7] = new Pawn(Piece.Color.white);
            GameBoard[7, 7] = new Pawn(Piece.Color.white);
            GameBoard[8, 7] = new Pawn(Piece.Color.white);
            //White Side, First Line
            GameBoard[1, 8] = new Rook(Piece.Color.white);
            GameBoard[2, 8] = new Knight(Piece.Color.white);
            GameBoard[3, 8] = new Bishop(Piece.Color.white);
            GameBoard[4, 8] = new Queen(Piece.Color.white);
            GameBoard[5, 8] = new King(Piece.Color.white);
            GameBoard[6, 8] = new Bishop(Piece.Color.white);
            GameBoard[7, 8] = new Knight(Piece.Color.white);
            GameBoard[8, 8] = new Rook(Piece.Color.white);

            DemandToStart();

        }

        public void PrintBoard()
        {
            for (int i = 0; i <= 8; i++)
            {
                Console.Write("\n");
                for (int j = 0; j <= 8; j++)
                {
                    if (GameBoard[j, i] == null)
                        Console.Write("   |");
                    else
                        Console.Write(" " + GameBoard[j, i].id + " |");
                }
            }
        }

        public void DemandToStart()
        {
            bool started = false;
            if (started == false)
            {
                Console.Write("\n");
                Console.Write("Start a Game ? (Y/n)");
                string DemandToStart = Console.ReadLine();

                if (DemandToStart == "" || DemandToStart == "Y" || DemandToStart == "y")
                {
                    started = true;
                    Console.Write("Joueur n°1:\n");
                    string joueur1 = Console.ReadLine();
                    Console.Write("Joueur n°2:\n");
                    string joueur2 = Console.ReadLine();
                    while (GameOver == false)
                    {
                        PlayTurn(joueur1, Piece.Color.white);
                        PlayTurn(joueur2, Piece.Color.black);
                    }
                }
                else if (DemandToStart == "n")
                {
                    Console.Write("Really ?! Why did you start the game stupid ?");
                    StartGame();
                }
            }
        }

        public void PlayTurn(string joueur, Piece.Color color)
        {
            PrintBoard();
            Console.Write("\n" + joueur + "\n");


            Coord coordPieceToMove = AskPieceToMove(color);

            
            List<Coord> coordListMove = AskMoveIntoAList(coordPieceToMove);

            Coord coordDestination = ChooseWhereMovePiece(coordListMove);
            if (coordDestination == null)
            {
                while (coordDestination == null)
                {
                    coordDestination = ChooseWhereMovePiece(coordListMove);
                }
            }
            
            MovePiece(coordPieceToMove, coordDestination, color);
        }

        public Coord AskPieceToMove(Piece.Color color)
        {
            Console.Write("Please select the piece you want to move" + "\n");
            Console.Write("[A..H]: ");
            string X = Console.ReadLine();
            int x = 0;
            if (new string[]
                {"A", "a", "B", "b", "C", "c", "D", "d", "E", "e", "F", "f", "G", "g", "H", "h"}.Contains(X))
            {
            }
            else
            {
                Console.Write("Hmmm..."+X+" Doesn't exist..\n");
                AskPieceToMove(color);
            }
            switch (X)
            {
                case "A":
                case "a":
                    x = 1;
                    break;
                case "B":
                case "b":
                    x = 2;
                    break;
                case "C":
                case "c":
                    x = 3;
                    break;
                case "D":
                case "d":
                    x = 4;
                    break;
                case "E":
                case "e":
                    x = 5;
                    break;
                case "F":
                case "f":
                    x = 6;
                    break;
                case "G":
                case "g":
                    x = 7;
                    break;
                case "H":
                case "h":
                    x = 8;
                    break;
            }
            Console.Write("\n" + "[1..8]:");
            int y = int.Parse(Console.ReadLine());

            if (y < 1 || y > 8)
            {
                Console.Write("Hmmm..."+y+" Doesn't exist..\n");
                AskPieceToMove(color);
            }

            if (GameBoard[x, y].c != color)
            {
                Console.Write("Are you sure this is your piece ?\n");
                AskPieceToMove(color);
            }
            
            Coord coord = new Coord(x, y);
            
            return coord;
        }

        public List<Coord> AskMoveIntoAList(Coord coord)
        {
            if (GameBoard[coord.x,coord.y].id == "\u2659")
            {
                Console.Write("\u2659");
                Pawn piece = new Pawn(Piece.Color.black);
                List<Coord> coordDestination = piece.GetPossibleMoves(GameBoard, coord);
                return coordDestination;
            }
            else if (GameBoard[coord.x,coord.y].id == "\u265F")
            {
                Console.Write("\u265F");
                Pawn piece = new Pawn(Piece.Color.white);
                List<Coord> coordDestination = piece.GetPossibleMoves(GameBoard, coord);
                return coordDestination;
            }
            else if (GameBoard[coord.x,coord.y].id == "\u2658")
            {
                Console.Write("\u2658");
                Knight piece = new Knight(Piece.Color.black);
                List<Coord> coordDestination = piece.GetPossibleMoves(GameBoard, coord);
                return coordDestination;
            }
            else if (GameBoard[coord.x,coord.y].id == "\u265E")
            {
                Console.Write("\u265E");
                Knight piece = new Knight(Piece.Color.white);
                List<Coord> coordDestination = piece.GetPossibleMoves(GameBoard, coord);
                return coordDestination;
            }
            else if (GameBoard[coord.x,coord.y].id == "\u2654")
            {
                Console.Write("\u2654");
                King piece = new King(Piece.Color.black);
                List<Coord> coordDestination = piece.GetPossibleMoves(GameBoard, coord);
                return coordDestination;
            }
            else if (GameBoard[coord.x,coord.y].id == "\u265A")
            {
                Console.Write("\u265A");
                King piece = new King(Piece.Color.white);
                List<Coord> coordDestination = piece.GetPossibleMoves(GameBoard, coord);
                return coordDestination;
            }
            else if (GameBoard[coord.x,coord.y].id == "\u2656")
            {
                Console.Write("\u2656");
                Rook piece = new Rook(Piece.Color.black);
                List<Coord> coordDestination = piece.GetPossibleMoves(GameBoard, coord);
                return coordDestination;
            }
            else if (GameBoard[coord.x,coord.y].id == "\u265C")
            {
                Console.Write("\u265C");
                Rook piece = new Rook(Piece.Color.white);
                List<Coord> coordDestination = piece.GetPossibleMoves(GameBoard, coord);
                return coordDestination;
            }
            else if (GameBoard[coord.x,coord.y].id == "\u2655")
            {
                Console.Write("\u2655");
                Queen piece = new Queen(Piece.Color.black);
                List<Coord> coordDestination = piece.GetPossibleMoves(GameBoard, coord);
                return coordDestination;
            }
            else if (GameBoard[coord.x,coord.y].id == "\u265B")
            {
                Console.Write("\u265B");
                Queen piece = new Queen(Piece.Color.white);
                List<Coord> coordDestination = piece.GetPossibleMoves(GameBoard, coord);
                return coordDestination;
            }
            else if (GameBoard[coord.x,coord.y].id == "\u2657")
            {
                Console.Write("\u2657");
                Bishop piece = new Bishop(Piece.Color.black);
                List<Coord> coordDestination = piece.GetPossibleMoves(GameBoard, coord);
                return coordDestination;
            }
            else if (GameBoard[coord.x, coord.y].id == "\u265D")
            {
                Console.Write("\u265D");
                Bishop piece = new Bishop(Piece.Color.white);
                List<Coord> coordDestination = piece.GetPossibleMoves(GameBoard, coord);
                return coordDestination;
            }
            else
            {
                return null;
            }
        }

        public Coord ChooseWhereMovePiece(List<Coord> move)
        {
            bool confirm = false;
            
            foreach (Coord co in move)
            {
                Console.Write("\nMove:[" + co.x + ":" + co.y + "] \n");
            }
            
            Console.Write("\n" + "[A..H]: ");
            string X = Console.ReadLine();
            int x = 0;
            switch (X)
            {
                case "A":
                case "a":
                    x = 1;
                    break;
                case "B":
                case "b":
                    x = 2;
                    break;
                case "C":
                case "c":
                    x = 3;
                    break;
                case "D":
                case "d":
                    x = 4;
                    break;
                case "E":
                case "e":
                    x = 5;
                    break;
                case "F":
                case "f":
                    x = 6;
                    break;
                case "G":
                case "g":
                    x = 7;
                    break;
                case "H":
                case "h":
                    x = 8;
                    break;
            }
            
            Console.Write("\n" + "[1..8]:");
            int y = int.Parse(Console.ReadLine());
            
            Coord coord = new Coord(x, y);
            
            foreach (Coord co in move)
            {
                if (x == co.x && y == co.y)
                {
                    confirm = true;
                }
            }
            if (confirm == true)
            {
                return coord;
            }
            else
            {
                return null;
            }
        }
        
        public void MovePiece(Coord coordPiece, Coord coordDestination, Piece.Color color)
        {
            if (GameBoard[coordDestination.x,coordDestination.y] != null && GameBoard[coordDestination.x, coordDestination.y].id == "\u2654" || GameBoard[coordDestination.x,coordDestination.y] != null &&
                GameBoard[coordDestination.x, coordDestination.y].id == "\u265A")
            {
                Console.Write(color+" Win");
                StartGame();
            }
            GameBoard[coordDestination.x, coordDestination.y] = GameBoard[coordPiece.x, coordPiece.y];
            GameBoard[coordPiece.x, coordPiece.y] = null;
        }
    }
}