using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures;

public class ImmortalHorror : BaseCreature
{
    private bool _reborn;

    public ImmortalHorror(Attack attack, Health health, bool reborn = false)
        : base(attack, health)
    {
        _reborn = reborn;
    }

    public override void TakeDamage(int damage)
    {
        Health = new Health(Health.Value - damage);

        if (Health.Value > 0)
            return;

        if (_reborn)
            return;

        Health = new Health(1);

        _reborn = true;

        if (Health.Value <= 0)
            Health = new Health(0);
    }

    public override ICreature Clone()
    {
        return new ImmortalHorror(Attack, Health, _reborn);
    }
}