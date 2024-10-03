
using System.Collections.Generic;

abstract class Creature : LevelElement
{
    public int HealthPoints { get; set; }
    public int Defence { get; set; }
    public int Attack { get; set; }
    

    public abstract void Update(LevelElement element, List<LevelElement> list, int playerXCoord = 0, int playerYCoord = 0);



    public bool MoveOneStep(string direction, List<LevelElement> list)
    {
        bool hasMoved = true;
        if (direction.ToLower() == "left")
        {
            CoordX--;
            int value = PotentallyBlockStep(-1, list);
            CoordX += value;
            if (value > 0) hasMoved = false;
        }
        if (direction.ToLower() == "right")
        {
            CoordX++;
            int value = PotentallyBlockStep(1, list);
            CoordX += value;
            if (value < 0) hasMoved = false;

        }
        if (direction.ToLower() == "down")
        {
            CoordY++;
            int value = PotentallyBlockStep(1, list);
            CoordY += value;
            if (value < 0) hasMoved = false;

        }
        if (direction.ToLower() == "up")
        {
            CoordY--;
            int value= PotentallyBlockStep(-1, list);
            CoordY += value;
            if (value > 0) hasMoved = false;
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



    public void AttackAnimation(int direction)
    {
        if (direction == -1)
        {
            Delete();
            CoordX--;
            Draw(this);
            Thread.Sleep(500);
            Delete();
            CoordX++;
            Draw(this);
        }
        else if (direction == 1)
        {
            Delete();
            CoordX++;
            Draw(this);
            Thread.Sleep(500);
            Delete();
            CoordX--;
            Draw(this);
        }
        else if (direction == -2)
        {
            Delete();
            CoordY--;
            Draw(this);
            Thread.Sleep(500);
            Delete();
            CoordY++;
            Draw(this);
        }
        else if (direction == 2)
        {
            Delete();
            CoordY++;
            Draw(this);
            Thread.Sleep(500);
            Delete();
            CoordY--;
            Draw(this);
        }
    }
}

