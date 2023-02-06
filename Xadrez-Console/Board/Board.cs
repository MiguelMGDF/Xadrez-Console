using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace board
{
    public class Board
    {
        public int linhas { get; set; }
        public int colunas { get; set; }
        private Piece[,] pieces;

        public Board(int linhas, int colunas){
            this.linhas = linhas;
            this.colunas = colunas;
            pieces = new Piece[linhas, colunas];
        }

        public Piece piece(int linha, int coluna){
            return pieces[linha, coluna];
        }
    }
}