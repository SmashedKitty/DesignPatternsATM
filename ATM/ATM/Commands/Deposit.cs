using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Commands
{
    public class Deposit : ICommand
    {
        private BankAccount _account;
        private double _amount;

        public Deposit(BankAccount account, double amount) {
            _account = account;
            _amount = amount;
        }

        public void Execute()
        {
            Console.WriteLine("\n=== Процесс внесения денег ===");
            Console.WriteLine("1. Вставьте купюры в купюроприемник");
            Console.WriteLine("2. Подождите, пока банкомат проверит купюры");
            Console.WriteLine("3. Подтвердите сумму внесения\n");
            _account.Deposit(_amount);
        }
        public void SetAmount(double amount)
        {
            _amount = amount;
        }
    }
}
