
class Player : Creature
{
    public Player(int xCord, int yCord)
    {
        CharacterChar = '@';
        CharacterColor = ConsoleColor.Magenta;

        CoordX = xCord;
        CoordY = yCord;

        HealthPoints = 100;
        OriginalHealthPoints = HealthPoints;
        Name = "Player";
        IsAlive = true;
    }

    public override void Update(LevelElement element, List<LevelElement> list, LevelData levelData, int xCoord = 0, int yCoord = 0)
    {
        bool hasMoved = true;

        if (Console.ReadKey().Key == ConsoleKey.LeftArrow)
        {
            Delete();
            hasMoved = MoveOneStep(Directions.left, list);
            AttackEnemy(hasMoved, Directions.left, list, levelData);
        }
        else if (Console.ReadKey().Key == ConsoleKey.RightArrow)
        {
            Delete();
            hasMoved = MoveOneStep(Directions.right, list);
            AttackEnemy(hasMoved, Directions.right, list, levelData);
        }
        else if (Console.ReadKey().Key == ConsoleKey.DownArrow)
        {
            Delete();
            hasMoved = MoveOneStep(Directions.down, list);
            AttackEnemy(hasMoved, Directions.down, list, levelData);
        }
        else if (Console.ReadKey().Key == ConsoleKey.UpArrow)
        {
            Delete();
            hasMoved = MoveOneStep(Directions.up, list);
            AttackEnemy(hasMoved, Directions.up, list, levelData);
        }
        else if (Console.ReadKey().Key == ConsoleKey.End) Delete();
        
        Draw(element);
    }

    public void AttackEnemy(bool hasMoved, Directions direction, List<LevelElement> list, LevelData levelData)
    {
        bool isAlive = true;
        List<LevelElement> enemiesToRemove = new();

        if (!hasMoved)
        {
            foreach (var enemy in list)
            {
                if (enemy is Enemy e && CoordX - 1 == enemy.CoordX && CoordY == enemy.CoordY && direction == Directions.left)
                {
                    AttackAnimation(-1);
                    DamageEnemy(enemy);
                    if (!e.IsAlive) enemiesToRemove.Add(enemy);
                }
                if (enemy is Enemy en && CoordX + 1 == enemy.CoordX && CoordY == enemy.CoordY && direction == Directions.right)
                {
                    AttackAnimation(1);
                    DamageEnemy(enemy);
                    if (!en.IsAlive) enemiesToRemove.Add(enemy);
                }
                if (enemy is Enemy ene && CoordX == enemy.CoordX && CoordY - 1 == enemy.CoordY && direction == Directions.up)
                {
                    AttackAnimation(-2);
                    DamageEnemy(enemy);
                    if (!ene.IsAlive) enemiesToRemove.Add(enemy);
                }
                if (enemy is Enemy enem && CoordX == enemy.CoordX && CoordY + 1 == enemy.CoordY && direction == Directions.down)
                {
                    AttackAnimation(2);
                    DamageEnemy(enemy);
                    if (!enem.IsAlive) enemiesToRemove.Add(enemy);
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
        if (enemy is Rat rat)
        {
            int damage = PlayerAttackDice.Throw() - rat.RatDefenceDice.Throw();
            if (damage <= 0) damage = 0;
            else rat.HealthPoints = rat.HealthPoints - damage;
            WriteAttack(enemy, damage);
            
            if (rat.HealthPoints > 0)
            {
                damage = rat.RatAttackDice.Throw() - PlayerDefenceDice.Throw();
                if (damage <= 0) damage = 0;
                else HealthPoints = HealthPoints - damage;
                rat.WriteAttack(this, damage);
                if (HealthPoints < 0) IsAlive = false;
            }
            else rat.IsAlive = false;
        }
        else if (enemy is Snake snake)
        {
            int damage = PlayerAttackDice.Throw() - snake.SnakeDefenceDice.Throw();
            if (damage <= 0) damage = 0;
            else snake.HealthPoints = snake.HealthPoints - damage;
            WriteAttack(enemy, damage);

            if (snake.HealthPoints > 0)
            {
                damage = snake.SnakeAttackDice.Throw() - PlayerDefenceDice.Throw();
                if (damage <= 0) damage = 0;
                else HealthPoints = HealthPoints - damage;
                snake.WriteAttack(this, damage);
                if (HealthPoints < 0) IsAlive = false;
            }
            else snake.IsAlive = false;
        }
    }
    
}