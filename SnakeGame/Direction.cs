namespace SnakeGame
{
   public class Direction
    {
       private int RowOffset { get; }
       private int ColOffset { get; }

        public Direction(int rowOffset, int colOffset)
        {
            RowOffset = rowOffset;
            ColOffset = colOffset;
        }
    }
}
