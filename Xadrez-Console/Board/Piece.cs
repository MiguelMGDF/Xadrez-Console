using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace board
{
    public class Piece
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
    }
}