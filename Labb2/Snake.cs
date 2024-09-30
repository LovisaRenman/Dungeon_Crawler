
class Snake : Enemy
{
    public Snake(int xCord, int yCord)
    {
        CharacterChar = 's';
        CharacterColor = ConsoleColor.Green;

        CoordX = xCord;
        CoordY = yCord;

        Name = "Snake";
        HealthPoints = 25;
    }

    public void Update(bool isOnAvailableSpot, LevelElement element)
    {
        throw new NotImplementedException();
    }
}