using System;

namespace CheckOutTerminal
{
    public class View
    {
        public void Greeting()
        {
            Console.WriteLine("Welcome to the super market please enter your order");
            Console.WriteLine("your order can be from cost codes a,b,c or d");
            Console.WriteLine("please start your order : ");
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
                    Console.WriteLine($"your total is {output}");
                    Console.WriteLine("Enter Products : ");

                }
            }

        }

    }
}
