
abstract class Creature : LevelElement
{
    public int HealthPoints { get; set; }
    public bool IsAlive { get; set; }
    public int Defence { get; set; }
    public int Attack { get; set; }
    public string Name { get; set; }

    public abstract void Update(LevelElement element, List<LevelElement> list, LevelData leveldata, int playerXCoord = 0, int playerYCoord = 0);


    public bool MoveOneStep(string direction, List<LevelElement> list)
    {
        bool hasMoved = true;
        if (direction.ToLower() == "left")
        {
            CoordX--;
            int value = PotentallyBlockStep(-1, list);
            CoordX += value;
            if (value > 0) hasMoved = false;
        }
        if (direction.ToLower() == "right")
        {
            CoordX++;
            int value = PotentallyBlockStep(1, list);
            CoordX += value;
            if (value < 0) hasMoved = false;

        }
        if (direction.ToLower() == "down")
        {
            CoordY++;
            int value = PotentallyBlockStep(1, list);
            CoordY += value;
            if (value < 0) hasMoved = false;

        }
        if (direction.ToLower() == "up")
        {
            CoordY--;
            int value= PotentallyBlockStep(-1, list);
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
        if (direction == -1)
        {
            Delete();
            CoordX--;
            Draw(this);
            Thread.Sleep(500);
            Delete();
            CoordX++;
            Draw(this);
        }
        else if (direction == 1)
        {
            Delete();
            CoordX++;
            Draw(this);
            Thread.Sleep(500);
            Delete();
            CoordX--;
            Draw(this);
        }
        else if (direction == -2)
        {
            Delete();
            CoordY--;
            Draw(this);
            Thread.Sleep(500);
            Delete();
            CoordY++;
            Draw(this);
        }
        else if (direction == 2)
        {
            Delete();
            CoordY++;
            Draw(this);
            Thread.Sleep(500);
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
        //if (this is Player && (this as Player).HealthPoints > 66
        //    || this is Rat && (this as Rat).HealthPoints > 6
        //    || this is Snake && (this as Snake).HealthPoints > 16)
        //    Console.ForegroundColor = ConsoleColor.Green;
        //else if (this is Player && (this as Player).HealthPoints > 33
        //    || this is Rat && (this as Rat).HealthPoints > 3
        //    || this is Snake && (this as Snake).HealthPoints > 8)
        //    Console.ForegroundColor = ConsoleColor.Yellow;
        //else Console.ForegroundColor = ConsoleColor.Red;

        Console.ForegroundColor = ConsoleColor.White;

        if (this is Enemy)
        {
            Console.SetCursorPosition(0, 20);
            Console.Write(" ".PadRight(Console.BufferWidth));
        }
        else if (this is Player)
        {
            Console.SetCursorPosition(0, 19);
            Console.Write(" ".PadRight(Console.BufferWidth));
        }

        if (element is Rat)
        {
            if ((element as Rat).HealthPoints > 0) Console.WriteLine($"{Name} attacked with {(this as Player).PlayerAttackDice}. " +
                $"{(element as Rat).Name} defended with {(element as Rat).RatDefenceDice} and recived {damage} damage " +
                $"{(element as Rat).Name} remaining Hp is {(element as Rat).HealthPoints}");
            else Console.WriteLine($"{Name} attacked with {(this as Player).PlayerAttackDice}. {(element as Rat).Name} defended with " +
                $"{(element as Rat).RatDefenceDice} and recived {damage} damage {(element as Rat).Name} remaining Hp is {0}");
        }
        else if (this is Rat)
        {
            if ((element as Player).HealthPoints > 0) Console.WriteLine($"{Name} attacked with {(this as Rat).RatAttackDice}. " +
                $"{(element as Player).Name} defended with {(element as Player).PlayerDefenceDice} and recived {damage} damage " +
                $"{(element as Player).Name} remaining Hp is {(element as Player).HealthPoints}");
            else Console.WriteLine($"{Name} attacked with {(this as Rat).RatAttackDice}. {(element as Player).Name} defended with " +
                $"{(element as Player).PlayerDefenceDice} and recived {damage} damage {(element as Player).Name} remaining Hp is {0}");

        }
        else if (element is Snake)
        {
            if((element as Snake).HealthPoints > 0) Console.WriteLine($"{Name} attacked with {(this as Player).PlayerAttackDice}." +
                $" {(element as Snake).Name} defended with {(element as Snake).SnakeDefenceDice} and recived {damage} damage " +
                $"{(element as Snake).Name} remaining Hp is {(element as Snake).HealthPoints}");
            else Console.WriteLine($"{Name} attacked with {(this as Player).PlayerAttackDice}. {(element as Snake).Name} defended with " +
                $"{(element as Snake).SnakeDefenceDice} and recived {damage} damage {(element as Snake).Name} remaining Hp is {0}");
        }
        else if (this is Snake)
        {
            if ((element as Player).HealthPoints > 0) Console.WriteLine($"{Name} attacked with {(this as Snake).SnakeAttackDice}." +
                $" {(element as Player).Name} defended with {(element as Player).PlayerDefenceDice} and recived {damage} damage" +
                $" {(element as Player).Name} remaining Hp is {(element as Player).HealthPoints}");
            else Console.WriteLine($"{Name} attacked with {(this as Snake).SnakeAttackDice}. {(element as Player).Name} defended with " +
                $"{(element as Player).PlayerDefenceDice} and recived {damage} damage {(element as Player).Name} remaining Hp is {0}");
        }

    }
}


