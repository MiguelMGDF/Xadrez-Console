using System;
using board;


namespace chess
{
    class Bishop : Piece
    {
        public Bishop(Board board, Color color) : base(board, color){

        }

        public override string ToString()
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            return "\u2657";
        }

        private bool canMove(Position pos){
            Piece p = board.piece(pos);
            return p == null || p.color != color;
        }

        public override bool[,] possibleMovements(){
            bool[,] mat = new bool[board.linhas, board.colunas];
            Position pos = new Position(0,0);

            //NO
            pos.defineValue(position.Linha - 1, position.Coluna - 1);
            while (board.validPos(pos) && canMove(pos)){
                mat[pos.Linha, pos.Coluna] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color){
                    break;
                }
                pos.defineValue(pos.Linha - 1, pos.Coluna - 1);
            }

            //NE
            pos.defineValue(position.Linha - 1, position.Coluna + 1);
            while (board.validPos(pos) && canMove(pos)){
                mat[pos.Linha, pos.Coluna] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color){
                    break;
                }
                pos.defineValue(pos.Linha - 1, pos.Coluna + 1);
            }

            //SE
            pos.defineValue(position.Linha + 1, position.Coluna + 1);
            while (board.validPos(pos) && canMove(pos)){
                mat[pos.Linha, pos.Coluna] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color){
                    break;
                }
                pos.defineValue(pos.Linha + 1, pos.Coluna + 1);
            }

            //SO
            pos.defineValue(position.Linha + 1, position.Coluna - 1);
            while (board.validPos(pos) && canMove(pos)){
                mat[pos.Linha, pos.Coluna] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color){
                    break;
                }
                pos.defineValue(pos.Linha + 1, pos.Coluna - 1);
            }
            
            return mat;
        }
    }
}