using System;
using Board;

namespace Xadrez_Console { 
    class Program{
        static void Main(string[] args){

            Position p;
            p = new Position(3,4);
            System.Console.WriteLine("Posicao " + p);

            Console.ReadLine();

        }
    }
}