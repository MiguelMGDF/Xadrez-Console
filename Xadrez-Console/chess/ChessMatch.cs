using System;
using board;

namespace chess
{
    class ChessMatch
    {
        public Board board { get; private set; }
        private int turn;
        private Color currentPlayer;
        public bool ended {get; private set; }

        public ChessMatch(){
            board = new Board(8, 8);
            turn = 1;
            currentPlayer = Color.White;
            ended = false;
            putPieces();
        }

        public void performMovement(Position origin, Position destiny){
            Piece p = board.removePiece(origin);
            p.incrementMovements();
            Piece capturedPiece = board.removePiece(destiny);
            ended = false;
            board.putPiece(p, destiny);
        }

        private void putPieces(){
            board.putPiece(new Rook(board, Color.White), new ChessPosition('c', 1).toPosition());
            board.putPiece(new King(board, Color.Black), new ChessPosition('d', 1).toPosition());
            board.putPiece(new Rook(board, Color.White), new ChessPosition('e', 1).toPosition());
            board.putPiece(new Rook(board, Color.Black), new ChessPosition('f', 1).toPosition());        
            
            }
    }
}