using System.Runtime.Serialization;

namespace ConsoleGame.Players;

internal class Player : ISerializable, ICloneable, IComparable<Player>
{
    public const float MinHealth = 0;
    public const float MaxHealth = 0;
    
    public string Name { get; }
    public Guid UniqueIdentifier { get; }
    public float Health { get; set; }
    public PlayerTraits Traits { get; set; }

    public Player(string name, Guid uniqueIdentifier, float health, PlayerTraits traits)
    {
        Name = name;
        UniqueIdentifier = uniqueIdentifier;
        Health = health;
        Traits = traits;
    }

    public void GetObjectData(SerializationInfo info, StreamingContext context)
    {
        throw new NotImplementedException();
    }

    public object Clone()
    {
        throw new NotImplementedException();
    }

    public int CompareTo(Player? other)
    {
        if (other == null)
            return -1;
        if (this.UniqueIdentifier == other.UniqueIdentifier)
            return 0;
        return string.CompareOrdinal(this.Name, other.Name);
    }
}