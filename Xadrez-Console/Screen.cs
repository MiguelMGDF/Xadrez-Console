using System;
using board;


namespace Xadrez_Console
{
    public class Screen
    {
        public static void printBoard(Board board){

            for (int i=0; i<board.linhas; i++){
                System.Console.Write(8-i + "     ");
                for (int j=0; j<board.colunas; j++){
                    if (board.piece(i,j) == null){
                        System.Console.Write("-  ");
                    }
                    else
                    {
                        Screen.printPiece(board.piece(i, j));
                        System.Console.Write("  ");
                    }
                    
                
                }
                System.Console.WriteLine();
            }

            System.Console.WriteLine("\n      a  b  c  d  e  f  g  h");
        }

        public static void printPiece(Piece piece){
            if (piece.color == Color.White){
                System.Console.Write(piece);
            }
            else {
                ConsoleColor aux = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;
                System.Console.Write(piece);
                Console.ForegroundColor = aux;
            }
        }
    }
}