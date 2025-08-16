namespace Banking_System;
public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("WelCome to Banking System!");
        Repository<BankAccount> repository = new();
        BankingService bankingService = new(repository);
        int input = 0;
        do
        {
            Console.WriteLine("1. Create Account\n2. Deposit\n3. Withdraw\n4. View All Accounts\n5. Run Analytics (LINQ)\n6. Exit\n");
            input = TryParseInt(Console.ReadLine());
            switch (input)
            {
                case 1:
                    bankingService.CreateAccount();
                    break;
                case 2:
                    bankingService.Deposit();
                    break;
                case 3:
                    bankingService.Withdraw();
                    break;
                case 4:
                    bankingService.ViewAllAccounts();
                    break;
                case 5:
                    bankingService.RunAnalytics();
                    break;

            }
        }
        while (input != 6);
    }
    static int TryParseInt(string? input)
    {
        int result;
        while (!int.TryParse(input, out result) || result < 1 || result > 6)
        {
            Console.WriteLine("Invalid input. Please enter a number between 1 and 6.");
            input = Console.ReadLine();
        }
        return result;
    }
}