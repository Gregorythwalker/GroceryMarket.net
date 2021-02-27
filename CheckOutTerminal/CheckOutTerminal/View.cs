using System;

namespace CheckOutTerminal
{
    public class View
    {
        public void Greeting()
        {
            Console.WriteLine("Welcome to the super market please enter your order");
            Console.WriteLine("Your order can be from cost codes a,b,c or d");
            Console.WriteLine("Type done to quit application");
            Console.WriteLine("Please start your order : ");
            performValidation();
        }

        public void performValidation()
        {
            while (true) // Loop indefinitely
            {
                string input = Console.ReadLine().ToUpper(); // Get string from user type safety put everything in upper case

                if (input == "DONE") // Check string
                {
                    break;
                }
                else
                {                   
                    var pricingRepo = new PricingRepository();
                    var checkOutService = new CheckOutTerminalService(pricingRepo);
                    var output = checkOutService.CheckOut(input);
                    Console.WriteLine($"Your total is {output}");
                    Console.WriteLine("Enter Products : ");

                }
            }

        }

    }
}
