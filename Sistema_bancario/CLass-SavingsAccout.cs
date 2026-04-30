using System;

namespace Sistema_Bancario
{

    public class SavingsAccount : BankAccount
    {
        public SavingsAccount(int accountNumber, string name) : base(accountNumber, name) { }
        public override bool WithDraw(double amount)
        {
            limit = 0;
            if (amount < limit)
            {
                return false;
            }
            Balance -= amount;
            return true;
        }
    }
}
