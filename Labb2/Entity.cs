
abstract class Entity : LevelElement
{
    public int HealthPoints { get; set; }
    public int Defence { get; set; }
    public int Attack { get; set; }

    abstract public void Move();
}

