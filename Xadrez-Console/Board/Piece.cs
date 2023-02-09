using System;

namespace board
{
    abstract class Piece
    {
        public Position position {get; set;}
        public Color color { get; protected set; }
        public int movements { get; protected set; }
        public Board board {get; protected set;}

        public Piece(Board board, Color color){
            this.position = null;
            this.board = board;
            this.color = color;
            this.movements = 0;
        }

        public void incrementMovements(){
            movements++;
        }

        public bool possibleMovementExist(){
            bool[,] mat = possibleMovements();
            for (int i = 0; i < board.linhas; i++){
                for (int j = 0; j < board.linhas; j++){
                    if (mat[i,j]){
                        return true;
                    }
                }
            }
            return false;
        }

        public bool canMoveTo(Position pos){
            return possibleMovements()[pos.Linha, pos.Coluna];
        }

        public abstract bool[,] possibleMovements();
    }
}