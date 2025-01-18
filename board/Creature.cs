namespace board;

public abstract class Creature
{
    public string Name { get; private set; }
    public int Row { get; protected set; }
    public int Column { get; protected set; }
    public abstract string ImagePath { get; }

    protected Creature(string name, int row, int column)
    {
        Name = name;
        Row = row;
        Column = column;
    }

    public abstract void Move(int rows, int columns, Random random);
}
