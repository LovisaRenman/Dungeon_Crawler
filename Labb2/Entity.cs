
abstract class Entity : LevelElement
{
    public int HealthPoints { get; set; }
    public int Defence { get; set; }
    public int Attack { get; set; }
    public Dice AttackDice { get; set; }
    public Dice DefenceDice { get; set; }

    public abstract void Update(LevelElement element, List<LevelElement> listint, int playerXCoord = 0, int playerYCoord = 0);

    public void Delete()
    {
        Console.SetCursorPosition(CoordX, CoordY);
        Console.Write(" ");
    }

    public void MoveOneStep(string direction, List<LevelElement> list)
    {
        bool hasMoved = true; // to be implemented to make the snake more slippery
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
                        hasMoved = false;
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
                        hasMoved = false;
                        break;
                    }
                }
            }
        }
        if (direction.ToLower() == "down")
        {
            CoordY++;
            foreach (LevelElement element in list)
            {
                if (element is Wall)
                {
                    if (CoordX == element.CoordX && CoordY == element.CoordY)
                    {
                        CoordY--;
                        hasMoved = false;
                        break;
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
                        hasMoved = false;
                        break;
                    }
                }
            }
        }
        //return hasMoved;
    }
}

