using Itmo.ObjectOrientedProgramming.Lab3.Creatures;

namespace Itmo.ObjectOrientedProgramming.Lab3.Modifiers.Factories;

public class MagicShieldFactory : IModifierFactory
{
    public ICreature CreateModifier(ICreature creature)
    {
        return new MagicShield(creature);
    }
}