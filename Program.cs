using System;
using System.Threading.Tasks;

namespace Project_Mario_game
{
    internal class Program
    {


        public static void Main(string[] args)
        {
            Menu menu = new Menu();
            menu.Show_Menu();
            menu.Scroll_Cursor_Position();
        }


    }
}