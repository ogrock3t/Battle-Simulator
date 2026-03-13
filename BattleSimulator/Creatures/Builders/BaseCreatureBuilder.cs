using Itmo.ObjectOrientedProgramming.Lab3.Modifiers.Factories;
using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures.Builders;

public abstract class BaseCreatureBuilder : ICreatureBuilder
{
    private readonly List<IModifierFactory> _modifierFactories = new List<IModifierFactory>();

    private Attack? _attack;
    private Health? _health;

    public BaseCreatureBuilder WithAttack(int value)
    {
        _attack = new Attack(value);
        return this;
    }

    public BaseCreatureBuilder WithHealth(int value)
    {
        _health = new Health(value);
        return this;
    }

    public BaseCreatureBuilder AddModifier(IModifierFactory modifierFactory)
    {
        _modifierFactories.Add(modifierFactory);
        return this;
    }

    public abstract ICreature Create(Attack attack, Health health);

    public ICreature Build()
    {
        if (_attack == null)
            throw new InvalidOperationException("Attack must be  set before building this creature.");

        if (_health == null)
            throw new InvalidOperationException("Health must be  set before building this creature.");

        ICreature creature = Create(_attack, _health);

        foreach (IModifierFactory modifierFactory in _modifierFactories)
        {
            creature = modifierFactory.CreateModifier(creature);
        }

        return creature;
    }
}