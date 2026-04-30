using System;
using System.Runtime.CompilerServices;

namespace Sistema_Bancario
{

    public class Bank
    {
        private static List<BankAccount> Accounts = new List<BankAccount>();
        public static int NextNumber = 1;

        public void GetAccount()
        {
             foreach (var every in Accounts)
            {
                Console.WriteLine(every);
            }
        }
        public static int GetInfo()
        {
            return NextNumber;
        }

        public bool FindAccount(int number, out BankAccount account)
        {
            account = Accounts.Find(c => c.AccountNumber == number);
            return account != null;
        }
        public BankAccount AccountCreate(string name, int type)
        {
            BankAccount account;
            switch (type)
            {
                case 1:
                    account = new CheckingAccount(NextNumber, name);
                    break;
                case 2:
                    account = new SavingsAccount(NextNumber, name);
                    break;

                default:
                    return null;
            }
            Accounts.Add(account);
            NextNumber++;
            return account;
        }
        public bool FindOriginAccount(int origin, out BankAccount bankOrigin)
        {
            bankOrigin = Accounts.Find(c => c.AccountNumber == origin);
            return bankOrigin != null;
        }
        public bool VerificationWithDraw(int origin, double value)
        {
            if (!FindOriginAccount(origin, out BankAccount bankOrigin))
            {
                return false;
            }
            return bankOrigin.WithDraw(value);

        }
        public bool FindDestinationAccount(int destination, out BankAccount BankDestination)
        {
            BankDestination = Accounts.Find(c => c.AccountNumber == destination);
            return BankDestination != null;
        }


        public bool BankTransfer(int origin, int destination, double value)
        {
            if (!FindOriginAccount(origin, out BankAccount bankOrigin))
            {
                return false;
            }
            if (!FindDestinationAccount(destination, out BankAccount bankDestination))
            {
                return false;
            }
            if (VerificationWithDraw(origin, value))
            {
                return false;
            }

            bankDestination.deposit(value);
            bankOrigin.History.Add($"Tranferência enviada de {value:c} para: {bankDestination}");
            bankDestination.History.Add($"Transferência recebida de {value:c} de {bankOrigin}");

            return true;

        }
    }
}