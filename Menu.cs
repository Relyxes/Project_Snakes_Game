using System;


namespace Project_Mario_game
{
    public class Menu
    {
        internal static int _top = 1;
        internal static int _left = 20;
        private static bool _exit;
        private bool _newGame;
        private bool _options;
        private bool _score;

        public Menu() { }

        public Menu(int left, int top)
        {
            _top = top;
            _left = left;
        }

        public void Show_Menu()
        {
            Window window = new Window();
            window.Window_Properties(40,10);
            _top = 1;
            Console.Clear();

            Console.SetCursorPosition(_left, _top);
            Console.Write("New Game");
            Console.SetCursorPosition(_left, _top+1);
            Console.Write("Score");
            Console.SetCursorPosition(_left, _top+2);
            Console.Write("Options");
            Console.SetCursorPosition(_left, _top+3);
            Console.Write("Exit");
            Scroll_Cursor_Position();
        }

        public void Set_Cursor_Position(int left, int top)
        {
            Console.CursorVisible = false;
            Console.SetCursorPosition(_left-3, _top);
            Console.Write("->");
        }

        public void Scroll_Cursor_Position()
        {

            Set_Cursor_Position(_left, _top);

            ConsoleKeyInfo key = new ConsoleKeyInfo();

            while (!_exit)
            {
                key = Console.ReadKey();

                if (key.Key == ConsoleKey.DownArrow)
                {
                    Console.SetCursorPosition(_left-3,_top);
                    Console.Write("  ");
                    _top++;
                    if (_top >= 4) _top = 4;
                }
                else if (key.Key == ConsoleKey.UpArrow)
                {
                    Console.SetCursorPosition(_left-3,_top);
                    Console.Write("  ");
                    _top--;
                    if (_top <= 1) _top = 1;
                }
                else if (key.Key == ConsoleKey.Enter)
                {
                    switch (_top)
                    {
                        case 1:
                            NewGame();
                            break;
                        case 2:
                            Scores();
                            break;
                        case 3:
                            Options();
                            break;
                        case 4:
                            _exit = Exit();
                            break;
                    }
                }
                Set_Cursor_Position(_left, _top);
            }
        }

        public bool Exit()
        {
            bool exit = true;
            return exit;
        }

        private bool Options()
        {
            _options = true;
            Option option = new Option();
            option.ShowProperties(1);
            option.Scroll_Cursor_Position();
            return _options;
        }

        private bool Scores()
        {
            _score = true;
            Console.SetCursorPosition(10,6);
            Score.ShowPoints("TEST");
            return _score;
        }

        private bool NewGame()
        {
            _newGame = true;
            Game game = new Game();
            game.Start();
            game.EndGame();
            Show_Menu();
            return _newGame;
        }
    }
}