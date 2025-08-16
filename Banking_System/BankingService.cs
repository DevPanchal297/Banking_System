using System.Security.Principal;

namespace Banking_System
{
    public class BankingService
    {
        private Repository<BankAccount> _repository;
        public BankingService(Repository<BankAccount> repository)
        {
            _repository = repository;
        }
        public void CreateAccount()
        {
            string name = null, number = null;
            double balance = 0.0;
            do
            {
                Console.WriteLine("Please Enter Name of Account Holder:");
                name = Console.ReadLine();
            }
            while (string.IsNullOrEmpty(name) || !CheckName(name));
            do
            {
                Console.WriteLine("Please Enter Initial Balance:");
                balance = double.TryParse(Console.ReadLine(), out balance) ? balance : 0.0;
            }
            while (!double.IsPositive(balance));
            BankAccount newAcc = new(name, balance);
            _repository.Add(newAcc);
        }
        public void ViewAllAccounts()
        {
            List<BankAccount> accounts = _repository.GetAll();
            foreach (BankAccount account in accounts)
            {
                Console.WriteLine($"Account Holder: {account?.HolderName}, Account Number: {account?.AccountNumber}, Account Balance: ${account?.Balance}");
            }
            Console.WriteLine();
        }
        public void Deposit()
        {
            string number = null, amountinput = null;
            do
            {
                Console.WriteLine("Enter Account Number: ");
                number = Console.ReadLine();
            }
            while (string.IsNullOrEmpty(number) || !CheckAccountNumber(number));
            BankAccount acc = _repository.Find(acc => acc.AccountNumber == number)?.FirstOrDefault();
            double amount = 0.0;
            do
            {
                Console.WriteLine("Enter Amount to Deposit: ");
                amountinput = Console.ReadLine();
                amount = double.TryParse(amountinput, out amount) ? amount : 0.0;
            }
            while (amount <= 0);
            acc.Deposit(amount);
        }
        public void Withdraw()
        {
            string number = null, amountinput = null;
            do
            {
                Console.WriteLine("Enter Account Number: ");
                number = Console.ReadLine();
            }
            while (string.IsNullOrEmpty(number) || !CheckAccountNumber(number));
            BankAccount acc = _repository.Find(acc => acc.AccountNumber == number)?.FirstOrDefault();
            double amount = 0.0;
            do
            {
                Console.WriteLine("Enter Amount to Withdraw: ");
                amountinput = Console.ReadLine();
                amount = double.TryParse(amountinput, out amount) ? amount : 0.0;
                if (!CheckAccountBalance(amount, acc))
                {
                    Console.WriteLine("Not Sufficient Balance to Withdraw");
                    amount = 0;
                }
            }
            while (amount <= 0);
            acc.Withdraw(amount);
        }
        public void RunAnalytics()
        {
            List<BankAccount> accounts = _repository.GetAll();
            int lowBal = accounts.FindAll(acc => acc.Balance < 10000).Count;
            int midBal = accounts.FindAll(acc => acc.Balance >= 10000 && acc.Balance <= 50000).Count;
            int highBal = accounts.FindAll(acc => acc.Balance > 50000).Count;
            Console.WriteLine();
            Console.WriteLine("Sorted By Holder Name: ");
            var sortedbyName = accounts.OrderBy(a => a.HolderName ?? string.Empty, StringComparer.CurrentCultureIgnoreCase).ToList();
            PrintList(sortedbyName);
            Console.WriteLine("Sorted By Balance(descending)");
            var sortedbyBal = accounts.OrderByDescending(a=>a.Balance).ToList();
            PrintList(sortedbyBal);
            Console.WriteLine($"Low Balance Account: {lowBal}, Middle Balance Account: {midBal}, High Balance Account: {highBal}");
            Console.WriteLine();
        }
        private bool CheckAccountNumber(string number)
        {
            BankAccount account = _repository.Find(acc => acc.AccountNumber == number)?.FirstOrDefault();
            if (account != null)
            {
                return true;
            }
            return false;
        }
        private bool CheckAccountBalance(double amount, BankAccount acc)
        {
            if (acc.Balance >= amount)
            {
                return true;
            }
            return false;
        }
        private bool CheckName(string name)
        {
            foreach (char n in name)
            {
                if (!char.IsLetter(n) && !char.IsWhiteSpace(n))
                {
                    return false;
                }
            }
            return true;
        }
        private void PrintList(List<BankAccount> accounts)
        {
            foreach (BankAccount account in accounts)
            {
                Console.WriteLine($"Account Holder: {account?.HolderName}, Account Number: {account?.AccountNumber}, Account Balance: ${account?.Balance}");
            }
            Console.WriteLine();
        }
    }
}
