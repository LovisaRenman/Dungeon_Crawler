
using System.Numerics;
using System.Security.Cryptography.X509Certificates;

class Player : Entity
{
    public int DistanceFromPlayer { get; set; }
    public Player(int xCord, int yCord)
    {
        CharacterChar = '@';
        CharacterColor = ConsoleColor.Magenta;

        CoordX = xCord;
        CoordY = yCord;

        HealthPoints = 25;
    }

    public void Update(LevelElement element, List<LevelElement> list)
    {
        
        if (Console.ReadKey().Key == ConsoleKey.LeftArrow)
        {
            Delete();
            CoordX--;
            foreach (LevelElement wall in list)
            {
                if (wall is Wall)
                {
                    if (CoordX == wall.CoordX && CoordY == wall.CoordY)
                    {
                        CoordX++;
                        break;
                    }
                }
            }
        }
        else if (Console.ReadKey().Key == ConsoleKey.RightArrow)
        {
            Delete();
            CoordX++;
            foreach (LevelElement wall in list)
            {
                if (wall is Wall)
                {
                    if (CoordX == wall.CoordX && CoordY == wall.CoordY)
                    {
                        CoordX--;
                    }
                }
            }
        }
        else if (Console.ReadKey().Key == ConsoleKey.DownArrow)
        {
            Delete();
            CoordY++;
            foreach (LevelElement wall in list)
            {
                if (wall is Wall)
                {
                    if (CoordX == wall.CoordX && CoordY == wall.CoordY)
                    {
                        CoordY--;
                    }
                }
            }
        }
        else if (Console.ReadKey().Key == ConsoleKey.UpArrow)
        {
            Delete();
            CoordY--;
            foreach (LevelElement wall in list)
            {
                if (wall is Wall)
                {
                    if (CoordX == wall.CoordX && CoordY == wall.CoordY)
                    {
                        CoordY++;
                    }
                }
            }
        }
        else if (Console.ReadKey().Key == ConsoleKey.End) Delete();
        
        Draw(element);
    }

    private void Delete()
    {
        Console.SetCursorPosition(CoordX, CoordY);
        Console.Write(" ");
    }
}