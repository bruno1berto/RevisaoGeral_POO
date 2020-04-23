using RevisaoGeral_POO.Entities;
using RevisaoGeral_POO.Entities.Exceptions;
using RevisaoGeral_POO.Entities.Functions;
using System;
using System.Collections.Generic;

namespace RevisaoGeral_POO
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Client> clients = new List<Client>();
            List<Account> accounts = new List<Account>();

            try
            {
                Menu.ExecuteManu(clients, accounts);
            }
            catch(DomainException err)
            {
                Console.WriteLine("Error: " + err.Message);
            }
            catch (Exception err)
            {
                Console.WriteLine("Unexpected Error: " + err.Message);
            }
            finally
            {
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
}
