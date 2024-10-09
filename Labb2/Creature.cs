
abstract class Creature : LevelElement
{
    public int OriginalHealthPoints { get; set; }
    public int HealthPoints { get; set; }
    public bool IsAlive { get; set; }
    public int Defence { get; set; }
    public int Attack { get; set; }
    public string Name { get; set; }

    public abstract void Update(LevelElement element, List<LevelElement> list, LevelData leveldata, int playerXCoord = 0, int playerYCoord = 0);

    public bool MoveOneStep(Directions direction, List<LevelElement> list)
    {
        int value;
        bool hasMoved = true;
        if (direction == Directions.left)
        {
            CoordX--;
            value = PotentallyBlockStep(-1, list);
            CoordX += value;
            if (value > 0) hasMoved = false;
        }
        if (direction == Directions.right)
        {
            CoordX++;
            value = PotentallyBlockStep(1, list);
            CoordX += value;
            if (value < 0) hasMoved = false;
        }
        if (direction == Directions.down)
        {
            CoordY++;
            value = PotentallyBlockStep(1, list);
            CoordY += value;
            if (value < 0) hasMoved = false;
        }
        if (direction == Directions.up)
        {
            CoordY--;
            value= PotentallyBlockStep(-1, list);
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
        int sleepDuration = 250;
        if (direction == -1)
        {
            Delete();
            CoordX--;
            Draw(this);
            Thread.Sleep(sleepDuration);
            Delete();
            CoordX++;
            Draw(this);
        }
        else if (direction == 1)
        {
            Delete();
            CoordX++;
            Draw(this);
            Thread.Sleep(sleepDuration);
            Delete();
            CoordX--;
            Draw(this);
        }
        else if (direction == -2)
        {
            Delete();
            CoordY--;
            Draw(this);
            Thread.Sleep(sleepDuration);
            Delete();
            CoordY++;
            Draw(this);
        }
        else if (direction == 2)
        {
            Delete();
            CoordY++;
            Draw(this);
            Thread.Sleep(sleepDuration);
            Delete();
            CoordY--;
            Draw(this);
        }
    }


    private Dice _playerAttackDice = new Dice(2, 6, 2);
    public Dice PlayerAttackDice
    {
        get { return _playerAttackDice; }
    }

    private Dice _playerDefenceDice = new Dice(2, 6, 0);
    public Dice PlayerDefenceDice
    {
        get { return _playerDefenceDice; }
    }

    private Dice _ratAttackDice = new Dice(1, 6, 3);
    public Dice RatAttackDice
    {
        get { return _ratAttackDice; }
    }

    private Dice _ratDefenceDice = new Dice(1, 6, 1);
    public Dice RatDefenceDice
    {
        get { return _ratDefenceDice; }
    }

    private Dice _snakeAttackDice = new Dice(1, 6, 3);
    public Dice SnakeAttackDice
    {
        get { return _snakeAttackDice; }
    }

    private Dice _SnakeDefenceDice = new Dice(1, 8, 5);
    public Dice SnakeDefenceDice
    {
        get { return _SnakeDefenceDice; }
    }
    public void WriteAttack(LevelElement element, int damage)    
    {
        double percentageOfHealth = Convert.ToDouble((element as Creature).HealthPoints)
            / Convert.ToDouble((element as Creature).OriginalHealthPoints);

        if (percentageOfHealth > 0.66) Console.ForegroundColor = ConsoleColor.Green;
        else if (percentageOfHealth > 0.33) Console.ForegroundColor = ConsoleColor.Yellow;
        else Console.ForegroundColor = ConsoleColor.Red;


        if (this is Enemy)
        {
            Console.SetCursorPosition(0, 19);
            Console.Write(" ".PadRight(Console.BufferWidth));
            Console.SetCursorPosition(0, 19); // Fixed bug where text wrote over itself
        }
        else if (this is Player)
        {
            Console.SetCursorPosition(0, 20);
            Console.Write(" ".PadRight(Console.BufferWidth));
            Console.SetCursorPosition(0, 20);
        }

        if (element is Rat rat)
        {
            if (rat.HealthPoints > 0) Console.WriteLine($"{Name} attacked with {PlayerAttackDice}. " + 
                $"{rat.Name} defended with {rat.RatDefenceDice} and recived {damage} damage " +
                $"{rat.Name} remaining Hp is {rat.HealthPoints}");
            else Console.WriteLine($"{Name} attacked with {PlayerAttackDice}. {rat.Name} defended with " +
                $"{rat.RatDefenceDice} and recived {damage} damage {rat.Name} remaining Hp is {0}");
        }
        else if (this is Rat r && element is Player player)
        {
            if (player.HealthPoints > 0) Console.WriteLine($"{Name} attacked with {r.RatAttackDice}. " +
                $"{player.Name} defended with {player.PlayerDefenceDice} and recived {damage} damage " +
                $"{player.Name} remaining Hp is {player.HealthPoints}");
            else Console.WriteLine($"{Name} attacked with {r.RatAttackDice}. {player.Name} defended with " +
                $"{player.PlayerDefenceDice} and recived {damage} damage {player.Name} remaining Hp is {0}");
        }
        else if (element is Snake snake)
        {
            if(snake.HealthPoints > 0) Console.WriteLine($"{Name} attacked with {PlayerAttackDice}." +
                $" {snake.Name} defended with {snake.SnakeDefenceDice} and recived {damage} damage " +
                $"{snake.Name} remaining Hp is {snake.HealthPoints}");
            else Console.WriteLine($"{Name} attacked with {PlayerAttackDice}. {snake.Name} defended with " +
                $"{snake.SnakeDefenceDice} and recived {damage} damage {snake.Name} remaining Hp is {0}");
        }
        else if (this is Snake s && element is Player p)
        {
            if (p.HealthPoints > 0) Console.WriteLine($"{Name} attacked with {s.SnakeAttackDice}." +
                $" {p.Name} defended with {p.PlayerDefenceDice} and recived {damage} damage" +
                $" {p.Name} remaining Hp is {p.HealthPoints}");
            else Console.WriteLine($"{Name} attacked with {s.SnakeAttackDice}. {p.Name} defended with " +
                $"{p.PlayerDefenceDice} and recived {damage} damage {p.Name} remaining Hp is {0}");
        }
    }
}


