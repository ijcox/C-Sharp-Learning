using System;

class Gradebook
{
    static string GetFullName()
    { 
        Console.WriteLine("\nEnter First Name: ");
        string? firstName = Console.ReadLine();
        Console.WriteLine("\nEnter Last Name: ");
        string? lastName = Console.ReadLine();
        string fullName = firstName + " " + lastName;
        Console.WriteLine("{0}", fullName);
        return fullName;
    }


    static List<int> GetGrades()
    {
        List<int> grades = new List<int>();
        Console.WriteLine("\nEnter a new grade, or type enter to exit: ");
        string? input = Console.ReadLine();
        if ((Convert.ToInt32(input) > 0) && (Convert.ToInt32(input) < 100) && (input != ""))
        { 
            grades.Add(Convert.ToInt32(input));
        }
        while (input != "")
        {
            Console.WriteLine("Enter a new grade (0-100), or type enter to exit: ");
            input = Console.ReadLine();
            int value;
            if (!int.TryParse(input, out value))
            {
                Console.WriteLine("Returning to main menu...");
            }
            else if ((value < 0) || (value > 100))
            {
                Console.WriteLine("Please enter a grade between 0 and 100.");
            }
            else
            {
                grades.Add(Convert.ToInt32(value));
            }
        }
        return grades;

    }

    static void Main(string[] args)
    {
        bool isQuit = false;
        Dictionary<string, List<int>> gradebook = new Dictionary<string, List<int>>();
        while (!isQuit)
        {
            Console.WriteLine("\n1. Add Gradebook Entry\n2. View Student Averages\n3. Quit\nEnter a number to select an option: ");
            int input = Convert.ToInt32(Console.ReadLine());


            switch (input)
            {
                case 1:
                    string name = GetFullName();
                    List<int> grades = GetGrades();
                    gradebook.Add(name, grades);
                    break;
                case 2:
                    Console.WriteLine("\nList of Existing Students: ");
                    foreach (var student in gradebook)
                    {
                        double average = student.Value.Average();
                        if (average > 60)
                        {
                            Console.WriteLine("\n{0}, Average Grade: {1}", student.Key, double.Round((average), 2).ToString());
                        }
                        else
                        {
                            Console.WriteLine("\n{0}, Average Grade: {1} ---------- Failing", student.Key, double.Round((average), 2).ToString());
                        }
                    }
                    Console.WriteLine("\n---------------------------------------------------");
                    break;
                case 3:
                    isQuit = true;
                    return;
                default:
                    Console.WriteLine("\n--- Invalid Input, Try Again ---");
                    break;

            }
        }

    }
}