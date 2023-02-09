using System;
using System.Collections.Generic;
using board;

namespace chess
{
    class ChessMatch
    {
        public Board board { get; private set; }
        public int turn { get; private set; }
        public Color currentPlayer { get; private set; }
        public bool ended {get; private set; }
        private HashSet<Piece> pieces;
        private HashSet<Piece> capturedPieces;

        public ChessMatch(){
            board = new Board(8, 8);
            turn = 1;
            currentPlayer = Color.White;
            ended = false;
            pieces = new HashSet<Piece>();
            capturedPieces = new HashSet<Piece>();
            putPieces();
        }

        public void performMovement(Position origin, Position destiny){
            Piece p = board.removePiece(origin);
            p.incrementMovements();
            Piece capturedPiece = board.removePiece(destiny);
            ended = false;
            board.putPiece(p, destiny);
            if (capturedPiece != null){
                capturedPieces.Add(capturedPiece);
            }
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

        public HashSet<Piece> CapturedPieces(Color color){
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach(Piece x in capturedPieces){
                if (x.color == color){
                    aux.Add(x);
                }
            }
            return aux;
        }

        public HashSet<Piece> ingamePieces(Color color){
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach(Piece x in capturedPieces){
                if (x.color == color){
                    aux.Add(x);
                }
            }
            aux.ExceptWith(CapturedPieces(color));
            return aux;
        }

        public void putNewPiece(char column, int line, Piece piece){
            board.putPiece(piece, new ChessPosition(column, line).toPosition());
            pieces.Add(piece);
        }

        private void putPieces(){
            putNewPiece('c', 1, new Rook(board, Color.White));
            putNewPiece('c', 2,new King(board, Color.Black));
            putNewPiece('c', 3,new Rook(board, Color.White));
            putNewPiece('c', 4,new King(board, Color.Black));            
            }
    }
}