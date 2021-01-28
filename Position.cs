using System;

namespace Project_Mario_game
{
    public struct Position
    {
        public int x { get; set; }
        public int y { get; set; }
        public char point { get; set; }

        public string color { get; set; }

        public static bool operator ==(Position a, Position b) => (a.x == b.x && a.y == b.y);
        public static bool operator !=(Position a, Position b) => (a.x != b.x || a.y != b.y);

        public Position(int x, int y, char point, string color)
        {
            this.x = x;
            this.y = y;
            this.point = point;
            this.color = color;
        }

      public void Draw()
        {
            DrawPoint(point,Option._color);
        }

        public void Clear()
        {
            DrawPoint(' ', color);
        }

        private void DrawPoint(char point, string color)
        {

            Console.SetCursorPosition(x,y);
            Console.Write(point);

        }

    }
}