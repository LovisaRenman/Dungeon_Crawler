
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
        OriginalHealthPoints = HealthPoints;
        IsAlive = true;
    }

    public override void Update(LevelElement element, List<LevelElement> list, LevelData leveldata, int playerXCoord = 0, int playerYCoord = 0)
    {
        Random rnd = new Random();
        int direction = rnd.Next(0, 4);
        bool hasMoved = true;
        Delete();
        if (direction == 0)
        {
            hasMoved = MoveOneStep(Directions.left, list);
            AttackPlayer(hasMoved, Directions.left, leveldata, list);
        }
        else if (direction == 1)
        {
            hasMoved = MoveOneStep(Directions.right, list);         
            AttackPlayer(hasMoved, Directions.right, leveldata, list);
        }
        else if (direction == 2)
        {
            hasMoved = MoveOneStep(Directions.down, list);
            AttackPlayer(hasMoved, Directions.down, leveldata, list);
        }
        else if (direction == 3)
        {
            hasMoved = MoveOneStep(Directions.up, list);
            AttackPlayer(hasMoved, Directions.up, leveldata, list);
        }

        Draw(element);
    }
}