namespace board;

public class FlightlessBird : Creature
{
    public override string ImagePath => "/images/flightlessbird.jpg";

    public FlightlessBird(string name, int row, int column) : base(name, row, column) { }

    public override void Move(int rows, int columns, Random random)
    {
        Row = (Row + 1 + rows) % rows;
        Column = (Column + 1 + columns) % columns;
    }
}
