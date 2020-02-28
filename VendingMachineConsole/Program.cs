using System;

namespace VendingMachineConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to your Vending Machine");

            var machine = new VendingMachine.VendingMachine();

            Console.WriteLine("Buying Coke (25)");

            Console.WriteLine("Inserting (10)");
            machine.AddCash(10);

            Console.WriteLine("Inserting (10)");
            machine.AddCash(10);

            Console.WriteLine("Inserting (5)");
            machine.AddCash(5);

            Console.WriteLine("Selecting Coke");
            machine.SelectProduct("Coke");

            Console.WriteLine("Purchasing...");
            var (item1, item2) = machine.Purchase();


            Console.WriteLine($"Your Item is {item1} and your change is {item2}");

            Console.WriteLine("Thank you!");

            Console.ReadLine();
        }
    }
}
