
abstract class Entity : LevelElement
{
    public int HealthPoints { get; set; }
    public int Defence { get; set; }
    public int Attack { get; set; }
    public Dice AttackDice { get; set; }
    public Dice DefenceDice { get; set; }

    public void Delete()
    {
        Console.SetCursorPosition(CoordX, CoordY);
        Console.Write(" ");
    }

    public void MoveOneStep(string direction, List<LevelElement> list)
    {
        if (direction.ToLower() == "left")
        {
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
        if (direction.ToLower() == "right")
        {
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
        if (direction.ToLower() == "down")
        {
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
        if (direction.ToLower() == "up")
        {
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
    }


}

