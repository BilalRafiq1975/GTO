using System;

// Base class: BankAccount
class BankAccount
{
    protected string accountHolder;
    protected double balance;

    public BankAccount(string accountHolder, double balance)
    {
        this.accountHolder = accountHolder;
        this.balance = balance;
    }

    // Virtual method for withdrawal (Method Overriding)
    public virtual void Withdraw(double amount)
    {
        if (balance >= amount)
        {
            balance -= amount;
            Console.WriteLine($"{accountHolder} withdrew {amount:C}. New balance: {balance:C}");
        }
        else
        {
            Console.WriteLine("Insufficient balance.");
        }
    }

    // Overloaded method for depositing with different parameters (Method Overloading)
    public void Deposit(double amount)
    {
        balance += amount;
        Console.WriteLine($"{accountHolder} deposited {amount:C}. New balance: {balance:C}");
    }

    public void Deposit(double amount, string source)
    {
        balance += amount;
        Console.WriteLine($"{accountHolder} received {amount:C} from {source}. New balance: {balance:C}");
    }
}

// Derived class: SavingsAccount (Method Overriding)
class SavingsAccount : BankAccount
{
    private double interestRate;

    public SavingsAccount(string accountHolder, double balance, double interestRate)
        : base(accountHolder, balance)
    {
        this.interestRate = interestRate;
    }

    // Overriding Withdraw method with different rules
    public override void Withdraw(double amount)
    {
        if (balance - amount >= 100) // Ensuring minimum balance of $100
        {
            balance -= amount;
            Console.WriteLine($"{accountHolder} withdrew {amount:C} from savings. New balance: {balance:C}");
        }
        else
        {
            Console.WriteLine("Cannot withdraw. Minimum balance of $100 must be maintained.");
        }
    }
}

// Derived class: CheckingAccount (Method Overriding)
class CheckingAccount : BankAccount
{
    private double overdraftLimit;

    public CheckingAccount(string accountHolder, double balance, double overdraftLimit)
        : base(accountHolder, balance)
    {
        this.overdraftLimit = overdraftLimit;
    }

    // Overriding Withdraw method with overdraft limit
    public override void Withdraw(double amount)
    {
        if (balance - amount >= -overdraftLimit)
        {
            balance -= amount;
            Console.WriteLine($"{accountHolder} withdrew {amount:C} from checking. New balance: {balance:C}");
        }
        else
        {
            Console.WriteLine("Overdraft limit exceeded. Cannot withdraw.");
        }
    }
}

// Main Program
class Program
{
    static void Main()
    {
        BankAccount acc1 = new SavingsAccount("Ahmed", 1000, 0.02);
        BankAccount acc2 = new CheckingAccount("Bilal", 500, 200);

        acc1.Deposit(200);
        acc1.Withdraw(950); // Should fail due to minimum balance rule in SavingsAccount

        acc2.Deposit(100, "Paycheck");
        acc2.Withdraw(650); // Should allow overdraft up to limit
    }
}
