


using System.Drawing;

class Player : Creature
{
    public Player(int xCord, int yCord)
    {
        CharacterChar = '@';
        CharacterColor = ConsoleColor.Magenta;

        CoordX = xCord;
        CoordY = yCord;

        HealthPoints = 25;
    }

    public override void Update(LevelElement element, List<LevelElement> list, int xCoord = 0, int yCoord = 0)
    {
        bool hasMoved = true;

        if (Console.ReadKey().Key == ConsoleKey.LeftArrow)
        {
            Delete();
            hasMoved = MoveOneStep("left", list);
            AttackEnemy(hasMoved, list);
        }
        else if (Console.ReadKey().Key == ConsoleKey.RightArrow)
        {
            Delete();
            hasMoved = MoveOneStep("right", list);
            AttackEnemy(hasMoved, list);
        }
        else if (Console.ReadKey().Key == ConsoleKey.DownArrow)
        {
            Delete();
            hasMoved = MoveOneStep("down", list);
            AttackEnemy(hasMoved, list);
        }
        else if (Console.ReadKey().Key == ConsoleKey.UpArrow)
        {
            Delete();
            hasMoved = MoveOneStep("up", list);
            AttackEnemy(hasMoved, list);
        }
        else if (Console.ReadKey().Key == ConsoleKey.End) Delete();
        
        Draw(element);
    }

    public void AttackEnemy(bool hasMoved, List<LevelElement> list)
    {
        if (!hasMoved)
        {
            foreach (var enemy in list)
            {
                if (enemy is Enemy && CoordX - 1 == enemy.CoordX && CoordY == enemy.CoordY)
                {
                    AttackAnimation(-1); 
                }
                if (enemy is Enemy && CoordX + 1 == enemy.CoordX && CoordY == enemy.CoordY)
                {
                    AttackAnimation(1); 
                }
                if (enemy is Enemy && CoordX == enemy.CoordX && CoordY - 1 == enemy.CoordY)
                {
                    AttackAnimation(-2); 
                }
                if (enemy is Enemy && CoordX == enemy.CoordX && CoordY + 1 == enemy.CoordY)
                {
                    AttackAnimation(2); 
                }
            }
        }
    }

}