using System;

namespace Project_Mario_game
{
    public class Window
    {
        private int _width = 50;
        private int _height = 12;
        public Window() { }

        public Window(int width, int height)
        {
            _width = width;
            _height = height;
        }
        public void Window_Properties(int width, int height)
        {
            Console.SetWindowSize(width + 1, height + 1);
            Console.SetBufferSize(width + 1, height + 1);
            Console.Title = "Snake_Game";
        }

    }
}