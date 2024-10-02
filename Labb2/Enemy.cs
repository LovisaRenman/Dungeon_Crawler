


abstract class Enemy : Creature
{
    public string Name { get; set; }

    public override bool MoveOneStep(string direction, List<LevelElement> list)
    {
        bool hasMoved = true;
        if (direction.ToLower() == "left")
        {
            CoordX--;
            foreach (LevelElement element in list )
            {
                if (element is Wall or Enemy && element != this)
                {
                    if (CoordX == element.CoordX && CoordY == element.CoordY)
                    {
                        CoordX++;
                        hasMoved = false;
                        break;
                    }
                }
                else if (element is Player)
                {

                }
            }
        }
        if (direction.ToLower() == "right")
        {
            CoordX++;
            foreach (LevelElement element in list)
            {
                if (element is Wall or Enemy && element != this)
                {
                    if (CoordX == element.CoordX && CoordY == element.CoordY)
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
                if (element is Wall or Enemy && element != this)
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
            foreach (LevelElement element in list)
            {
                if (element is Wall or Enemy && element != this)
                {
                    if (CoordX == element.CoordX && CoordY == element.CoordY)
                    {
                        CoordY++;
                        hasMoved = false;
                        break;
                    }
                }

            }
        }

        return hasMoved;
    }
}