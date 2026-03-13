using Itmo.ObjectOrientedProgramming.Lab3.Creatures;

namespace Itmo.ObjectOrientedProgramming.Lab3.Catalog;

public class CreatureCatalog
{
    private readonly Dictionary<string, ICreature> _creatures = new();

    public void Add(string name, ICreature creature)
    {
        _creatures[name] = creature;
    }

    public ICreature Get(string name)
    {
        return _creatures[name];
    }
}