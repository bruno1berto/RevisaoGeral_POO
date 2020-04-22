using RevisaoGeral_POO.Entities.Enums;
using System;
using System.Globalization;
using System.Collections.Generic;

namespace RevisaoGeral_POO.Entities.Functions
{
    class Menu
    {
        private static double withdrawelFee = 2.0;
        private static double loanFee = 10.0;
        public static void ExecuteManu(List<Client> clients, List<Account> accounts)
        {
            Console.WriteLine("Main Menu");
            Console.WriteLine();
            Console.WriteLine("1. Register Customer.");
            Console.WriteLine("2. Open Account.");
            Console.WriteLine("3. Deposit.");
            Console.WriteLine("4. Withdraw.");
            Console.WriteLine("5. Loan.");

            Console.WriteLine();
            Console.Write("Option: ");
            int n = int.Parse(Console.ReadLine());

            if (n == 1)
            {
                Console.WriteLine();
                Console.Write("How many customers do you want register? ");
                n = int.Parse(Console.ReadLine());
                for (int i = 1; i <= n; i++)
                {
                    Console.WriteLine();
                    Console.WriteLine($"Customer #{i} data: ");
                    Console.Write("Type: ");
                    TypeClient type = Enum.Parse<TypeClient>(Console.ReadLine());
                    Console.Write("Id: ");
                    int id = int.Parse(Console.ReadLine());
                    Console.Write("Name: ");
                    string name = Console.ReadLine();
                    Console.Write("Document: ");
                    string document = Console.ReadLine();
                    Console.Write("Loan Limit: $ ");
                    double loamLimit = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    clients.Add(new Client(type, id, name, document, loamLimit, loamLimit));
                }
                Console.WriteLine();
                Console.WriteLine("** CUSTOMERS **");
                foreach (Client customer in clients)
                {
                    Console.WriteLine(customer);
                }
            }
            else if (n == 2)
            {
                Console.WriteLine();
                Console.WriteLine("Account Data:");
                Console.Write("Type Account (i-Individual / c-Company): ");
                char type = char.Parse(Console.ReadLine());
                if (type == 'i' || type == 'I')
                {
                    Console.WriteLine();
                    Console.WriteLine("** CUSTOMERS **");
                    foreach (Client customer in clients.FindAll(X => X.Type == TypeClient.Individual))
                    {
                        Console.WriteLine(customer.Id + ", " + customer.Name + ", $ " + customer.AvailableLoanLimit.ToString("F2"));
                    }
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("** CUSTOMERS **");
                    foreach (Client customer in clients.FindAll(X => X.Type == TypeClient.Company))
                    {
                        Console.WriteLine(customer.Id + ", " + customer.Name + ", $ " + customer.AvailableLoanLimit.ToString("F2"));
                    }
                }
                Console.WriteLine();
                Console.Write("Enter the customer id: ");
                int customerId = int.Parse(Console.ReadLine());

                Exceptions.ExceptionsClient(clients, accounts, type, customerId);

                Console.Write("Number Account: ");
                int numberAccount = int.Parse(Console.ReadLine());
                Console.Write("Initial Banlance: $ ");
                double initialBalance = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                if (type == 'i' || type == 'I')
                {
                    accounts.Add(new IndividualAccount(numberAccount, clients.Find(x => x.Id == customerId), initialBalance));
                }
                else
                {
                    accounts.Add(new CompanyAccount(numberAccount, clients.Find(x => x.Id == customerId), initialBalance));
                }
                Console.WriteLine();
                foreach (Account account in accounts)
                {
                    Console.WriteLine(account.Number + ", " + account.Holder.Name + ", $ " + account.Balance.ToString("F2"), CultureInfo.InvariantCulture);
                }
            }
            else if (n == 3)
            {
                Console.WriteLine();
                Console.WriteLine("** ACCOUNTS **");
                foreach (Account acc in accounts)
                {
                    Console.WriteLine(acc);
                }

                Console.WriteLine();
                Console.Write("Enter Account Number: ");
                int accountNumber = int.Parse(Console.ReadLine());

                Exceptions.ExceptionsAccount(clients, accounts, accountNumber);

                Console.Write("Deposit amount: $ ");
                double depositAmount = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Account accDep = accounts.Find(x => x.Number == accountNumber);
                accDep.Deposit(depositAmount);
                Console.WriteLine();
                Console.WriteLine(accDep);
            }
            else if (n == 4)
            {
                Console.WriteLine();
                Console.WriteLine("** ACCOUNTS **");
                foreach (Account acc in accounts)
                {
                    Console.WriteLine(acc);
                }

                Console.WriteLine();
                Console.Write("Enter Account Number: ");
                int accountNumber = int.Parse(Console.ReadLine());

                Exceptions.ExceptionsAccount(clients, accounts, accountNumber);

                Console.Write("Withdraw amount: $ ");
                double depositAmount = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Account accWit = accounts.Find(x => x.Number == accountNumber);
                accWit.WithDraw(depositAmount, withdrawelFee);
                Console.WriteLine();
                Console.WriteLine(accWit);
            }
            else if (n == 5)
            {
                Console.WriteLine();
                Console.WriteLine("** ACCOUNTS **");
                foreach (Account acc in accounts)
                {
                    Console.WriteLine(acc);
                }

                Console.WriteLine();
                Console.Write("Enter Account Number: ");
                int accountNumber = int.Parse(Console.ReadLine());

                Exceptions.ExceptionsAccount(clients, accounts, accountNumber);

                Console.Write("Loan amount: $ ");
                double depositAmount = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Account accLoan = accounts.Find(x => x.Number == accountNumber);
                accLoan.Loan(depositAmount, loanFee);
                Console.WriteLine();
                Console.WriteLine(accLoan);
            }

            Console.WriteLine();
            Console.Write("Perform another operation? (s/n): ");
            char ch = char.Parse(Console.ReadLine());
            if (ch == 's' || ch == 'S')
            {
                Console.WriteLine();
                Menu.ExecuteManu(clients, accounts);
            }
            else
            {
                Console.WriteLine("End program...");
                Console.ReadLine();
            }
        }
    }
}
