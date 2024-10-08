
using System.Numerics;

internal class Dice
{
    public int NumberOfDice { get; set; }
    public int SidesPerDice { get; set; }
    public int Modifier { get; set; }
    public int TotalAdd { get; set; }

    public Dice(int numberOfDice, int sidesPerDice, int modifier)
    {
        NumberOfDice = numberOfDice;
        SidesPerDice = sidesPerDice;
        Modifier = modifier;
    }

    public int Throw()
    {
        int diceThrow = Modifier;
        Random rnd = new();

        for (int i = 0; i < NumberOfDice; i++)
        {
            diceThrow += rnd.Next(1, SidesPerDice + 1);
        }

        TotalAdd = diceThrow;

        return diceThrow;
    }

    public override string ToString()
    {
        return $"{NumberOfDice}d{SidesPerDice}+{Modifier} -> {TotalAdd}";
    }
}

