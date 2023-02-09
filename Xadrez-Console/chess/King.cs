using System;
using board;
using chess;

namespace chess
{
    class King : Piece
    {
        public King(Board board, Color color) : base(board, color){

        }

        public override string ToString()
        {
            return "K";
        }

        private bool canMove(Position pos){
            Piece p = board.piece(pos);
            return p == null || p.color != color;
        }

        public override bool[,] possibleMovements(){
            bool[,] mat = new bool[board.linhas, board.colunas];
            Position pos = new Position(0,0);

            pos.defineValue(position.Linha - 1, position.Coluna);
            if (board.validPos(pos) && canMove(pos)){
                mat[pos.Linha, pos.Coluna] = true; 
            }

            pos.defineValue(position.Linha - 1, position.Coluna + 1);
            if (board.validPos(pos) && canMove(pos)){
                mat[pos.Linha, pos.Coluna] = true; 
            }

            pos.defineValue(position.Linha, position.Coluna);
            if (board.validPos(pos) && canMove(pos)){
                mat[pos.Linha, pos.Coluna] = true; 
            }

            pos.defineValue(position.Linha + 1, position.Coluna + 1);
            if (board.validPos(pos) && canMove(pos)){
                mat[pos.Linha, pos.Coluna] = true; 
            }

            pos.defineValue(position.Linha + 1, position.Coluna);
            if (board.validPos(pos) && canMove(pos)){
                mat[pos.Linha, pos.Coluna] = true; 
            }

            pos.defineValue(position.Linha + 1, position.Coluna - 1);
            if (board.validPos(pos) && canMove(pos)){
                mat[pos.Linha, pos.Coluna] = true; 
            }

            pos.defineValue(position.Linha, position.Coluna - 1);
            if (board.validPos(pos) && canMove(pos)){
                mat[pos.Linha, pos.Coluna] = true; 
            }

            pos.defineValue(position.Linha - 1, position.Coluna - 1);
            if (board.validPos(pos) && canMove(pos)){
                mat[pos.Linha, pos.Coluna] = true; 
            }

            return mat;
        }

    }
}