using System;
using System.Security.Cryptography.X509Certificates;

namespace Sistema_Bancario
{

    public abstract class BankAccount
    {
        public int AccountNumber;
        public string OwnerName;
        private double _Balance;
        public double Balance;

        public List<string> History { get; private set; } = new List<string>();

        public BankAccount(int accountNumber, string name)
        {
            AccountNumber = accountNumber;
            OwnerName = name;
            Balance = 0;
        }
        public bool deposit(double amount)
        {
            if (amount <= 0)
            {
                return false;
            }
            Balance += amount;
            return true;
        }
        public abstract bool WithDraw(double amount);
        public bool Verification(double amount, double limit)
        {
            if (!WithDraw(amount))
            {
                return false;
            }
            _Balance -= Balance;
            return true;
        }
        public bool VerificationDeposit(double amount)
        {
            if (!deposit(amount))
            {
                return false;
            }
            _Balance += amount;
            return true;
        }
    }
}
