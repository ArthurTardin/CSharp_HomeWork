using System;
using System.Diagnostics.Contracts;

namespace Sistema_Conta_Arbitragem
{
    
    public class RegionalAccount : RefereeAccount
    {
        public RegionalAccount(string name) : base(name){}
        public override bool Spend(double value)
        {
            if(value <= 0)
            {
                return false;
            }
            else if(value > Balance)
            {
                return false;
            }
            Balance -= value;
            return true;
        }
    }
}