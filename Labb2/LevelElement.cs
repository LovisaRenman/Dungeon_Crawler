
abstract class LevelElement
{
    internal int CoordX { get; set; }
    internal int CoordY { get; set; }
    internal char CharacterChar { get; set; }
    internal ConsoleColor CharacterColor { get; set; }
    internal int DistanceFromPlayer { get; set; }

    virtual internal void Draw()
    {
        Console.ForegroundColor = CharacterColor;
        Console.SetCursorPosition(CoordX, CoordY);
        Console.Write(CharacterChar);
    }
}
