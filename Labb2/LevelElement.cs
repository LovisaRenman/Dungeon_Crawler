
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
        double hypotenuse = deltaX * deltaX + deltaY * deltaY;
        hypotenuse = Math.Sqrt(hypotenuse);
        return hypotenuse;
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
