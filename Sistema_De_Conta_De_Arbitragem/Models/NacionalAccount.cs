using System;

namespace Sistema_Conta_Arbitragem
{
    
    public class NacionalAccount : RefereeAccount
    {
        public NacionalAccount(string name) : base(name){}
        public override bool Spend(double value)
        {
            if(value <= 0)
            {
                return false;
            }
            double finalValue = value * 1.02;
            if(finalValue > Balance)
            {
                return false;
            }
            Balance -= finalValue;
            return true;
        }
    }
}