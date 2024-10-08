
abstract class Enemy : Creature
{
    public void AttackPlayer(bool hasMoved, string direction, LevelData levelData, List<LevelElement> list)
    {
        if (!hasMoved)
        {
            
            foreach (var player in list)
            {
                if (player is Player && CoordX - 1 == player.CoordX && CoordY == player.CoordY && direction == "left")
                {
                    AttackAnimation(-1);
                    DamagePlayer(player, levelData.enemiesToRemove);
                }
                else if (player is Player && CoordX + 1 == player.CoordX && CoordY == player.CoordY && direction == "right")
                {
                    AttackAnimation(1);
                    DamagePlayer(player, levelData.enemiesToRemove);
                }
                else if (player is Player && CoordX == player.CoordX && CoordY - 1 == player.CoordY && direction == "up")
                {
                    AttackAnimation(-2);
                    DamagePlayer(player, levelData.enemiesToRemove);
                }
                else if (player is Player && CoordX == player.CoordX && CoordY + 1 == player.CoordY && direction == "down")
                {
                    AttackAnimation(2);
                    DamagePlayer(player, levelData.enemiesToRemove);
                }
            }
        }
    }
    public void DamagePlayer(LevelElement player, List<LevelElement> enemiesToRemove)
    {
        if (player is Player && this is Rat)
        {
            int damage = RatAttackDice.Throw() - (player as Player).PlayerDefenceDice.Throw();
            if (damage <= 0) damage = 0;
            else (player as Player).HealthPoints = (player as Player).HealthPoints - damage;
            WriteAttack(player, damage);

            if ((player as Player).HealthPoints > 0)
            {
                damage = (player as Player).PlayerAttackDice.Throw() - RatDefenceDice.Throw();
                if (damage <= 0) damage = 0;
                else HealthPoints = HealthPoints - damage;
                (player as Player).WriteAttack(this, damage);
                if (HealthPoints < 0)
                {
                    IsAlive = false;
                    enemiesToRemove.Add(this);
                }
            }
            else (player as Player).IsAlive = false;

        }
        else if (player is Player && this is Snake)
        {
            int damage = SnakeAttackDice.Throw() - (player as Player).PlayerDefenceDice.Throw();
            if (damage <= 0) damage = 0;
            else (player as Player).HealthPoints = (player as Player).HealthPoints - damage;
            WriteAttack(player, damage);

            if ((player as Player).HealthPoints > 0)
            {
                damage = (player as Player).PlayerAttackDice.Throw() - SnakeDefenceDice.Throw();
                if (damage <= 0) damage = 0;
                else HealthPoints = HealthPoints - damage;
                (player as Player).WriteAttack(this, damage);
                if (HealthPoints < 0) 
                { 
                    IsAlive = false;
                    enemiesToRemove.Add(this);
                }
            }
            else (player as Player).IsAlive = false;
        }
    }
}