


class Gameloop 
{
    public void PlayGame()
    {
        Console.CursorVisible = false;
        LevelData levelData = new();
        levelData.Load(@"Level\Level1.txt");
        levelData.DrawFromList();

        foreach (LevelElement player in levelData.Elements)
        {
            if (player is Player)
            {
                while (true)
                {
                    (player as Player).Update(player, levelData.Elements);
                }                               
            }
        }
    }
}

