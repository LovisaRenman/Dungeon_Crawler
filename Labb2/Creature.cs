
using System.Collections.Generic;

abstract class Creature : LevelElement
{
    public int HealthPoints { get; set; }
    public int Defence { get; set; }
    public int Attack { get; set; }
    

    public abstract void Update(LevelElement element, List<LevelElement> list, int playerXCoord = 0, int playerYCoord = 0);

    public void Delete()
    {
        Console.SetCursorPosition(CoordX, CoordY);
        Console.Write(" ");
    }

    public bool MoveOneStep(string direction, List<LevelElement> list)
    {
        bool hasMoved = true;
        if (direction.ToLower() == "left")
        {
            CoordX--;
            CoordX += PotentallyBlockStep(-1, list);
            if (PotentallyBlockStep(-1, list) == 0) hasMoved = false;
        }
        if (direction.ToLower() == "right")
        {
            CoordX++;
            CoordX += PotentallyBlockStep(1, list);
            if (PotentallyBlockStep(1, list) == 0) hasMoved = false;

        }
        if (direction.ToLower() == "down")
        {
            CoordY++;
            CoordY += PotentallyBlockStep(1, list);
            if (PotentallyBlockStep(1, list) == 0) hasMoved = false;

        }
        if (direction.ToLower() == "up")
        {
            CoordY--;
            CoordY += PotentallyBlockStep(-1, list);
            if (PotentallyBlockStep(-1, list) == 0) hasMoved = false;

        }

        return hasMoved;
    }

    public int PotentallyBlockStep(int direction, List<LevelElement> list)
    {
        int BlockOrMove = 0;
        foreach (LevelElement element in list)
        {
            if (element != this)
            {
                if (CoordX == element.CoordX && CoordY == element.CoordY && direction < 0)
                {
                    BlockOrMove++;
                    break;
                }
                else if (CoordX == element.CoordX && CoordY == element.CoordY && direction > 0)
                {
                    BlockOrMove--;
                    break;
                }
            }
        }

        return BlockOrMove;
    }


}

