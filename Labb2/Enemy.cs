


abstract class Enemy : Creature
{
    public string Name { get; set; }

    public void AttackPlayer(bool hasMoved, List<LevelElement> list)
    {
        if (!hasMoved)
        {
            foreach (var player in list)
            {
                if (player is Player && CoordX - 1 == player.CoordX && CoordY == player.CoordY)
                {
                    AttackAnimation(-1);
                }
                if (player is Player && CoordX + 1 == player.CoordX && CoordY == player.CoordY)
                {
                    AttackAnimation(1);
                }
                if (player is Player && CoordX == player.CoordX && CoordY - 1 == player.CoordY)
                {
                    AttackAnimation(-2);
                }
                if (player is Player && CoordX == player.CoordX && CoordY + 1 == player.CoordY)
                {
                    AttackAnimation(2);
                }
            }
        }
    }

}