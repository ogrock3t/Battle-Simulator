using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.Table.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab3.Table;

public class PlayerBoard
{
    private readonly List<ICreature> _creatures;

    public PlayerBoard(IEnumerable<ICreature> creatures)
    {
        _creatures = creatures.ToList();
    }

    public ICreature? FindAttacker()
    {
        return _creatures.FirstOrDefault(creature => creature.Health.Value > 0);
    }

    public ICreature? FindDefender()
    {
        return _creatures.FirstOrDefault(creature => creature.Health.Value > 0);
    }

    public PlayerBoard Clone()
    {
        var builder = new PlayerBoardBuilder();

        foreach (ICreature creature in _creatures)
        {
            builder.WithCreature(creature);
        }

        return builder.Build();
    }
}