namespace board;

public class Cell
{
    public List<Creature> Creatures { get; private set; } = new List<Creature>();
    public bool HasMine { get; private set; } = false;

    public void AddCreature(Creature creature)
    {
        Creatures.Add(creature);
    }

    public void RemoveCreature(Creature creature)
    {
        Creatures.Remove(creature);
    }

    public void PlaceMine()
    {
        HasMine = true;
    }
}