
abstract class Enemy : Creature
{
    public void AttackPlayer(bool hasMoved, List<LevelElement> list)
    {
        if (!hasMoved)
        {
            foreach (var player in list)
            {
                bool isAlive = true;
                if (player is Player && CoordX - 1 == player.CoordX && CoordY == player.CoordY)
                {
                    AttackAnimation(-1);
                    isAlive = DamagePlayer(player);
                    if (isAlive) (player as Player).AttackAnimation(-1);
                }
                else if (player is Player && CoordX + 1 == player.CoordX && CoordY == player.CoordY)
                {
                    AttackAnimation(1);
                    isAlive = DamagePlayer(player);
                    if (isAlive) (player as Player).AttackAnimation(1);
                }
                else if (player is Player && CoordX == player.CoordX && CoordY - 1 == player.CoordY)
                {
                    AttackAnimation(-2);
                    isAlive = DamagePlayer(player);
                    if (isAlive) (player as Player).AttackAnimation(2);
                }
                else if (player is Player && CoordX == player.CoordX && CoordY + 1 == player.CoordY)
                {
                    AttackAnimation(2);
                    isAlive = DamagePlayer(player);
                    if (isAlive) (player as Player).AttackAnimation(-2);
                }
            }
        }
    }
    public bool DamagePlayer(LevelElement player)
    {
        bool isAlive = true;
        if (player is Player && this is Rat)
        {
            int damage = RatAttackDice.Throw() - (player as Player).PlayerDefenceDice.Throw();
            if (damage <= 0) damage = 0;
            (player as Player).HealthPoints = (player as Player).HealthPoints - damage;
            WriteAttack(player, damage);

            if ((player as Player).HealthPoints > 0)
            {
                damage = (player as Player).PlayerAttackDice.Throw() - RatDefenceDice.Throw();
                if (damage < 0) damage = 0;
                HealthPoints = HealthPoints - damage;
                (player as Player).WriteAttack(this, damage);
            }
            else isAlive = false;

        }
        else if (player is Player && this is Snake)
        {
            int damage = SnakeAttackDice.Throw() - (player as Player).PlayerDefenceDice.Throw();
            if (damage <= 0) damage = 0;
            (player as Player).HealthPoints = (player as Player).HealthPoints - damage;
            WriteAttack(player, damage);

            if ((player as Player).HealthPoints > 0)
            {
                damage = (player as Player).PlayerAttackDice.Throw() - SnakeDefenceDice.Throw();
                if (damage < 0) damage = 0;
                HealthPoints = HealthPoints - damage;
                (player as Player).WriteAttack(this, damage);
            }
            else isAlive = false;

        }
        return isAlive;
    }
}