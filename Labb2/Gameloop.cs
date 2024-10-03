
class Gameloop 
{
    public void PlayGame()
    {
        Console.CursorVisible = false;
        LevelData levelData = new();
        levelData.Load(@"Level\Level1.txt");
        //levelData.DrawFromList();

        foreach (LevelElement player in levelData.Elements)
        {
            if (player is Player)
            {
                bool isPlayerAlive = true; // to later be implemented to stop the foreverloop if Player dies
                while (isPlayerAlive)
                {
                    (player as Player).Update(player, levelData.Elements);
                    player.Draw(player);

                    foreach (LevelElement element in levelData.Elements)
                    {
                        if (element is Rat)
                        {                            
                            (element as Rat).Update(element, levelData.Elements);
                            double distance = element.DistanceFromPlayer(player.CoordX, player.CoordY, element.CoordX, element.CoordY);
                            double DrawRange = 5;
                            if (distance < DrawRange)
                            {
                                element.Draw(element);
                            }
                            else element.Delete();
                        }
                        else if (element is Snake)
                        {
                            (element as Snake).Update(element, levelData.Elements, player.CoordX, player.CoordY);
                            double distance = element.DistanceFromPlayer(player.CoordX, player.CoordY, element.CoordX, element.CoordY);
                            double DrawRange = 5;
                            if (distance < DrawRange)
                            {
                                element.Draw(element);
                            }
                            else element.Delete();
                        }
                        else if (element is Wall)
                        {
                            double distance = element.DistanceFromPlayer(player.CoordX, player.CoordY, element.CoordX, element.CoordY);
                            double DrawRange = 5;
                            if (distance < DrawRange)
                            {
                                element.Draw(element);
                            }
                        }
                    }
                    player.Draw(player);
                }                               
            }
        }
    }
}

