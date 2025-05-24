using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Commands
{
    public class Pay : ICommand
    {
        private BankAccount _account;
        private double _amount;
        private string _name;

        public Pay(BankAccount account, string name, double amount)
        {
            _account = account;
            _amount = amount;
            _name = name;
        }

        public void Execute()
        {
            Console.WriteLine($"\n=== Процесс оплаты {_name} ===");
            Console.WriteLine("1. Введите реквизиты платежа");
            Console.WriteLine("2. Подтвердите сумму оплаты\n");
            _account.Pay(_name, _amount);
        }
        public void SetAmount(double amount)
        {
            _amount = amount;
        }
        public void SetName(string name)
        {
            _name = name;
        }
    }
}
