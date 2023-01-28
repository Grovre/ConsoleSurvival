namespace ConsoleGame.Players;

internal class PlayerBuilder
{
    public string? Name { get; set; }
    public Guid? UniqueIdentifier { get; set; }
    public float? Health { get; set; }
    public PlayerTraits? Traits { get; set; }

    public PlayerBuilder()
    {
    }

    public Player Build()
    {
        return new Player(
            Name ?? "Name",
            UniqueIdentifier ?? Guid.NewGuid(),
            Health ?? 100F,
            Traits ?? new PlayerTraits());
    }

    public PlayerBuilder SetName(string name)
    {
        Name = name;
        return this;
    }

    public PlayerBuilder SetIdentifier(Guid identifier)
    {
        UniqueIdentifier = identifier;
        return this;
    }

    public PlayerBuilder SetHealth(float hp)
    {
        Health = hp;
        return this;
    }

    public PlayerBuilder SetTraits(PlayerTraits traits)
    {
        Traits = traits;
        return this;
    }
}