
class Rat : Enemy
{
    public Rat(int xCord, int yCord)
    {
        CharacterChar = 'r';
        CharacterColor = ConsoleColor.Red;

        CoordX = xCord;
        CoordY = yCord;

        Name = "Rat";
        HealthPoints = 10;
    }

    public override void Update(LevelElement element, List<LevelElement> list, int playerXCoord = 0, int playerYCoord = 0)
    {
        Random rnd = new Random();
        int direction = rnd.Next(0, 4);
        bool hasMoved = true;
        Delete();
        if (direction == 0)
        {
            hasMoved = MoveOneStep("left", list);
            AttackPlayer(hasMoved, list);
        }
        else if (direction == 1)
        {
            hasMoved = MoveOneStep("right", list);         
            AttackPlayer(hasMoved, list);
        }
        else if (direction == 2)
        {
            hasMoved = MoveOneStep("down", list);
            AttackPlayer(hasMoved, list);
        }
        else if (direction == 3)
        {
            hasMoved = MoveOneStep("up", list);
            AttackPlayer(hasMoved, list);
        }

        Draw(element);
    }
}