
class Rat : Enemy
{
    public Rat(int xCord, int yCord)
    {
        CharacterChar = 'r';
        CharacterColor = ConsoleColor.Red;

        CoordX = xCord;
        CoordY = yCord;

        Name = "Rat";
        HealthPoints = 10;
    }

    public void Update(bool isAvailableSpot, LevelElement element)
    {
        Random rnd = new Random();
        int direction = rnd.Next(0, 4);

        Console.SetCursorPosition(CoordX, CoordY);
        Console.WriteLine("\b");

        if (!isAvailableSpot) { }
        else if (direction == 0) CoordX--;
        else if (direction == 1) CoordX++;
        else if (direction == 2) CoordY--;
        else if (direction == 3) CoordY++;

        Draw(element);
    }
}