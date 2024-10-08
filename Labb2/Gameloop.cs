
class Gameloop 
{
    public void PlayGame()
    {
        Console.CursorVisible = false;
        LevelData levelData = new();
        levelData.Load(@"Level\Level1.txt");
        //levelData.DrawFromList();

        bool isPlayerAlive = true;
        while (isPlayerAlive)
        {
            levelData.Player.Draw(levelData.Player);
            levelData.Player.Update(levelData.Player, levelData.Elements, levelData);

            foreach (LevelElement element in levelData.Elements)
            {
                if (element is Rat)
                {                            
                    (element as Rat).Update(element, levelData.Elements, levelData);
                    double distance = element.DistanceFromPlayer(levelData.Player.CoordX, levelData.Player.CoordY, element.CoordX, element.CoordY);
                    double drawRange = 5;
                    if (distance < drawRange)
                    {
                        element.Draw(element);
                    }
                    else element.Delete();
                }
                else if (element is Snake)
                {
                    (element as Snake).Update(element, levelData.Elements, levelData, levelData.Player.CoordX, levelData.Player.CoordY);
                    double distance = element.DistanceFromPlayer(levelData.Player.CoordX, levelData.Player.CoordY, element.CoordX, element.CoordY);
                    double drawRange = 5;
                    if (distance < drawRange)
                    {
                        element.Draw(element);
                    }
                    else element.Delete();

                }
                else if (element is Wall)
                {
                    double distance = element.DistanceFromPlayer(levelData.Player.CoordX, levelData.Player.CoordY, element.CoordX, element.CoordY);
                    double drawRange = 5;
                    if (distance < drawRange)
                    {
                        element.Draw(element);
                    }
                }
            }
            isPlayerAlive = levelData.Player.IsAlive;
        }
        //Console.Clear();
        //Console.WriteLine("Game Over");
    }
}

