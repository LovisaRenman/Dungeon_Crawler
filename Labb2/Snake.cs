
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
        bool hasMoved;

        Delete();
        double distance = 2;
        if (hypotenuse <= distance)
        {
            if (playerYCoord == CoordY + 2 && playerXCoord == CoordX || playerYCoord == CoordY + 1 && playerXCoord == CoordX)
            {
                MoveOneStep("up", list);
                //hasMoved = MoveOneStep("up", list);
                //if (!hasMoved && playerXCoord >= CoordX--)
                //{
                //    hasMoved = MoveOneStep("left", list);
                //    if (!hasMoved) MoveOneStep("right", list);
                //}
            }
            else if (playerYCoord == CoordY - 2 && playerXCoord == CoordX || playerYCoord == CoordY - 1 && playerXCoord == CoordX)
            {
                MoveOneStep("down", list);
                //hasMoved = MoveOneStep("down", list);
                //if (!hasMoved && playerXCoord <= CoordX--)
                //{
                //    hasMoved = MoveOneStep("left", list);
                //    if (!hasMoved) MoveOneStep("right", list);
                //}
            }
            else if ( playerXCoord >= CoordX + 1 ) //&& playerYCoord == CoordY 
            {
                MoveOneStep("left", list);
                //hasMoved = MoveOneStep("left", list);
                //if (!hasMoved && playerYCoord >= CoordY++)
                //{
                //    hasMoved = MoveOneStep("up", list);
                //    if (!hasMoved) MoveOneStep("down", list);
                //}
            }
            else if (playerXCoord <= CoordX - 1 )
            {
                MoveOneStep("right", list);
                //hasMoved = MoveOneStep("right", list);
                //if (!hasMoved)
                //{
                //    hasMoved = MoveOneStep("up", list);
                //    if (!hasMoved) MoveOneStep("down", list);
                //}
            }

            // compare which spot is the futherst and not wall
        }

        Draw(element);
    }
}