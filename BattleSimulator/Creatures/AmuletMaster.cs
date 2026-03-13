using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures;

public class AmuletMaster : BaseCreature
{
    public AmuletMaster(Attack attack, Health health)
        : base(attack, health) { }

    public override ICreature Clone()
    {
        return new AmuletMaster(Attack, Health);
    }
}