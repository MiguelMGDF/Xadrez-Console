using System;

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

        public Piece piece(Position pos){
            return pieces[pos.Linha, pos.Coluna];
        }

        public bool existPiece(Position pos){
            validatePos(pos);
            return piece(pos) != null;
        }        

        public void putPiece(Piece p, Position pos){
            if (existPiece(pos)){
                throw new BoardException("Já existe uma peça nessa posição!")
            }
            pieces[pos.Linha, pos.Coluna] = p;
            p.position = pos;
        }

        public bool validPos(Position pos){
            if (pos.Linha < 0 || pos.Linha >= linhas || pos.Coluna < 0 || pos.Coluna >= colunas){
                return false;
            }
            return true;
        }

        public void validatePos(Position pos){
            if (!validPos(pos)){

                throw new BoardException("Posição inválida");

            }
        }

    }
}