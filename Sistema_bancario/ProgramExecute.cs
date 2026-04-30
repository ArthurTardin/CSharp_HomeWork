using System;
using System.Threading;

namespace Sistema_Bancario
{

    public class Execute
    {

        public static void ProgramExecute()
        {
            Bank bank = new Bank();

            bool repetition = true;
            while (repetition)
            {
                Console.WriteLine("======[Sistema Bancário]======");
                Console.WriteLine("Bem vindo ao Sistema bancário!");
                Console.WriteLine("Escolha a opção desejada:");
                Console.WriteLine("1 - Criar conta");
                Console.WriteLine("2 - Depositar");
                Console.WriteLine("3 - Sacar");
                Console.WriteLine("4 - Transferência");
                Console.WriteLine("5 - Ver conta");
                Console.WriteLine("6 - Histórico");

                int.TryParse(Console.ReadLine(), out int choice);
                switch (choice)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("======[Criação de conta]======");

                        Console.Write("Digite o seu nome: ");
                        string name = Console.ReadLine()!;

                        Console.WriteLine("Que tipo de conta deseja criar:");
                        Console.WriteLine("1 - Conta Corrente");
                        Console.WriteLine("2 - Conta Poupança");

                        int choose;
                        if (!int.TryParse(Console.ReadLine(), out choose))
                        {
                            Console.WriteLine("Digite um número válido");
                            break;
                        }
                        
                        
                        var account = bank.AccountCreate(name, choose);
                        if (account != null)
                        {
                                Console.WriteLine("Conta criada com sucesso!");
                                Console.WriteLine($"Nome: {account.OwnerName}");
                                Console.WriteLine($"Número da conta: {account.AccountNumber}");
                            break;
                        }   
                        Console.WriteLine("Houve um erro ao criar a conta! Tente novamente");

                        Thread.Sleep(2000);
                        Console.Clear();

                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("======[Depositar]======");

                        int number;
                        double amount;

                        Console.Write("Qual é o número da conta que deseja depositar: ");
                        if (!int.TryParse(Console.ReadLine(), out number))
                        {
                            Console.WriteLine("Digite um valor válido!");
                            break;
                        }

                        Console.Write("Valor que deseja depositar: ");
                        if (!double.TryParse(Console.ReadLine(), out amount))
                        {
                           Console.WriteLine("Digite um valor válido!");
                            break;
                        }

                        if (bank.FindAccount(number, out BankAccount account1))
                        {
                            if (account1.deposit(amount) == false)
                            {
                                Console.WriteLine("Valor inválido!");
                            }
                            else
                            {
                                Console.WriteLine("Valor depositado!");

                                account1.History.Add($"Valor depositado: {amount:c}");
                            }
                            break;
                        }
                        
                        Console.WriteLine("Conta não encontrada! Tente novamente");

                        Thread.Sleep(3000);
                        Console.Clear();

                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("======[Sacar]======");

                        Console.Write("Digite o número da conta que deseja sacar: ");
                        
                        if(!int.TryParse(Console.ReadLine(), out number))
                        {
                            Console.WriteLine("Digite um valor válido!");
                            break;
                        }
                        else
                        {
                            Console.Write("Digite o valor que deseja sacar: ");
                            
                            if (double.TryParse(Console.ReadLine(), out amount))
                            {
                                Console.WriteLine("Digite um valor válido!");
                            }
                            else
                            {
                                if (bank.FindAccount(number, out BankAccount account2))
                                {
                                    if (account2.WithDraw(amount) == false)
                                    {
                                        Console.WriteLine("Limite excedido!");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Valor sacado!");
                                        account2.History.Add($"Valor sacado: {amount:c}");  
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Conta não encontrada!");
                                }
                            }
                        }
                        Thread.Sleep(3000);
                        Console.Clear();

                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine("======[Transferência]======");

                        Console.Write("Digite o número da conta Origem: ");
                        
                        if(!int.TryParse(Console.ReadLine(), out int find))
                        {
                            Console.WriteLine("Digite um valor válido!");
                        }
                        else
                        {
                            if (bank.FindOriginAccount(find, out BankAccount bankOrigin) == false)
                            {
                                Console.WriteLine("Conta não encontrada!");
                            }
                            else
                            {
                                Console.Write("Digite o número da conta destino: ");
                                
                                if(!int.TryParse(Console.ReadLine(), out int found))
                                {
                                    Console.WriteLine("Digite um valor válido!");
                                }
                                else
                                {
                                    if (bank.FindDestinationAccount(found, out BankAccount bankDestination) == false)
                                    {
                                        Console.WriteLine("Conta não encontrada!");
                                    }
                                    else
                                    {
                                        Console.Write("Digite o valor a ser transferido: ");
                                        
                                        if (!double.TryParse(Console.ReadLine(), out double Pay))
                                        {
                                            Console.WriteLine("Digite um valor válido!");
                                        }
                                        else
                                        {
                                            if (bank.BankTransfer(find, found, Pay) == false)
                                            {
                                                Console.WriteLine("Transação não concluída");
                                            }
                                            else
                                            {
                                                Console.WriteLine("Transação concluída");
                                            }
                                        }
                                    }
                                }
                            }
                        }
                                        
                        break;
                    case 5:
                        Console.Clear();
                        Console.WriteLine("======[Conta]======");

                        Console.Write("Digite o número da sua conta: ");
                        int.TryParse(Console.ReadLine(), out int Try);

                        if (bank.FindAccount(Try, out BankAccount bankAccount) == false)
                        {
                            Console.WriteLine("Conta não encontrada!");
                        }
                        else
                        {
                            Console.WriteLine($"Nome: {bankAccount.OwnerName} | Número da conta: {bankAccount.AccountNumber}" +
                                $"| Saldo: {bankAccount.Balance}");
                            Console.WriteLine("Aperte ENTER para voltar");
                            Console.ReadLine();
                            Console.Clear();
                        }
                        break;
                    case 6:
                        Console.WriteLine("======[Histórico]======");

                        Console.Write("Digite o número da conta: ");
                        int.TryParse(Console.ReadLine(), out int Hi);

                        if (bank.FindAccount(Hi, out bankAccount) == false)
                        {
                            Console.WriteLine("Conta não encontrada");
                        }
                        else
                        {
                            foreach(var Every in bankAccount.History)
                            {
                                Console.WriteLine(Every);
                            }
                        }
                        break;
                    case 7:
                        Console.WriteLine("======[Listar contas]======");

                        bank.GetAccount();
                        break;




                }
            }
        }
    }
}
