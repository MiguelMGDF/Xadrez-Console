using System;


namespace chess
{
    public class ChessPosition
    {
        
        public char column { get; set; }
        public int line { get; set; }

        public ChessPosition(char column, int line){
            this.column = column;
            this.line = line;
        }

        public override string ToString()
        {
            return "" + column + line;
        }

    }
}