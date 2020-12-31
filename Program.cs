using ApiAccessor;
using System;

namespace ACCESSOR
{
    class Program
    {
        static void Main(string[] args)
        {
            PersonAccessor personAccessor = new PersonAccessor();

            Console.WriteLine("Welcome here!" + Environment.NewLine);

            Console.WriteLine("Initializing client...");
            ApiHelper.InitializeClient();
            Console.WriteLine("Client was successfully initialized!");


        }
    }
}
