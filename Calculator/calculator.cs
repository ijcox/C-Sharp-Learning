using System;

class Caclulator
{
    static void Main(string[] args)
    {
        bool isQuit = false;

        while (isQuit == false)
        {
            Console.WriteLine("\n1. +\n2. -\n3. *\n4. /\n5. Quit\nEnter a number (1-5) to select an operation: ");

            int input = Convert.ToInt32(Console.ReadLine()); //takes user input
            string result;

            switch (input)
            {
                case 1:
                    Console.WriteLine("Enter two numbers to add: ");
                    result = Add().ToString("0.####");
                    Console.WriteLine("Result = {0}", result);
                    break;
                case 2:
                    Console.WriteLine("Enter two numbers to subtract: ");
                    result = Sub().ToString("0.####");
                    Console.WriteLine("Result = {0}", result);
                    break;
                case 3:
                    Console.WriteLine("Enter two numbers to multiply: ");
                    result = Mul().ToString("0.####");
                    Console.WriteLine("Result = {0}", result);
                    break;
                case 4:
                    Console.WriteLine("Enter two numbers to division: ");
                    result = Div().ToString("0.####");
                    Console.WriteLine("Result = {0}", result);
                    break;
                case 5:
                    isQuit = true;
                    return;
                default:
                    Console.WriteLine("\n---- Invalid Input! ----");
                    break;

            }
        }
    }
    static float Add()
    {
        float n1 = GetFloatFromUser("First number: ");
        float n2 = GetFloatFromUser("Second number: ");
        float n3 = n1 + n2;
        return n3;
    }
    static float Sub()
    {
        float n1 = GetFloatFromUser("First number: ");
        float n2 = GetFloatFromUser("Second number: ");
        float n3 = n1 - n2;
        return n3;
    }
    static float Mul()
    {
        float n1 = GetFloatFromUser("First number: ");
        float n2 = GetFloatFromUser("Second number: ");
        float n3 = n1 * n2;
        return n3;
    }
    static float Div()
    {
        float n1 = GetFloatFromUser("First number: ");
        float n2 = GetFloatFromUser("Second number: ");
        float n3 = n1 / n2;
        return n3;
    }
    static float GetFloatFromUser(string prompt)
    {
    float result;
    while (true)
    {
        Console.Write(prompt);
        string? input = Console.ReadLine();

        if (float.TryParse(input, out result))
            return result;

        Console.WriteLine("Invalid input. Please enter a valid number.");
    }
}

}
