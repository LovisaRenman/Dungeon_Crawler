
abstract class LevelElement
{
    public int CoordX { get; set; }
    public int CoordY { get; set; }
    public char CharacterChar { get; set; }
    public ConsoleColor CharacterColor { get; set; }
    public int DistanceFromPlayer { get; set; }

    public void Draw(LevelElement element)
    {
        Console.ForegroundColor = element.CharacterColor;
        Console.SetCursorPosition(element.CoordX, element.CoordY);
        Console.Write(element.CharacterChar);
    }
}
