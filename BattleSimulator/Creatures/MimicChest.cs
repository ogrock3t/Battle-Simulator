using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures;

public class MimicChest : BaseCreature
{
    public MimicChest(Attack attack, Health health)
        : base(attack, health) { }

    public override void AttackCreature(ICreature opponent)
    {
        Attack = new Attack(Math.Max(Attack.Value, opponent.Attack.Value));
        Health = new Health(Math.Max(Health.Value, opponent.Health.Value));

        opponent.TakeDamage(Attack.Value);
    }

    public override ICreature Clone()
    {
        return new MimicChest(Attack, Health);
    }
}