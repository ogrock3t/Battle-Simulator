using Itmo.ObjectOrientedProgramming.Lab3.Creatures;

namespace Itmo.ObjectOrientedProgramming.Lab3.Table.Builders;

public class PlayerBoardBuilder
{
    private const int MaxCreatures = 7;

    private readonly List<ICreature> _creatures = new List<ICreature>();

    public PlayerBoardBuilder WithCreature(ICreature creature)
    {
        if (_creatures.Count >= MaxCreatures)
            throw new ArgumentException("There can be no more than 7 creatures on the table", nameof(creature));

        _creatures.Add(creature);
        return this;
    }

    public PlayerBoard Build() => new PlayerBoard(_creatures.ToArray());
}