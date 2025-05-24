using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using ATM.Commands;
//reciver
namespace ATM
{
    public class BankAccount
    {
        private double balance;
        private string ownerName;
        private string Id;

        public BankAccount(double balance, string ownerName, string id)
        {
            this.balance = balance;
            this.ownerName = ownerName;
            Id = id;
        }

        public void Withdraw(double amount)
        {
            if (amount <= balance)
            {
                balance -= amount;
                Console.WriteLine("Снято:" + amount + "₮. " + "Остаток на счету:" + balance + "₮.");
            }
            else
            {
                Console.WriteLine("На счету недостаточно средств");
            }
        }

        public void Deposit(double amount)
        {
            balance += amount;
            Console.WriteLine("Внесено: " + balance + "₮. " + "Баланс: " + balance + "₮.");
        }

        public void Pay(String name, double amount)
        {
            if (amount <= balance)
            {
                balance -= amount;
                Console.WriteLine("Оплачена услуга: " + name + " Остаток:" + balance + "₮.");
            }
            else
            {
                Console.WriteLine("На счету недостаточно средств");
            }
        }
        public void DisplayInfo()
        {
            Console.WriteLine();
            //Console.Clear();
            Console.WriteLine("=== БАНКОВСКАЯ СИСТЕМА ===");
            Console.WriteLine($"Клиент: {ownerName}");
            Console.WriteLine($"ID счета: {Id}");
            Console.WriteLine($"Текущий баланс: {balance}₮");
            Console.WriteLine("==========================");
            Console.WriteLine("Доступные команды:\nснять\nвнести\nоплатить\nвыход");
        }

        public double GetBalance()
        {
            return balance;
        }


    }


}
