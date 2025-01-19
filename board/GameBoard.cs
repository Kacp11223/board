namespace board;

public class GameBoard
{
    private const int Rows = 8;
    private const int Columns = 8;
    private const int MaxMines = 4;
    public Cell[,] Board { get; private set; }
    public List<Creature> Creatures { get; private set; } = new List<Creature>();
    private Random _random = new Random();
    private int _currentMines = 0;

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

    public bool CanPlaceMine(int row, int column)
    {
        return _currentMines < MaxMines && Board[row, column].Creatures.Count == 0;
    }

    public bool PlaceMine(int row, int column)
    {
        if (CanPlaceMine(row, column))
        {
            Board[row, column].PlaceMine();
            _currentMines++;
            return true;
        }
        return false;
    }

    public void ClearAllMines()
    {
        for (int i = 0; i < Rows; i++)
        {
            for (int j = 0; j < Columns; j++)
            {
                if (Board[i, j].HasMine)
                {
                    Board[i, j].RemoveMine();
                }
            }
        }
        _currentMines = 0;
    }

    public void MoveCreatures()
    {
        foreach (var creature in Creatures.ToList())
        {
            Board[creature.Row, creature.Column].RemoveCreature(creature);
            creature.Move(Rows, Columns, _random);
            Board[creature.Row, creature.Column].AddCreature(creature);
        }

        // Minec check
        foreach (var creature in Creatures.ToList())
        {
            var cell = Board[creature.Row, creature.Column];
            if (cell.HasMine)
            {
                cell.RemoveCreature(creature);
                Creatures.Remove(creature);
            }
        }

        // Mine clear
        ClearAllMines();
    }

    public int GetCurrentMines()
    {
        return _currentMines;
    }
}