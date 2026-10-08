namespace PersonalRegister
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Personal Register!");

            List<Employee> employees = new List<Employee>();

            bool exit = false;
            string input = string.Empty;

            while (!exit)
            {
                PrintMenu();
                input = Console.ReadLine();
                int option = 0;
                try
                {
                    option = int.Parse(input);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                    continue;
                }
                if (option == 1)
                {
                    employees.Add(AddEmployee());
                }
                else if (option == 2)
                {
                    PrintEmployeeList(employees);
                }
                else if (option == 3)
                {
                    if (employees.Count == 0) {
                        Console.WriteLine("No employees to update.");
                        continue;
                    }
                    UpdateEmployeeSalary(employees);
                }
                else if (option == 4) {
                    exit = true;
                }
                else {
                    Console.WriteLine("Invalid option. Please try again.");
                }
            }

            Console.WriteLine("Exiting program!");
        }

        static void UpdateEmployeeSalary(List<Employee> employees)
        {
            Employee e;
            int index;
            try
            {
                Console.WriteLine("Enter the index of the employee whose salary you want to update (0-indexing)");
                Console.Write(">");
                index = int.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input");
                return;
            }
            if (index < 0 || index >= employees.Count)
            {
                Console.WriteLine("Index out of bounds");
                return;
            }
            e = employees[index];
            int newSalary;
            try
            {
                Console.WriteLine("Enter the new salary for " + e.Name);
                Console.Write(">");
                newSalary = int.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input");
                return;
            }
            e.ChangeSalary(newSalary);
            Console.WriteLine(e.Name + "'s salary was updated to " + newSalary);
        }

        static void PrintEmployeeList(List<Employee> employees) {
            if (employees.Count == 0)
            {
                Console.WriteLine("No employees to display.");
            }
            else {
                Console.WriteLine("--- Employees ---");
                foreach (var e in employees)
                {
                    Console.WriteLine("Name: " + e.Name + ", Salary: " + e.Salary);
                }
            }
        }

        static Employee AddEmployee() {
            string name = string.Empty;
            while (string.IsNullOrEmpty(name)) {
                Console.WriteLine("Type the new Employees name.");
                Console.Write(">");
                name = Console.ReadLine();
            }
            int salary = 0;
            bool validSalary = false;
            while (!validSalary) {
                Console.WriteLine("Type " + name + "'s salary.");
                Console.Write(">");
                try
                {
                    salary = int.Parse(Console.ReadLine());
                    validSalary = true;
                }
                catch (FormatException) {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                    continue;
                }
            }
            return new Employee(name, salary);
        }

        static void PrintMenu() {
            Console.WriteLine();
            Console.WriteLine("Choose an action:");
            Console.WriteLine("1. Add employee");
            Console.WriteLine("2. View employees");
            Console.WriteLine("3. Update employee salary");
            Console.WriteLine("4. Exit");
            Console.Write(">");
        }
    }
}
