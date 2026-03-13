using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Spells;

public class PowerPotion : ISpell
{
    public ICreature Apply(ICreature creature)
    {
        ICreature copied = creature.Clone();

        copied.ChangeAttack(new Attack(creature.Attack.Value + 5));

        return copied;
    }
}