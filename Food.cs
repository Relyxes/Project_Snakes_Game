using System;

namespace Project_Mario_game
{
    public class Food
    {
        private int x;
        private int y;
        private char symbol;
        private string color = "WHITE";

        public Position food {get; set;}

        Random _random = new Random();

        public Food(int x, int y, char symbol)
        {
            this.x = x;
            this.y = y;
            this.symbol = symbol;
        }

        public void CreateFood()
        {
            food = new Position(_random.Next(1, x - 1), _random.Next(1, y - 1), symbol,color);
            food.Draw();
        }

    }
}