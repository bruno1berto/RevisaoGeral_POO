using System;
using RevisaoGeral_POO.Entities;
using RevisaoGeral_POO.Entities.Exceptions;

namespace RevisaoGeral_POO.Entities
{
    class CompanyAccount : Account
    {
        public CompanyAccount()
        {
        }

        public CompanyAccount(int number, Client holder, double balance) : base(number, holder, balance)
        {
        }

        public override void Deposit(double amount)
        {
            Balance += amount;
        }

        public override void WithDraw(double amount, double withDrawelFee)
        {
            if (amount > Balance)
                throw new DomainException("Insuficient Balance.");
            else
                Balance -= amount - withDrawelFee;
                Console.WriteLine("New Balance: $ " + Balance + "(Fee: " + withDrawelFee.ToString("F2") + ")");
        }

        public override void Loan(double amount, double loanFee)
        {
            if (amount > Holder.LoanLimit)
                throw new DomainException("Loan Limit from client exceeded.");
            else
                Balance += amount - amount * loanFee / 100;
                Holder.UpdateAvailableLoanLimit(amount);
                Console.WriteLine("New Balance: $ " + Balance.ToString("F2") + " (Fee: " + loanFee.ToString("F2") + ")");
        }

        public override string ToString()
        {
            return Holder.Type + ", " 
                + Number + ", "
                + Holder.Name + ", $ "
                + Balance.ToString("F2");
        }
    }
}
