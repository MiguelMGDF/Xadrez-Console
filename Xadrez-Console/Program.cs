using System;
using board;
using chess;

namespace Xadrez_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            try {

                ChessMatch chessMatch = new ChessMatch();

                while (!chessMatch.ended){
                    Console.Clear();
                    Screen.printBoard(chessMatch.board);

                    System.Console.Write("\nOrigin: ");
                    Position origin = Screen.readChessPosition().toPosition();

                    Console.Clear();

                    bool[,] possiblePositions = chessMatch.board.piece(origin).possibleMovements();
                    Screen.printBoard(chessMatch.board, possiblePositions);

                    System.Console.Write("\nDestiny: ");
                    Position destiny = Screen.readChessPosition().toPosition();

                    chessMatch.performMovement(origin, destiny);
                }

                Screen.printBoard(chessMatch.board);

                Console.ReadLine();
            }
            catch(BoardException e){
                System.Console.WriteLine(e.Message);
            }

        }
    }
}