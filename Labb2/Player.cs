


class Player : Creature
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

    public override void Update(LevelElement element, List<LevelElement> list, int xCoord = 0, int yCoord = 0)
    {
        bool hasMoved = true;

        if (Console.ReadKey().Key == ConsoleKey.LeftArrow)
        {
            Delete();
            hasMoved = MoveOneStep("left", list);
        }
        else if (Console.ReadKey().Key == ConsoleKey.RightArrow)
        {
            Delete();
            hasMoved = MoveOneStep("right", list);
        }
        else if (Console.ReadKey().Key == ConsoleKey.DownArrow)
        {
            Delete();
            hasMoved = MoveOneStep("down", list);
        }
        else if (Console.ReadKey().Key == ConsoleKey.UpArrow)
        {
            Delete();
            hasMoved = MoveOneStep("up", list);
        }
        else if (Console.ReadKey().Key == ConsoleKey.End) Delete();
        
        Draw(element);
    }


}