using System;
using board;


namespace chess
{
    class Knight : Piece
    {
        public Knight(Board board, Color color) : base(board, color){

        }

        public override string ToString()
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            return "\u2658";
        }

        private bool canMove(Position pos){
            Piece p = board.piece(pos);
            return p == null || p.color != color;
        }

        public override bool[,] possibleMovements(){
            bool[,] mat = new bool[board.linhas, board.colunas];
            Position pos = new Position(0,0);

            pos.defineValue(position.Linha - 1, position.Coluna - 2);
            if (board.validPos(pos) && canMove(pos)){
                mat[pos.Linha, pos.Coluna] = true; 
            }

            pos.defineValue(position.Linha - 2, position.Coluna - 1);
            if (board.validPos(pos) && canMove(pos)){
                mat[pos.Linha, pos.Coluna] = true; 
            }

            pos.defineValue(position.Linha - 2, position.Coluna + 1);
            if (board.validPos(pos) && canMove(pos)){
                mat[pos.Linha, pos.Coluna] = true; 
            }

            pos.defineValue(position.Linha - 1, position.Coluna + 2);
            if (board.validPos(pos) && canMove(pos)){
                mat[pos.Linha, pos.Coluna] = true; 
            }

            pos.defineValue(position.Linha + 1, position.Coluna + 2);
            if (board.validPos(pos) && canMove(pos)){
                mat[pos.Linha, pos.Coluna] = true; 
            }

            pos.defineValue(position.Linha + 2, position.Coluna + 1);
            if (board.validPos(pos) && canMove(pos)){
                mat[pos.Linha, pos.Coluna] = true; 
            }

            pos.defineValue(position.Linha + 2, position.Coluna - 1);
            if (board.validPos(pos) && canMove(pos)){
                mat[pos.Linha, pos.Coluna] = true; 
            }

            pos.defineValue(position.Linha + 1, position.Coluna - 2);
            if (board.validPos(pos) && canMove(pos)){
                mat[pos.Linha, pos.Coluna] = true; 
            }
            
            return mat;
        }
    }
}