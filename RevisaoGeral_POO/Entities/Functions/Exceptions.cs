using RevisaoGeral_POO.Entities.Enums;
using RevisaoGeral_POO.Entities.Exceptions;
using System.Collections.Generic;

namespace RevisaoGeral_POO.Entities.Functions
{
    class Exceptions
    {
        public static void ExceptionsAccount(List<Client> clients, List<Account> accounts, int accountNumber)
        {
            Account A = accounts.Find(x => x.Number == accountNumber);
            if (A == null)
            {
                throw new DomainException("Invalid Account Number.");
            }
        }

        public static void ExceptionsClient(List<Client> clients, List<Account> accounts, char type, int customerId)
        {
            Client C = clients.Find(x => x.Id == customerId);
            if (C == null)
            {
                throw new DomainException("Invalid customer Id.");
            }

            if (type == 'i' || type == 'I' && C.Type != TypeClient.Individual)
            {
                throw new DomainException("Holder is not a Individual Customer.");
            }

            if (type == 'c' || type == 'C' && C.Type != TypeClient.Company)
            {
                throw new DomainException("Holder is not a Company Customer.");
            }
        }
    }
}
