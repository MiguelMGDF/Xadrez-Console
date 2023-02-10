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
        public bool check { get; private set; }

        public ChessMatch(){
            board = new Board(8, 8);
            turn = 1;
            currentPlayer = Color.White;
            ended = false;
            check = false;
            pieces = new HashSet<Piece>();
            capturedPieces = new HashSet<Piece>();
            putPieces();
        }

        public Piece performMovement(Position origin, Position destiny){
            Piece p = board.removePiece(origin);
            p.incrementMovements();
            Piece capturedPiece = board.removePiece(destiny);
            ended = false;
            board.putPiece(p, destiny);
            if (capturedPiece != null){
                capturedPieces.Add(capturedPiece);
            }

            //Roque pequeno
            if (p is King && destiny.Coluna == origin.Coluna + 2){
                Position originR = new Position(origin.Linha, origin.Coluna + 3);
                Position destinyR = new Position(origin.Linha, origin.Coluna + 1);
                Piece R = board.removePiece(originR);
                R.incrementMovements();
                board.putPiece(R, destinyR);
            }

            //Roque grande
            if (p is King && destiny.Coluna == origin.Coluna - 2){
                Position originR = new Position(origin.Linha, origin.Coluna - 4);
                Position destinyR = new Position(origin.Linha, origin.Coluna - 1);
                Piece R = board.removePiece(originR);
                R.incrementMovements();
                board.putPiece(R, destinyR);
            }
            return capturedPiece;
        }
            

        public void undoMovement(Position origin, Position destiny, Piece capturedPiece){
            Piece p = board.removePiece(destiny);
            p.decrementMovements();
            if (capturedPiece != null){
                board.putPiece(capturedPiece, destiny);
                capturedPieces.Remove(capturedPiece);
            }
            board.putPiece(p, origin);

            //Roque pequeno
            if (p is King && destiny.Coluna == origin.Coluna + 2){
                Position originR = new Position(origin.Linha, origin.Coluna + 3);
                Position destinyR = new Position(origin.Linha, origin.Coluna + 1);
                Piece R = board.removePiece(destinyR);
                R.decrementMovements();
                board.putPiece(R, originR);
            }
        }

        public void makePlay(Position origin, Position destiny){
            Piece capturedPiece = performMovement(origin, destiny);

            if (inCheck(currentPlayer)){
                undoMovement(origin, destiny, capturedPiece);
                throw new BoardException("You can't put yourself in Check");
            }

            if (inCheck(enemy(currentPlayer))){
                check = true;
            }
            else {
                check = false;
            }

            if (testCheckmate(enemy(currentPlayer))){
                ended = true;
            }
            else{
                turn++;
                changePlayer();
            }
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
            foreach(Piece x in pieces){
                if (x.color == color){
                    aux.Add(x);
                }
            }
            aux.ExceptWith(CapturedPieces(color));
            return aux;
        }

        private Color enemy(Color color){
            if (color == Color.White){
                return Color.Black;
            }
            else {
                return Color.White;
            }
        }

        private Piece king(Color color){
            foreach (Piece x in ingamePieces(color)){
                if (x is King){
                    return x;
                }
            }
            return null;
        }

        public bool inCheck(Color color){
            Piece K = king(color);
            if (K == null){
                throw new BoardException("King from color " + color + " does not exist");
            }
            foreach (Piece x in ingamePieces(enemy(color))){
                bool[,] mat = x.possibleMovements();
                if (mat[K.position.Linha, K.position.Coluna]){
                    return true;
                }
            }
            return false;
        }

        public bool testCheckmate(Color color){
            if (!inCheck(color)){
                return false;
            }
            foreach(Piece x in ingamePieces(color)){
                bool[,] mat = x.possibleMovements();
                for (int i=0; i<board.linhas; i++){
                    for (int j=0; j<board.colunas; j++){
                        if(mat[i,j]){
                            Position origin = x.position;
                            Position destiny = new Position(i,j);
                            Piece capturedPiece = performMovement(origin: origin, destiny);
                            bool testCheck = inCheck(color);
                            undoMovement(origin, destiny, capturedPiece);
                            if (!testCheck){
                                return false;
                            }

                        }
                    }
                }
            }
            return true;
        }

        public void putNewPiece(char column, int line, Piece piece){
            board.putPiece(piece, new ChessPosition(column, line).toPosition());
            pieces.Add(piece);
        }

        private void putPieces(){
            putNewPiece('a', 1, new Rook(board, Color.White));
            putNewPiece('b', 1, new Knight(board, Color.White));
            putNewPiece('c', 1, new Bishop(board, Color.White));
            putNewPiece('d', 1, new Queen(board, Color.White));
            putNewPiece('e', 1, new King(board, Color.White, this));
            putNewPiece('f', 1, new Bishop(board, Color.White));
            putNewPiece('g', 1, new Knight(board, Color.White));
            putNewPiece('h', 1, new Rook(board, Color.White));
            putNewPiece('a', 2, new Pawn(board, Color.White));
            putNewPiece('b', 2, new Pawn(board, Color.White));
            putNewPiece('c', 2, new Pawn(board, Color.White));
            putNewPiece('d', 2, new Pawn(board, Color.White));
            putNewPiece('e', 2, new Pawn(board, Color.White));
            putNewPiece('f', 2, new Pawn(board, Color.White));
            putNewPiece('g', 2, new Pawn(board, Color.White));
            putNewPiece('h', 2, new Pawn(board, Color.White));

            putNewPiece('a', 8, new Rook(board, Color.Black));
            putNewPiece('b', 8, new Knight(board, Color.Black));
            putNewPiece('c', 8, new Bishop(board, Color.Black));
            putNewPiece('d', 8, new Queen(board, Color.Black));
            putNewPiece('e', 8, new King(board, Color.Black, this));
            putNewPiece('f', 8, new Bishop(board, Color.Black));
            putNewPiece('g', 8, new Knight(board, Color.Black));
            putNewPiece('h', 8, new Rook(board, Color.Black));
            putNewPiece('a', 7, new Pawn(board, Color.Black));
            putNewPiece('b', 7, new Pawn(board, Color.Black));
            putNewPiece('c', 7, new Pawn(board, Color.Black));
            putNewPiece('d', 7, new Pawn(board, Color.Black));
            putNewPiece('e', 7, new Pawn(board, Color.Black));
            putNewPiece('f', 7, new Pawn(board, Color.Black));
            putNewPiece('g', 7, new Pawn(board, Color.Black));
            putNewPiece('h', 7, new Pawn(board, Color.Black));                   
            }
    }
}