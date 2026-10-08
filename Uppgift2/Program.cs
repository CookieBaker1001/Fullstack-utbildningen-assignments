namespace Uppgift2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool running = true;
            int choice;

            while (running)
            {
                PrintMenu();
                choice = PromptChoice();
                switch (choice)
                {
                    case 0:
                        running = false;
                        break;
                    case 1:
                        AgeCalculator();
                        break;
                    case 2:
                        MultiplePeople();
                        break;
                    case 3:
                        Repeat10Times();
                        break;
                    case 4:
                        TheThirdWord();
                        break;
                    default:
                        Console.WriteLine("Felaktigt val.");
                        break;
                }
            }
        }

        /*
            Determines the price of a movie ticket based on the age of the user and prints
            the price to the console.
         */
        static void AgeCalculator()
        {
            Console.WriteLine("Ange ålder:");
            Console.Write(">");

            string? input = Console.ReadLine();
            int age;
            if (!int.TryParse(input, out age))
            {
                Console.WriteLine("Inte en giltig ålder.");
                return;
            }

            if (age <= 5) Console.WriteLine("Barn under 5 år får gå gratis.");
            else if (age < 20) Console.WriteLine("Ungdomspris: 80kr");
            else if (age <= 65) Console.WriteLine("Standardpris: 120kr");
            else if (age < 100) Console.WriteLine("Pensionärspris: 90kr");
            else Console.WriteLine("Pensionärer över 100 år får gå gratis.");
        }

        /*
            Allows for multiple people to enter their ages and the resulting total price is 
            calculated and printed to the console.
         */
        static void MultiplePeople()
        {
            Console.WriteLine("Ange antal personer som önskar gå på bio.");
            Console.Write(">");

            string? input = Console.ReadLine();
            int peopleCount;
            if (!int.TryParse(input, out peopleCount))
            {
                Console.WriteLine("Inte ett giltigt antal personer.");
                return;
            }
            int sum = 0;
            int age;
            for (int i = 0; i < peopleCount; i++)
            {
                Console.WriteLine("Ange ålder för person " + (i + 1) + ".");
                if (!int.TryParse(Console.ReadLine(), out age))
                {
                    Console.WriteLine("Inte en giltig ålder.");
                    return;
                }
                if (age <= 5) continue;
                else if (age < 20) sum += 80;
                else if (age <= 65) sum += 90;
                else if (age < 100) sum += 120;
            }
            Console.WriteLine("--- Kvitto ---");
            Console.WriteLine("Antal personer: " + peopleCount);
            Console.WriteLine("Total kostnad: " + sum + "kr");
        }

        /*
            Takes a string input from the user and peints it to the console 10 times
         */
        static void Repeat10Times()
        {
            Console.WriteLine("Ange en text som ska upprepas 10 gånger.");
            Console.Write(">");
            string input = Console.ReadLine();
            for (int i = 0; i < 10; i++)
            {
                Console.Write((i + 1) + ". " + input + ", ");
            }
        }
        /*
            Determines the third word in an input string from the user and outputs
            it to the console, if there is one.
        */
        static void TheThirdWord()
        {
            Console.WriteLine("Skriv en mening/fras på minst tre ord.");
            Console.Write(">");
            var input = Console.ReadLine();

            if (input is not string)
            {
                Console.WriteLine("Inte en sträng!");
                return;
            }
            var words = input.Split(' ');
            string word3 = "";
            int index = 0;
            for (int i = 0; i < words.Length; i++)
            {
                if (string.IsNullOrEmpty(words[i])) continue;
                word3 = words[i];
                index++;
                if (index == 3) break;
            }
            if (index < 3)
            {
                Console.WriteLine("För få ord.");
                return;
            }

            Console.WriteLine("Det tredje ordet är: " + word3);
        }

        /*
            Prints the menu to the console since it is a reoccurring task.
        */
        static void PrintMenu()
        {
            string menu = "\n --- Huvudmeny --- \n" +
                "Var god välj ett alternativ.\n" +
                "0: Avsluta\n" +
                "1: Ungdom eller pensionär\n" +
                "2: Sällskap på bio\n" +
                "3: Upprepa 10 gånger\n" +
                "4: Det tredje ordet";
            Console.WriteLine(menu);
        }

        /*
            Asks the user for their choice when faced with the menu.
        */
        static int PromptChoice()
        {
            Console.Write(">");

            int result = 0;
            string? choice = Console.ReadLine();
            if (!int.TryParse(choice, out result))
            {
                return -1;
            }
            return result;
        }
    }
}
