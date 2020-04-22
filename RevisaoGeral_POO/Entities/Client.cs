using System.Collections.Generic;
using System.Globalization;
using RevisaoGeral_POO.Entities.Enums;

namespace RevisaoGeral_POO.Entities
{
    class Client
    {
        public TypeClient Type { get; protected set; }
        public int Id { get; protected set; }
        public string Name { get; protected set; }
        public string Document { get; protected set; }
        public double LoanLimit { get; protected set; }
        public double AvailableLoanLimit { get; protected set; }

        public Client()
        {
        }

        public Client(TypeClient type, int id, string name, string document, double loanLimit, double availableLoanLimit)
        {
            Type = type;
            Id = id;
            Name = name;
            Document = document;
            LoanLimit = loanLimit;
            AvailableLoanLimit = availableLoanLimit;
        }

        public void UpdateAvailableLoanLimit(double amonut)
        {
            AvailableLoanLimit -= amonut;
        }

        public override string ToString()
        {
            return "Type: " + Type
                + ", Id: " + Id
                + ", Name: " + Name
                + ", Loan Limit Available: $ " + AvailableLoanLimit.ToString("F2");
        }
    }
}
