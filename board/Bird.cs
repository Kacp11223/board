namespace board;

public class Bird : Creature
{
    public override string ImagePath => "/images/bird.png";

    public Bird(string name, int row, int column) : base(name, row, column) { }

    public override void Move(int rows, int columns, Random random)
    {
        Row = (Row + random.Next(-2, 3) + rows) % rows;
        Column = (Column + random.Next(-2, 3) + columns) % columns;
    }
}
