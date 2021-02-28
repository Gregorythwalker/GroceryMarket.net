using System;

namespace CheckOutTerminal
{
    public class View
    {
        public void Greeting()
        {
            //console greeting when library is called
            Console.WriteLine("Welcome to the super market please enter your order");
            Console.WriteLine("Your order can be from cost codes a,b,c or d");
            Console.WriteLine("Type done to quit application");
            Console.WriteLine("Please start your order : ");
            performValidation();
        }

        public void performValidation()
        {
            while (true) // Loop indefinitely until done is entered
            {
                string input = Console.ReadLine().ToUpper(); // Get string from user put everything into upper case

                if (input == "DONE") // Check string to end loop
                {
                    break;
                }
                else
                {
                    //initialize pricing repo object and pass it to the check out service to use
                    var pricingRepo = new PricingRepository();
                    var checkOutService = new CheckOutTerminalService(pricingRepo);
                    var output = checkOutService.CheckOut(input);
                    //write returned totals to console
                    Console.WriteLine($"Your total is {output}");
                    Console.WriteLine("Enter Products : ");

                }
            }

        }

    }
}
