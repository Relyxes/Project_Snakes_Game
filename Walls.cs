using System.Collections.Generic;
using System.Linq;

namespace Project_Mario_game
{
    public class Walls
    {
        private char point;
        private string color = "WHITE";
        private List<Position> walls = new List<Position>();
        public Walls(int x, int y, char point)
        {
            this.point = point;
            DrawHorizontal(x, 0);
            DrawHorizontal(x, y);
            DrawVertical(0,y);
            DrawVertical(x,y+1);
        }

        private void DrawHorizontal(int x, int y)
        {
            for (int i = 0; i < x; i++)
            {
                Position position = new Position(i, y, point,color);
                position.Draw();
                walls.Add(position);
            }
        }

        private void DrawVertical(int x, int y)
        {
            for (int i = 0; i < y; i++)
            {
                Position position = new Position(x, i, point,color);
                position.Draw();
                walls.Add(position);
            }
        }

        public bool IsWall(Position position)
        {
            foreach (Position wall in walls)
            {
                if (position == wall)
                {
                    return true;
                }
            }

            return false;
        }
    }
}