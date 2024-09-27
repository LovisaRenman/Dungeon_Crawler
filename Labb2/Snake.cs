
class Snake : Entity
{
    public Snake(int xCord, int yCord)
    {
        CharacterChar = 's';
        CharacterColor = ConsoleColor.Green;

        CoordX = xCord;
        CoordY = yCord;

        HealthPoints = 25;
    }

    public override void Move()
    {
        throw new NotImplementedException();
    }
}