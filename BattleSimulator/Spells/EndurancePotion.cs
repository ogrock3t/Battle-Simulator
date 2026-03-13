using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Spells;

public class EndurancePotion : ISpell
{
    public ICreature Apply(ICreature creature)
    {
        ICreature copied = creature.Clone();

        copied.ChangeHealth(new Health(creature.Health.Value + 5));

        return copied;
    }
}