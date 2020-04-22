using RevisaoGeral_POO.Entities;

namespace RevisaoGeral_POO.Entities
{
    abstract class Account
    {
        public int Number { get; protected set; }
        public Client Holder { get; protected set; }
        public double Balance { get; protected set; }

        public Account()
        {
        }

        public Account(int number, Client holder, double balance)
        {
            Number = number;
            Holder = holder;
            Balance = balance;
        }

        public abstract void Deposit(double amount);
        public abstract void WithDraw(double amount, double withdrawelFee);
        public abstract void Loan(double amount, double loanFee);
    }
}
