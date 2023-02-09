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
                    try{
                        Console.Clear();
                        Screen.printMatch(chessMatch);

                        System.Console.Write("\nOrigin: ");
                        Position origin = Screen.readChessPosition().toPosition();
                        chessMatch.validateOriginPosition(origin);

                        Console.Clear();

                        bool[,] possiblePositions = chessMatch.board.piece(origin).possibleMovements();
                        Screen.printBoard(chessMatch.board, possiblePositions);

                        System.Console.Write("\nDestiny: ");
                        Position destiny = Screen.readChessPosition().toPosition();
                        chessMatch.validateDestinyPosition(origin, destiny);

                        chessMatch.makePlay(origin, destiny);
                    }
                    catch (BoardException e){
                        System.Console.WriteLine(e.Message);
                        System.Console.ReadLine();
                    }
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