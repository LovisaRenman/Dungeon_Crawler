
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

        Delete();
        if (direction == 0)
        {
            MoveOneStep("left", list);
        }
        else if (direction == 1)
        {
            MoveOneStep("right", list);
        }
        else if (direction == 2)
        {
            MoveOneStep("down", list);
        }
        else if (direction == 3)
        {
            MoveOneStep("up", list);
        }

        Draw(element);
    }
}