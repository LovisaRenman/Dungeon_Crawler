
abstract class LevelElement
{

    public int CoordX { get; set; }
    public int CoordY { get; set; }
    public char CharacterChar { get; set; }
    public ConsoleColor CharacterColor { get; set; }
    public double DistanceFromPlayer(int playerXCoord, int playerYCoord, int elementXCoord, int elementYCoord)
    {
        double deltaX = (playerXCoord - elementXCoord);
        double deltaY = (playerYCoord - elementYCoord);
        double distanceFromPlayer = deltaX * deltaX + deltaY * deltaY;
        distanceFromPlayer = Math.Sqrt(distanceFromPlayer);
        return distanceFromPlayer;
    }

    public void Draw(LevelElement element)
    {
        Console.ForegroundColor = element.CharacterColor;
        Console.SetCursorPosition(element.CoordX, element.CoordY);
        Console.Write(element.CharacterChar);
    }

    public void Delete()
    {
        Console.SetCursorPosition(CoordX, CoordY);
        Console.Write(" ");
    }
}
