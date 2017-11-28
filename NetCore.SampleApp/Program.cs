using System;
using System.Threading;

namespace NetCore.SampleApp
{
    class Program
    {
        private static Random Random;

        static void Main(string[] args)
        {
            Random = new Random();
            for (var i = 0; i < int.MaxValue; i++)
            {
                Console.WriteLine(i);
                if (Random.Next(10) == 5)
                    throw new Exception();
                Thread.Sleep(3000);
            }
        }
    }
}