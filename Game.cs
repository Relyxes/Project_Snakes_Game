using System;
using System.Threading;
using System.Threading.Tasks;
namespace Project_Mario_game
{
    public class Game
    {
        private static Walls _walls;
        private static Food _food;
        private static Snake _snake;
        private static Score _score;
        private static ConsoleKeyInfo _key;
        private static Task _taskAction;
        private static bool _isStart;

        public Game()
        {
        }

        public static void TaskAction()
        {
            while (_isStart)
            {
                if (Console.KeyAvailable)
                {
                    _key = Console.ReadKey(true);
                    _snake.Rotation(_key.Key);
                }
            }
        }


        public void Start()
        {
            Console.Clear();
            Console.WriteLine("Для начала нажмите \nклавишу \"Enter\"");
            Console.Read();
            Console.Clear();

            _food = new Food(21, 11, 'o');
            _snake = new Snake(10, 5, Option._length);
            _walls = new Walls(30, 10, '|');
            _score = new Score();
            Score._points = 0;
            _key = new ConsoleKeyInfo();

            _food.CreateFood();
            _isStart = true;
            _taskAction = new Task(TaskAction);
            _taskAction.Start();

            while (_isStart)
            {
                int points = Convert.ToInt32(Score._points)*20;
                Thread.Sleep(550-Option._speed*50-points);

                if (_walls.IsWall(_snake.GetHead()) || _snake.IsTail(_snake.GetHead())
                                                    || _key.Key == ConsoleKey.Backspace)
                {
                    EndGame();
                }
                else if (_snake.Eat(_food.food))
                {
                    _score.ChangePoints();
                    _food.CreateFood();
                }
                else
                {
                    _snake.Move();
                }
            }
        }

        public void EndGame()
        {
            _isStart = false;
            Console.Clear();
            Console.WriteLine("Game Over");
            _score.ShowPoints();
            Console.ReadLine();
        }
    }
}