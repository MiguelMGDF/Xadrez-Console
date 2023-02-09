using System;
using board;

namespace chess
{
    class ChessMatch
    {
        public Board board { get; private set; }
        public int turn { get; private set; }
        public Color currentPlayer { get; private set; }
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

        public void makePlay(Position origin, Position destiny){
            performMovement(origin, destiny);
            turn++;
            changePlayer();
        }

        public void validateOriginPosition(Position pos){
            if (board.piece(pos) == null){
                throw new BoardException("There is no piece in the origin position");
            }
            if (currentPlayer != board.piece(pos).color){
                throw new BoardException("The piece from origin is not yours");
            }
            if (!board.piece(pos).possibleMovementExist()){
                throw new BoardException("There is no possible movements for the piece in origin");
            }
        }

        public void validateDestinyPosition(Position origin, Position destiny){

            if (!board.piece(origin).canMoveTo(destiny)){
                throw new BoardException("Invalid destiny position!");
            }

        }

        private void changePlayer(){
            if (currentPlayer == Color.White){
                currentPlayer = Color.Black;
            }
            else{
                currentPlayer = Color.White;
            }
        }

        private void putPieces(){
            board.putPiece(new Rook(board, Color.White), new ChessPosition('c', 1).toPosition());
            board.putPiece(new King(board, Color.Black), new ChessPosition('d', 1).toPosition());
            board.putPiece(new Rook(board, Color.White), new ChessPosition('e', 1).toPosition());
            board.putPiece(new Rook(board, Color.Black), new ChessPosition('f', 1).toPosition());        
            
            }
    }
}