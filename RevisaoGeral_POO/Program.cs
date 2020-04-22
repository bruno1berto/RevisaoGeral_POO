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
            try
            {
                List<Client> clients = new List<Client>();
                List<Account> accounts = new List<Account>();

                Menu.ExecuteManu(clients, accounts);
            }
            catch(DomainException err)
            {
                Console.WriteLine("Error: " + err.Message);
                Console.ReadLine();
            }
            catch (Exception err)
            {
                Console.WriteLine("Unexpected Error: " + err.Message);
                Console.ReadLine();
            }
        }
    }
}
