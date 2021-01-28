using System;
using System.Collections.Generic;
using System.Linq;

namespace Project_Mario_game
{
    public class Snake
    {
        public List<Position> snake;
        private Direction _direction;
        private int step = 1;
        private Position tail;
        private Position head;
        private bool rotate = true;

        public Snake(int x, int y, int length)
        {
            _direction = Direction.RIGHT;
            snake = new List<Position>();
            for (int i = x-length; i < x; i++)
            {
                Position position = new Position(i,y,'o',Option._color);
                snake.Add(position);
                position.Draw();
            }
        }

        public void Move()
        {
            head = GetNextPoint();
            snake.Add(head);
            tail = snake.First();
            snake.Remove(tail);
            tail.Clear();
            head.Draw();
            rotate = true;
        }

        public bool IsTail(Position position)
        {
            for (int i = snake.Count - 2; i > 0; i--)
            {
                if (snake[i] == position) return true;
            }
            return false;
        }

        public bool Eat(Position position)
        {
            head = GetNextPoint();
            if (head == position)
            {
                snake.Add(head);
                head.Draw();
                return true;
            }
            return false;
        }

        public Position GetHead() => snake.Last();
        public  Position GetNextPoint()
        {
            Position position = GetHead();
            switch (_direction)
            {
                case Direction.UP:
                    position.y -= step;
                    break;
                case Direction.DOWN:
                    position.y += step;
                    break;
                case Direction.LEFT:
                    position.x -= step;
                    break;
                case Direction.RIGHT:
                    position.x += step;
                    break;

            }

            return position;
        }

        public void Rotation(ConsoleKey key)
        {
            if (rotate)
            {
                switch (_direction)
                {
                    case Direction.LEFT:
                        case Direction.RIGHT:
                        if (key == ConsoleKey.DownArrow) _direction = Direction.DOWN;
                        else if (key == ConsoleKey.UpArrow) _direction = Direction.UP;
                    break;
                    case Direction.UP:
                    case Direction.DOWN:
                        if (key == ConsoleKey.LeftArrow) _direction = Direction.LEFT;
                        else if (key == ConsoleKey.RightArrow) _direction = Direction.RIGHT;
                        break;

                }
            }
            rotate = false;
        }
    }
}