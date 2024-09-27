
abstract class LevelElement
{
    internal int CoordX { get; set; }
    internal int CoordY { get; set; }
    internal char CharacterChar { get; set; }
    internal ConsoleColor CharacterColor { get; set; }
    internal int DistanceFromPlayer { get; set; }

    internal static void Draw(LevelElement element)
    {
        Console.ForegroundColor = element.CharacterColor;
        Console.SetCursorPosition(element.CoordX, element.CoordY);
        Console.Write(element.CharacterChar);
    }
}
