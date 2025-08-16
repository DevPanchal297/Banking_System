namespace Banking_System;

public delegate void TransactionHandler(string message);

public class BankAccount
{
    public static int curnum=1;
    public string AccountNumber { get; }
    public string HolderName { get; }
    public double Balance { get;  set; }
    public event TransactionHandler? OnTransaction;
    public BankAccount(string holderName, double initialBalance = 0)
    {
        AccountNumber = curnum.ToString();
        HolderName = holderName;
        Balance = initialBalance;
        curnum++;
        this.OnTransaction += (msg) => Console.WriteLine($"[Transaction Notification] {msg}");
        Notify($"[Account Created] : Account Holder: {this.HolderName}, Account Number: {this.AccountNumber}, Balance: {this.Balance}");
    }
    public void Deposit(double amount) { 
        this.Balance += amount;
        Notify($"{this.HolderName} deposited ${amount}. New Balance:${this.Balance}");
     }
    public void Withdraw(double amount) { 
        this.Balance-= amount;
        Notify($"{this.HolderName} Withdrawed ${amount}. New Balance:${this.Balance}");
    }

    protected virtual void Notify(string message)
    {
        OnTransaction?.Invoke(message);
    }
}