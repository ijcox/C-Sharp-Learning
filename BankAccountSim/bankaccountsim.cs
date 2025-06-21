using System;
using System.Collections.Generic;

class BankAccount
{
    public string Owner { get; private set; }
    public decimal Balance { get; private set; }

    public BankAccount(string owner, decimal initialBalance)
    {
        Owner = owner;
        Balance = initialBalance;
    }

    public void Deposit(decimal amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("Cannot deposit a non-positive amount.");
            return;
        }

        Balance += amount;
        Console.WriteLine($"Deposited {amount:C} into {Owner}'s account. New balance: {Balance:C}");
    }

    public void Withdraw(decimal amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("Cannot withdraw a non-positive amount.");
            return;
        }
        if (amount > Balance)
        {
            Console.WriteLine("Insufficient funds.");
            return;
        }

        Balance -= amount;
        Console.WriteLine($"Withdrew {amount:C} from {Owner}'s account. New balance: {Balance:C}");
    }

    public void Transfer(BankAccount target, decimal amount)
    {
        if (target == null)
        {
            Console.WriteLine("Invalid target account.");
            return;
        }

        if (amount <= 0)
        {
            Console.WriteLine("Cannot transfer a non-positive amount.");
            return;
        }

        if (amount > Balance)
        {
            Console.WriteLine("Insufficient funds to transfer.");
            return;
        }

        this.Withdraw(amount);
        target.Deposit(amount);
        Console.WriteLine($"Transferred {amount:C} from {Owner} to {target.Owner}.");
    }

    public override string ToString()
    {
        return $"{Owner}: Balance = {Balance:C}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<BankAccount> accounts = new List<BankAccount>();
        bool quit = false;

        while (!quit)
        {
            Console.WriteLine("\nSelect an option:\n1. Create Account\n2. Deposit\n3. Withdraw\n4. Transfer\n5. View Accounts\n6. Quit");
            Console.Write("Choice: ");
            string? choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    if (accounts.Count >= 2)
                    {
                        Console.WriteLine("Maximum of 2 accounts reached.");
                        break;
                    }
                    Console.Write("Enter first name: ");
                    string first = Console.ReadLine() ?? "";
                    Console.Write("Enter last name: ");
                    string last = Console.ReadLine() ?? "";
                    string fullName = first + " " + last;

                    accounts.Add(new BankAccount(fullName, 100));
                    Console.WriteLine($"Account created for {fullName} with $100 starting balance.");
                    break;

                case "2":
                    BankAccount? depositAcc = SelectAccount(accounts);
                    if (depositAcc != null)
                    {
                        Console.Write("Enter amount to deposit: ");
                        decimal deposit = Convert.ToDecimal(Console.ReadLine());
                        depositAcc.Deposit(deposit);
                    }
                    break;

                case "3":
                    BankAccount? withdrawAcc = SelectAccount(accounts);
                    if (withdrawAcc != null)
                    {
                        Console.Write("Enter amount to withdraw: ");
                        decimal withdrawal = Convert.ToDecimal(Console.ReadLine());
                        withdrawAcc.Withdraw(withdrawal);
                    }
                    break;

                case "4":
                    Console.WriteLine("Transfer from:");
                    BankAccount? from = SelectAccount(accounts);
                    Console.WriteLine("Transfer to:");
                    BankAccount? to = SelectAccount(accounts);
                    if (from != null && to != null && from != to)
                    {
                        Console.Write("Enter amount to transfer: ");
                        decimal transfer = Convert.ToDecimal(Console.ReadLine());
                        from.Transfer(to, transfer);
                    }
                    else
                    {
                        Console.WriteLine("Invalid accounts selected.");
                    }
                    break;

                case "5":
                    if (accounts.Count == 0)
                    {
                        Console.WriteLine("No accounts found.");
                    }
                    else
                    {
                        for (int i = 0; i < accounts.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}: {accounts[i]}");
                        }
                    }
                    break;

                case "6":
                    quit = true;
                    break;

                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }
    }

    static BankAccount? SelectAccount(List<BankAccount> accounts)
    {
        if (accounts.Count == 0)
        {
            Console.WriteLine("No accounts available.");
            return null;
        }

        for (int i = 0; i < accounts.Count; i++)
        {
            Console.WriteLine($"{i + 1}: {accounts[i].Owner}");
        }

        Console.Write("Select account by number: ");
        string? input = Console.ReadLine();
        if (int.TryParse(input, out int index) && index > 0 && index <= accounts.Count)
        {
            return accounts[index - 1];
        }

        Console.WriteLine("Invalid selection.");
        return null;
    }
}

