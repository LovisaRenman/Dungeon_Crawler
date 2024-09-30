
abstract class Entity : LevelElement
{
    public int HealthPoints { get; set; }
    public int Defence { get; set; }
    public int Attack { get; set; }
    public Dice AttackDice { get; set; }
    public Dice DefenceDice { get; set; }

    
}

