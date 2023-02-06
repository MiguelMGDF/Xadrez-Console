using System;
using board;


namespace Xadrez_Console
{
    public class Screen
    {
        public static void printBoard(Board board){

            for (int i=0; i<board.linhas; i++){
                for (int j=0; j<board.colunas; j++){
                    if (board.piece(i,j) == null){
                        System.Console.Write("- ");
                    }
                    System.Console.Write(board.piece(i, j) + " ");
                
                }
                System.Console.WriteLine();
            }

        }
    }
}