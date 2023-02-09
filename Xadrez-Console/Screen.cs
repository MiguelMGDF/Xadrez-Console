using System;
using board;
using chess;


namespace Xadrez_Console
{
    class Screen
    {
        public static void printBoard(Board board){

            for (int i=0; i<board.linhas; i++){
                System.Console.Write(8-i + "     ");
                for (int j=0; j<board.colunas; j++){
                    printPiece(board.piece(i, j));                
                }
                System.Console.WriteLine();
            }

            System.Console.WriteLine("\n      a  b  c  d  e  f  g  h");
        }

        public static void printBoard(Board board, bool[,] possiblePositions){
            
            ConsoleColor background = Console.BackgroundColor;
            ConsoleColor newBackground = ConsoleColor.DarkGray;
            
            for (int i=0; i<board.linhas; i++){
                System.Console.Write(8-i + "     ");
                for (int j=0; j<board.colunas; j++){
                    if (possiblePositions[i,j]){
                        Console.BackgroundColor = newBackground;
                    }
                    else{
                        Console.BackgroundColor = background;
                    }
                    printPiece(board.piece(i, j));
                    Console.BackgroundColor = background;
                }
                System.Console.WriteLine();
            }

            System.Console.WriteLine("\n      a  b  c  d  e  f  g  h");
            Console.BackgroundColor = background;
        }

        public static void printPiece(Piece piece){

            if (piece == null){
                System.Console.Write("-  ");
            }
            else{ 
                if (piece.color == Color.White){
                    System.Console.Write(piece);
                }
                else {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    System.Console.Write(piece);
                    Console.ForegroundColor = aux;
                }
                System.Console.Write("  ");
            }
        }

        public static ChessPosition readChessPosition(){
            string s = Console.ReadLine();
            char column = s[0];
            int line = int.Parse(s[1] + "");
            return new ChessPosition(column, line);
        }
    }
}