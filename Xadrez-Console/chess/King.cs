using System;
using board;
using chess;

namespace chess
{
    class King : Piece
    {

        private ChessMatch chessMatch;

        public King(Board board, Color color, ChessMatch chessMatch) : base(board, color){
            this.chessMatch = chessMatch;
        }

        public override string ToString()
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            return "\u2654";
        }

        private bool canMove(Position pos){
            Piece p = board.piece(pos);
            return p == null || p.color != color;
        }

        private bool testRookToCastling(Position pos){
            Piece p = board.piece(pos);
            return p != null && p is Rook && p.color == color && p.movements == 0;
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

            //Jogada especial roque
            if (movements == 0 && !chessMatch.check){
                //Roque pequeno
                Position posR1 = new Position(position.Linha, position.Coluna + 3);
                if (testRookToCastling(posR1)){
                    Position p1 = new Position(position.Linha, position.Coluna + 1);
                    Position p2 = new Position(position.Linha, position.Coluna + 2);
                    if (board.piece(p1) == null && board.piece(p2) == null){
                        mat[position.Linha, position.Coluna + 2] = true;
                    }
                }

                //Roque grande
                Position posR2 = new Position(position.Linha, position.Coluna - 4);
                if (testRookToCastling(posR2)){
                    Position p1 = new Position(position.Linha, position.Coluna - 1);
                    Position p2 = new Position(position.Linha, position.Coluna - 2);
                    Position p3 = new Position(position.Linha, position.Coluna - 3);
                    if (board.piece(p1) == null && board.piece(p2) == null && board.piece(p3) == null){
                        mat[position.Linha, position.Coluna + 2] = true;
                    }
                }
            }

            return mat;
        }

    }
}