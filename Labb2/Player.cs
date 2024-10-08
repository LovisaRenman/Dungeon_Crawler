
class Player : Creature
{
    public Player(int xCord, int yCord)
    {
        CharacterChar = '@';
        CharacterColor = ConsoleColor.Magenta;

        CoordX = xCord;
        CoordY = yCord;

        HealthPoints = 100;
        Name = "Player";
        IsAlive = true;
    }


    public override void Update(LevelElement element, List<LevelElement> list, LevelData levelData, int xCoord = 0, int yCoord = 0)
    {
        bool hasMoved = true;

        if (Console.ReadKey().Key == ConsoleKey.LeftArrow)
        {
            Delete();
            hasMoved = MoveOneStep("left", list);
            AttackEnemy(hasMoved, "left", list, levelData);
        }
        else if (Console.ReadKey().Key == ConsoleKey.RightArrow)
        {
            Delete();
            hasMoved = MoveOneStep("right", list);
            AttackEnemy(hasMoved, "right", list, levelData);
        }
        else if (Console.ReadKey().Key == ConsoleKey.DownArrow)
        {
            Delete();
            hasMoved = MoveOneStep("down", list);
            AttackEnemy(hasMoved, "down", list, levelData);
        }
        else if (Console.ReadKey().Key == ConsoleKey.UpArrow)
        {
            Delete();
            hasMoved = MoveOneStep("up", list);
            AttackEnemy(hasMoved, "up", list, levelData);
        }
        else if (Console.ReadKey().Key == ConsoleKey.End) Delete();
        
        Draw(element);
    }

    public void AttackEnemy(bool hasMoved, string direction, List<LevelElement> list, LevelData levelData)
    {
        bool isAlive = true;
        List<LevelElement> enemiesToRemove = new();

        if (!hasMoved)
        {
            foreach (var enemy in list)
            {
                if (enemy is Enemy && CoordX - 1 == enemy.CoordX && CoordY == enemy.CoordY && direction == "left")
                {
                    AttackAnimation(-1);
                    DamageEnemy(enemy);
                    if (!(enemy as Enemy).IsAlive) enemiesToRemove.Add(enemy);
                }
                if (enemy is Enemy && CoordX + 1 == enemy.CoordX && CoordY == enemy.CoordY && direction == "right")
                {
                    AttackAnimation(1);
                    DamageEnemy(enemy);
                    if (!(enemy as Enemy).IsAlive) enemiesToRemove.Add(enemy);
                }
                if (enemy is Enemy && CoordX == enemy.CoordX && CoordY - 1 == enemy.CoordY && direction == "up")
                {
                    AttackAnimation(-2);
                    DamageEnemy(enemy);
                    if (!(enemy as Enemy).IsAlive) enemiesToRemove.Add(enemy);
                }
                if (enemy is Enemy && CoordX == enemy.CoordX && CoordY + 1 == enemy.CoordY && direction == "down")
                {
                    AttackAnimation(2);
                    DamageEnemy(enemy);
                    if (!(enemy as Enemy).IsAlive) enemiesToRemove.Add(enemy);
                }
            }
            foreach (var enemy in enemiesToRemove)
            {
                levelData.RemoveEnemy(enemy);
            }
        }
    }
    public void DamageEnemy(LevelElement enemy)
    {
        bool isAlive = true;
        if (enemy is Rat)
        {
            int damage = PlayerAttackDice.Throw() - (enemy as Rat).RatDefenceDice.Throw();
            if (damage <= 0) damage = 0;
            else (enemy as Rat).HealthPoints = (enemy as Rat).HealthPoints - damage;
            WriteAttack(enemy, damage);
            
            if ((enemy as Rat).HealthPoints > 0)
            {
                damage = (enemy as Rat).RatAttackDice.Throw() - PlayerDefenceDice.Throw();
                if (damage <= 0) damage = 0;
                else HealthPoints = HealthPoints - damage;
                (enemy as Rat).WriteAttack(this, damage);
                if (HealthPoints < 0) IsAlive = false;
            }
            else (enemy as Rat).IsAlive = false;
        }
        else if (enemy is Snake)
        {
            int damage = PlayerAttackDice.Throw() - (enemy as Snake).SnakeDefenceDice.Throw();
            if (damage <= 0) damage = 0;
            else (enemy as Snake).HealthPoints = (enemy as Snake).HealthPoints - damage;
            WriteAttack(enemy, damage);

            if ((enemy as Snake).HealthPoints > 0)
            {
                damage = (enemy as Snake).SnakeAttackDice.Throw() - PlayerDefenceDice.Throw();
                if (damage <= 0) damage = 0;
                else HealthPoints = HealthPoints - damage;
                (enemy as Snake).WriteAttack(this, damage);
                if (HealthPoints < 0) IsAlive = false;
            }
            else (enemy as Snake).IsAlive = false;
        }
    }
    
}