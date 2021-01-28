using System;
using System.Collections.Generic;

namespace Project_Mario_game
{
    public class Option
    {
        internal static int _speed = 1;
        internal static int _length = 3;
        internal static int _colorPosition;
        internal static string _color = "WHITE";

        internal static int _top = 1;
        internal static int _left = 20;
        private static bool _back;


        private List<string> colors = new List<string>()
        {
            "WHITE",
            "RED",
            "GREEN",
            "BLUE",
            "YELLOW"
        };

        public Option()
        {
        }

        public Option(int speed, int length, string color)
        {
            _speed = speed;
            _length = length;
            _color = color;
        }

        private int Length
        {
            get { return _length;}
            set
            {
                if (value <= 0) _length = 0;
                _length = value > 5 ? 5 : _length = value;
            }
        }

        private string Color
        {
            get { return _color; }
            set
            { _color = value; }
        }

        private int Speed
        {
            get { return _speed; }
            set
            {
                if (value < 1) _speed = 1;
                _speed = value > 10 ? 10 : _speed = value;
            }
        }

        public void Set_Cursor_Position(int left, int top)
        {
            Console.CursorVisible = true;
            Console.SetCursorPosition(_left-3, _top+1);
            Console.Write("->");
        }

      public new void Scroll_Cursor_Position()
        {
            Set_Cursor_Position(_left, _top+3);
            ConsoleKeyInfo key = new ConsoleKeyInfo();


            while (!_back)
            {
                key = Console.ReadKey();
                int varTop = _top;

                if (key.Key == ConsoleKey.DownArrow)
                {
                    Console.SetCursorPosition(_left-3,_top+1);
                    Console.Write("  ");
                    _top++;
                    if (_top >= 4) _top = 5;
                }
                else if (key.Key == ConsoleKey.UpArrow)
                {
                    Console.SetCursorPosition(_left-3,_top+1);
                    Console.Write("  ");
                    _top--;
                    if (_top <= 1) _top = 1;
                    else if (_top == 4) _top = 3;
                }
                else if (key.Key == ConsoleKey.Backspace || key.Key == ConsoleKey.Enter && _top == 5)
                {
                        Menu menu = new Menu();
                        menu.Show_Menu();
                        _back = true;
                }
                else if (key.Key == ConsoleKey.RightArrow || key.Key == ConsoleKey.LeftArrow)
                {

                    switch (_top)
                    {
                        case 1:
                            ChangeSpeed(key.Key);
                            break;
                        case 2:
                            ChangeLength(key.Key);
                            break;
                        case 3:
                            ChangeColor(key.Key);
                          break;
                    }
                    ShowProperties(_top);
                }

                Set_Cursor_Position(_left, _top);
            }
        }

        public  void ShowProperties(int lastCursorPosition)
        {
            _top = 1;
            Console.Clear();
            Console.SetCursorPosition(_left-4, _top);
            Console.Write("--Параметры змейки--");
            Console.SetCursorPosition(_left, _top+1);
            Console.Write("Скорость: {0}",_speed);
            Console.SetCursorPosition(_left, _top+2);
            Console.Write("Длина: {0}",_length);
            Console.SetCursorPosition(_left, _top+3);
            Console.Write("Цвет: {0}",_color);

            Console.SetCursorPosition(_left, _top+5);
            Console.Write("Назад");
            _top = lastCursorPosition;
        }

        public void ChangeSpeed(ConsoleKey consoleKey)
        {
            if (consoleKey == ConsoleKey.LeftArrow && _speed > 1) { _speed--; }
            else if (consoleKey == ConsoleKey.RightArrow && _speed < 10)  { _speed++; }
        }

        public void ChangeLength(ConsoleKey consoleKey)
        {
            if (consoleKey == ConsoleKey.LeftArrow && _length > 3) { _length--; }
            else if (consoleKey == ConsoleKey.RightArrow && _length < 10) { _length++; }
        }

        public string ChangeColor(ConsoleKey consoleKey)
        {
            if (consoleKey == ConsoleKey.LeftArrow && _colorPosition > 0) { _colorPosition--; }
            else if (consoleKey == ConsoleKey.RightArrow && _colorPosition < colors.Count-1) { _colorPosition++; }
           _color = colors[_colorPosition];

           switch (_color)
           {
               case "RED":
                   Console.ForegroundColor = ConsoleColor.Red;
                   break;
               case "GREEN":
                   Console.ForegroundColor = ConsoleColor.Green;
                   break;
               case "BLUE":
                   Console.ForegroundColor = ConsoleColor.Blue;
                   break;
               case "YELLOW":
                   Console.ForegroundColor = ConsoleColor.Yellow;
                   break;
               default:
                   Console.ForegroundColor = ConsoleColor.White;
                   break;
           }

           return _color;
        }

    }


}