using System;

namespace Sistema_Bancario
{

    public class CheckingAccount : BankAccount
    {
        public CheckingAccount(int accountNumber, string name) : base(accountNumber, name) { }
        public override bool WithDraw(double amount)
        {
            if (amount < -2500)
            {
                return false;
            }
            Balance -= amount;
            return true;
        }
    }
}
