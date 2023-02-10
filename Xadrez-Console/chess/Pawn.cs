using System;
using board;
using chess;

namespace chess
{
    class Pawn : Piece
    {
        public Pawn(Board board, Color color) : base(board, color){

        }

        public override string ToString()
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            return "\u2659";
        }

        private bool existEnemy(Position pos){
            Piece p = board.piece(pos);
            return p != null && p.color != color;
        }

        public bool free(Position pos){
            return board.piece(pos) == null;
        }

        public override bool[,] possibleMovements(){
            bool[,] mat = new bool[board.linhas, board.colunas];
            Position pos = new Position(0,0);

            if (color == Color.White){
                pos.defineValue(position.Linha - 1, position.Coluna);
                if (board.validPos(pos) && free(pos)){
                    mat[pos.Linha, pos.Coluna] = true;
                }

                pos.defineValue(position.Linha - 2, position.Coluna);
                Position p2 = new Position(pos.Linha - 1, pos.Coluna);
                if (board.validPos(p2) && free(p2) && board.validPos(pos) && free(pos) && movements == 0){
                    mat[pos.Linha, pos.Coluna] = true;
                }

                pos.defineValue(position.Linha -1, position.Coluna - 1);
                if (board.validPos(pos) && existEnemy(pos)){
                    mat[pos.Linha, pos.Coluna] = true;
                }

                pos.defineValue(position.Linha -1, position.Coluna + 1);
                if (board.validPos(pos) && existEnemy(pos)){
                    mat[pos.Linha, pos.Coluna] = true;
                }
            }


            else {
                pos.defineValue(position.Linha + 1, position.Coluna);
                if (board.validPos(pos) && free(pos)){
                    mat[pos.Linha, pos.Coluna] = true;
                }

                pos.defineValue(position.Linha + 2, position.Coluna);
                Position p2 = new Position(pos.Linha - 1, pos.Coluna);
                if (board.validPos(p2) && free(p2) && board.validPos(pos) && free(pos) && movements == 0){
                    mat[pos.Linha, pos.Coluna] = true;
                }

                pos.defineValue(position.Linha +1, position.Coluna - 1);
                if (board.validPos(pos) && existEnemy(pos)){
                    mat[pos.Linha, pos.Coluna] = true;
                }

                pos.defineValue(position.Linha +1, position.Coluna + 1);
                if (board.validPos(pos) && existEnemy(pos)){
                    mat[pos.Linha, pos.Coluna] = true;
                }
            }
            return mat;
        }

    }
}