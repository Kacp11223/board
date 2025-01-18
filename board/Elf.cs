namespace board;

public class Elf : Creature
{
    public override string ImagePath => "/images/elf.png";

    public Elf(string name, int row, int column) : base(name, row, column) { }

    public override void Move(int rows, int columns, Random random)
    {
        Row = (Row + random.Next(-1, 2) + rows) % rows;
        Column = (Column + random.Next(-1, 2) + columns) % columns;
    }
}
