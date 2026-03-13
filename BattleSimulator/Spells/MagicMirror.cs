using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Spells;

public class MagicMirror : ISpell
{
    public ICreature Apply(ICreature creature)
    {
        int initialAttack = creature.Attack.Value;
        int initialHealth = creature.Health.Value;

        creature.ChangeAttack(new Attack(initialHealth));
        creature.ChangeHealth(new Health(initialAttack));

        return creature;
    }
}