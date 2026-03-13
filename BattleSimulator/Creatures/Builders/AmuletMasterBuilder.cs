using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures.Builders;

public class AmuletMasterBuilder : BaseCreatureBuilder
{
    public override ICreature Create(Attack attack, Health health)
    {
        return new AmuletMaster(attack, health);
    }
}