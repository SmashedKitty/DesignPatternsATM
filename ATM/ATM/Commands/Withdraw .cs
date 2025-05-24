using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Commands
{
    public class Withdraw : ICommand
    {
        private BankAccount _account;
        private double _amount;
        public Withdraw(BankAccount account, double amount)
        {
            _account = account;
            _amount = amount;
        }
        public void Execute()
        {
            Console.WriteLine("\n=== Процесс снятия денег ===");
            Console.WriteLine("1. Введите сумму для снятия");
            Console.WriteLine("2. Подождите, пока банкомат подготовит купюры");
            Console.WriteLine("3. Возьмите деньги из приемника\n");
            _account.Withdraw(_amount);
        }

        public void SetAmount(double amount)
        {
            _amount = amount;
        }
    }
}
