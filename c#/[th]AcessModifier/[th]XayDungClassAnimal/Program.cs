using System;

namespace _th_XayDungClassAnimal
{
    class Program
    {
        static void Main(string[] args)
        {
            Cat cat = new Cat("20kg", "1.5", "Kitty");
            cat.PrintInfo();
            Console.ReadKey();
        }
    }
}
