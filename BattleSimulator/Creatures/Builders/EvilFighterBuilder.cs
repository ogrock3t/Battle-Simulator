using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures.Builders;

public class EvilFighterBuilder : BaseCreatureBuilder
{
    public override ICreature Create(Attack attack, Health health)
    {
        return new EvilFighter(attack, health);
    }
}