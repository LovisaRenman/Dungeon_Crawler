
class Gameloop 
{
    public void PlayGame()
    {
        Console.CursorVisible = false;
        LevelData levelData = new();
        levelData.Load(@"Level\Level1.txt");

        int turn = 0;
        bool isPlayerAlive = true;
        while (isPlayerAlive)
        {
            levelData.Player.Draw(levelData.Player);
            levelData.Player.Update(levelData.Player, levelData.Elements, levelData);


            foreach (LevelElement element in levelData.Elements)
            {
                double drawRange = 5;
                double distance = element.DistanceFromPlayer(levelData.Player.CoordX, levelData.Player.CoordY, element.CoordX, element.CoordY);
                if (element is Rat rat)
                {                            
                    rat.Update(element, levelData.Elements, levelData);
                    if (distance <= drawRange)
                    {
                        element.Draw(element);
                    }
                    else element.Delete();
                }
                else if (element is Snake snake)
                {
                    snake.Update(element, levelData.Elements, levelData, levelData.Player.CoordX, levelData.Player.CoordY);                  
                    if (distance <= drawRange)
                    {
                        element.Draw(element);
                    }
                    else element.Delete();

                }
                else if (element is Wall)
                {
                    if (distance <= drawRange)
                    {
                        element.Draw(element);
                    }
                }
            }
            turn++;
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(0, 0);
            Console.WriteLine($"Player: @ \t HealthPoints: {levelData.Player.HealthPoints} \t Turn: {turn}");

            foreach (var enemy in levelData.enemiesToRemove)
            {
                levelData.RemoveEnemy(enemy);
            }

            isPlayerAlive = levelData.Player.IsAlive;
        }
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Game Over!");
    }
}