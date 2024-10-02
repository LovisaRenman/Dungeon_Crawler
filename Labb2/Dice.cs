
internal class Dice
{
    internal int DiceThrow(int numberOfDice, int sidesPerDice, int Modifier)
    {
        int diceThrow = Modifier;
        Random rnd = new();

        for (int i = 0; i < numberOfDice; i++)
        {
            diceThrow += rnd.Next(0, sidesPerDice + 1);
        }

        return diceThrow;
    }

    public override string ToString()
    {
        return base.ToString(); // to be implementet
    }
}

