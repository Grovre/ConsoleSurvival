namespace ConsoleGame.Players;

public class PlayerTraits
{
    
    public const int MinLuck = 0;
    public const int MaxLuck = 100;
    
    public const int MinStrength = 0;
    public const int MaxStrength = 100;
    
    public const int MinAgility = 0;
    public const int MaxAgility = 100;
    
    public const int MinIntelligence = 0;
    public const int MaxIntelligence = 100;
    
    

    private int _luck;
    private int _strength;
    private int _agility;
    private int _intelligence;
    public int Luck
    {
        get => _luck;
        set => _luck = Math.Clamp(value, MinLuck, MaxLuck);
    }

    public int Strength
    {
        get => _strength;
        set => _strength = Math.Clamp(value, MinStrength, MaxStrength);
    }

    public int Agility
    {
        get => _agility;
        set => _agility = Math.Clamp(value, MinAgility, MaxAgility);
    }

    public int Intelligence
    {
        get => _intelligence;
        set => _intelligence = Math.Clamp(value, MinIntelligence, MaxIntelligence);
    }

    public PlayerTraits(int luck, int strength, int agility, int intelligence)
    {
        Luck = luck;
        Strength = strength;
        Agility = agility;
        Intelligence = intelligence;
    }

    public PlayerTraits()
    {
        Luck = 0;
        Strength = 0;
        Agility = 0;
        Intelligence = 0;
    }
}