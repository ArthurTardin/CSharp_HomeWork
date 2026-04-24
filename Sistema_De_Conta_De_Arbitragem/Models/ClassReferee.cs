using System;

namespace Sistema_Conta_Arbitragem
{
    
    public abstract class RefereeAccount
    {
        public string Name {get; private set;}
        protected double Balance;

        public RefereeAccount(string name)
        {
            Name = name;
            Balance = 0; 
        }

        public bool ReceivePayment(double value)
        {
            if( value <= 0)
            {
                return false;
            }
            Balance += value;
            return true;
        }
        public abstract bool Spend(double value);
        public double GetBalance()
        {
            return Balance;
        }
    }
}