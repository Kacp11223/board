namespace board;

public class GameBoard
{
    private const int Rows = 8;
    private const int Columns = 8;
    public Cell[,] Board { get; private set; }
    public List<Creature> Creatures { get; private set; } = new List<Creature>();
    private Random _random = new Random();

    public GameBoard()
    {
        Board = new Cell[Rows, Columns];
        for (int i = 0; i < Rows; i++)
        {
            for (int j = 0; j < Columns; j++)
            {
                Board[i, j] = new Cell();
            }
        }
        InitializeCreatures();
    }

    private void InitializeCreatures()
    {
        Creatures.Add(new Orc("Gruk", 0, 0));
        Creatures.Add(new Elf("Elanor", 1, 1));
        Creatures.Add(new Bird("Eagle", 2, 2));
        Creatures.Add(new FlightlessBird("Ostrich", 3, 3));
        PlaceCreaturesOnBoard();
    }

    private void PlaceCreaturesOnBoard()
    {
        foreach (var creature in Creatures)
        {
            Board[creature.Row, creature.Column].AddCreature(creature);
        }
    }

    public void MoveCreatures()
    {
        foreach (var creature in Creatures.ToList())
        {
            Board[creature.Row, creature.Column].RemoveCreature(creature);
            creature.Move(Rows, Columns, _random);

            // Check for mines
            var cell = Board[creature.Row, creature.Column];
            if (cell.HasMine)
            {
                Creatures.Remove(creature); // Remove creature if it steps on a mine
            }
            else
            {
                cell.AddCreature(creature);
            }
        }
    }

    public void PlaceMine(int row, int column)
    {
        Board[row, column].PlaceMine();
    }
}