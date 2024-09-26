
class Snake : Entity
{
    public Snake(int xCord, int yCord)
    {
        CharacterChar = 'S';
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