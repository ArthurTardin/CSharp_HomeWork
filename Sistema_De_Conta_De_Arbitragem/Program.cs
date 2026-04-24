using System;

namespace Sistema_Conta_Arbitragem
{
    
    class Program
    {
        
        static void Main()
        {
            
            RefereeAccount regional = new RegionalAccount("tutu Regional");
            RefereeAccount nacional = new NacionalAccount("tutu Nacional");

            if (regional.ReceivePayment(200))
            {
                Console.WriteLine("Pagamento Recebido!");
            }
            else
            {
                Console.WriteLine("Erro ao receber pagamento.");
            }

            if (regional.Spend(50))
            {
                Console.WriteLine("Gasto realizado!");
            }
            else
            {
                Console.WriteLine("Erro ao gastar.");
            }
            
            Console.WriteLine($"Saldo final: {regional.GetBalance}");
        }
    }
}