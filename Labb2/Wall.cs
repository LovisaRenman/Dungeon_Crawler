
class Wall : LevelElement
{
    public Wall(int xCord, int yCord)
    {
        CharacterChar = '#';
        CharacterColor = ConsoleColor.White;

        CoordX = xCord;
        CoordY = yCord;
    }
}