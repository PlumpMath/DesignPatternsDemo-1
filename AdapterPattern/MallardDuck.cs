using System;
using AdapterPattern.Interfaces;

namespace AdapterPattern
{
    public class MallardDuck : IDuck
    {
        public void Quack()
        {
            Console.WriteLine("Quack");
        }

        public void Fly()
        {
            Console.WriteLine("I'm flying");
        }

        public void CatchFish()
        {
            Console.WriteLine("I'm diving to catch fish");
        }
    }
}
