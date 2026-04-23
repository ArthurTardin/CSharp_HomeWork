//syntax padrão
using System;

using System.Transactions;

namespace Functionary_System
{

    internal class Program
    {

        static void Main()
        {
            Company company = new Company();

            Manager m = new Manager
            {
                name = "Carlos",
                Basesalary = 5000,
                bonus = 2000
            };

            Developer d = new Developer
            {
                name = "Ana",
                Basesalary = 4000,
                extraHours = 10,
                hourValue = 50
            };

            Intern i = new Intern
            {
                name = "Lucas",
                Basesalary = 2000
            };

            company.AddEmployee(m);
            company.AddEmployee(d);
            company.AddEmployee(i);

            company.ShowSalaries();

        }
    }

    //=================================
    // Class Functionary
    //=================================
    public abstract class Functionary
    {
        public required string name { get; set; }

        private double baseSalary;

        public double Basesalary
        {
            get
            {
                return baseSalary;
            }
            set
            {
                if (value < 1621)
                {
                    Console.WriteLine("O salário não pode ser menor que o salário mínimo.");
                }
                else
                {
                    baseSalary = value;
                }
            }
        }

        public abstract double CalculateSalary();

        public virtual string GetFunctionaryInfo()
        {
            return $"Nome: {name}, Salário: {baseSalary}";
        }
    }

    //=================================
    // Class Manager
    //=================================

    public class Manager : Functionary
    {
        public double bonus { get; set; }

        public override double CalculateSalary()
        {
            return Basesalary + bonus;
        }

        public override string GetFunctionaryInfo()
        {
            return $"Nome: {name}, Salário: {Basesalary}, Bônus: {bonus}";
        }
    }

    //=================================
    // Class Developer
    //=================================

    public class Developer : Functionary
    {
        public int extraHours { get; set; }
        public double hourValue { get; set; }

        public override double CalculateSalary()
        {
            return Basesalary + (extraHours * hourValue);
        }
    }

    //=================================
    // Class Intern
    //=================================

    public class Intern : Functionary
    {
        public override double CalculateSalary()
        {
            return Basesalary;
        }
    }

    //=================================
    // Class Company
    //=================================

    public class Company
    {
        public List<Functionary> employees = new List<Functionary>();

        public void AddEmployee(Functionary f)
        {
            employees.Add(f);
        }
        public void ShowSalaries()
        {
            foreach (var i in employees)
            {
                Console.WriteLine($"O funcionário {i.name} ganha R$ {i.CalculateSalary()}");
            }
        }
    }
}