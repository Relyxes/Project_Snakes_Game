

using System;

namespace Project_Mario_game
{
    public class Score
    {
        private static string userID;
        public static double _points;

        public Score(){}

        Score(string userID, double points)
        {
            UserID = userID;
            _points = points;
        }

        private static string UserID
        {
            get { return userID; }
            set
            {
                if (value.Length > 10) Console.WriteLine("Не более 10 знаков.");
                else UserID = value;
            }
        }

        public double ChangePoints()
        {
            _points++;
            return _points;
        }

        public void ShowPoints()
        {
            Position position = new Position(5,10,'>',Option._color);
            Console.WriteLine("Your last scores: {0}",_points);
        }

        public static void ShowPoints(string userID)
        {
            Position position = new Position(5,10,'>',Option._color);
            Console.WriteLine("User {1} last scores: {0}",_points, userID);
        }
    }
}