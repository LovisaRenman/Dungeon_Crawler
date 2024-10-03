
class Snake : Enemy
{
    public Snake(int xCord, int yCord)
    {
        CharacterChar = 's';
        CharacterColor = ConsoleColor.Green;

        CoordX = xCord;
        CoordY = yCord;

        Name = "Snake";
        HealthPoints = 25;
    }

    public override void Update(LevelElement element, List<LevelElement> list, int playerXCoord = 0, int playerYCoord = 0)
    {
        double hypotenuse = DistanceFromPlayer(playerXCoord, playerYCoord, CoordX, CoordY);

        Delete();
        double fleeRange = 2;
        if (hypotenuse <= fleeRange)
        {
            bool hasMoved = true;
            if (playerYCoord >= CoordY && playerXCoord == CoordX)
            {
                hasMoved = MoveOneStep("up", list);
                if (!hasMoved)
                {
                    double chooseWayLeft = DistanceFromPlayer(playerXCoord, playerYCoord, CoordX - 1, CoordY);
                    double chooseWayRight = DistanceFromPlayer(playerXCoord, playerYCoord, CoordX + 1, CoordY);

                    if (chooseWayLeft <= chooseWayRight)
                    {
                        hasMoved = MoveOneStep("right", list);
                        if (!hasMoved) MoveOneStep("left", list);
                    }
                    else if (chooseWayLeft > chooseWayRight)
                    {
                        hasMoved = MoveOneStep("left", list);
                        if (!hasMoved) MoveOneStep("right", list);
                    }
                }
            }
            else if (playerYCoord <= CoordY && playerXCoord == CoordX)
            {
                hasMoved = MoveOneStep("down", list);
                if (!hasMoved)
                {
                    double chooseWayLeft = DistanceFromPlayer(playerXCoord, playerYCoord, CoordX - 1, CoordY);
                    double chooseWayRight = DistanceFromPlayer(playerXCoord, playerYCoord, CoordX + 1, CoordY);

                    if (chooseWayLeft <= chooseWayRight)
                    {
                        hasMoved = MoveOneStep("right", list);
                        if (!hasMoved) MoveOneStep("left", list);
                    }
                    else if (chooseWayLeft > chooseWayRight)
                    {
                        hasMoved = MoveOneStep("left", list);
                        if (!hasMoved) MoveOneStep("right", list);
                    }
                }
            }
            else if ( playerXCoord >= CoordX)
            {
                hasMoved = MoveOneStep("left", list);
                if (!hasMoved)
                {
                    double chooseWayUp = DistanceFromPlayer(playerXCoord, playerYCoord, CoordX, CoordY - 1);
                    double chooseWayDown = DistanceFromPlayer(playerXCoord, playerYCoord, CoordX, CoordY + 1);
                    hasMoved = true;

                    if (chooseWayUp <= chooseWayDown)
                    {
                        hasMoved = MoveOneStep("down", list);
                        if (!hasMoved) MoveOneStep("up", list);
                    }
                    else if (chooseWayUp > chooseWayDown)
                    {
                        hasMoved = MoveOneStep("up", list);
                        if (!hasMoved) MoveOneStep("down", list);
                    }
                }
            }
            else if (playerXCoord <= CoordX)
            {
                hasMoved = MoveOneStep("right", list);
                if (!hasMoved)
                {
                    double chooseWayUp = DistanceFromPlayer(playerXCoord, playerYCoord, CoordX, CoordY - 1);
                    double chooseWayDown = DistanceFromPlayer(playerXCoord, playerYCoord, CoordX, CoordY + 1);

                    if (chooseWayUp < chooseWayDown)
                    {
                        hasMoved = MoveOneStep("down", list);
                        if (!hasMoved) MoveOneStep("up", list);
                    }
                    else if (chooseWayUp >= chooseWayDown)
                    {
                        hasMoved = MoveOneStep("up", list);
                        if (!hasMoved) MoveOneStep("down", list);
                    }
                }
            }
        }

        Draw(element);
    }
}