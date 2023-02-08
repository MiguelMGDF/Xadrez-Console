using System;
using board;
using chess;

namespace Xadrez_Console
{
    class Program
    {
        static void Main(string[] args)
        {

            Board board = new Board(8,8);

            board.putPiece(new Rook(board, Color.White), new Position(0,0));
            board.putPiece(new King(board, Color.Black), new Position(1,3));
            board.putPiece(new Rook(board, Color.Black), new Position(2,4));

            Screen.printBoard(board);

            Console.ReadLine();

        }
    }
}