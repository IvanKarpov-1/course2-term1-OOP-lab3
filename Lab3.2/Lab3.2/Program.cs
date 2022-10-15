using PL;
using System.Text;
using System;

namespace Lab3._2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Default;
            Console.InputEncoding = Encoding.Default;

            var menu = new Menu();
            menu.MainMenu();
        }
    }
}
