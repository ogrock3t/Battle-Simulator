using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures;

public class EvilFighter : BaseCreature
{
    public EvilFighter(Attack attack, Health health)
        : base(attack, health) { }

    public override void TakeDamage(int damage)
    {
        Health = new Health(Health.Value - damage);

        if (Health.Value > 0)
            Attack = new Attack(Attack.Value * 2);
        else
            Health = new Health(0);
    }

    public override ICreature Clone()
    {
        return new EvilFighter(Attack, Health);
    }
}