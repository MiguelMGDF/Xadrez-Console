using System;
using board;


namespace chess
{
    class Rook : Piece
    {
        public Rook(Board board, Color color) : base(board, color){

        }

        public override string ToString()
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            return "\u2656";
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

            while(board.validPos(pos) && canMove(pos)){
                mat[pos.Linha, pos.Coluna] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color){
                    break;
                }
                pos.Linha = pos.Linha - 1;
            }

            pos.defineValue(position.Linha + 1, position.Coluna);
            while(board.validPos(pos) && canMove(pos)){
                mat[pos.Linha, pos.Coluna] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color){
                    break;
                }
                pos.Linha = pos.Linha + 1;
            }

            pos.defineValue(position.Linha, position.Coluna - 1);
            while(board.validPos(pos) && canMove(pos)){
                mat[pos.Linha, pos.Coluna] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color){
                    break;
                }
                pos.Coluna = pos.Coluna - 1;
            }

            pos.defineValue(position.Linha, position.Coluna + 1);
            while(board.validPos(pos) && canMove(pos)){
                mat[pos.Linha, pos.Coluna] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color){
                    break;
                }
                pos.Coluna = pos.Coluna + 1;
            }

            return mat;
        }
    }
}