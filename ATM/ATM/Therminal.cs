using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATM.Commands;
//Invoker
namespace ATM
{
    public class Therminal
    {
        private Dictionary<string, Commands.ICommand> _commands;
        private BankAccount _currentAccount;
        public Therminal()
        {
            _commands = new Dictionary<string, Commands.ICommand>(StringComparer.OrdinalIgnoreCase);
        }

        public void SetCommandToPhrase(string phrase, Commands.ICommand command)
        {
            _commands[phrase] = command;
        }

        public void ExecuteCommand(string phrase)
        {
            if (_commands.ContainsKey(phrase))
            {
                _commands[phrase].Execute();
            }
        }
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine("Доступные команды:");
            foreach (var cmd in _commands)
            {
                sb.AppendLine($"{cmd.Key}");
            }
            sb.AppendLine("выход — Выход из системы");
            return sb.ToString();
        }

        public void ProcessUserCommand(string input, Withdraw withdrawCmd, Deposit depositCmd, Pay payCmd, double balance)
        {
            if (input.StartsWith("снять"))
            {
                Console.Write("Введите сумму для снятия: ");
                double amount = double.Parse(Console.ReadLine());
                withdrawCmd.SetAmount(amount);
                withdrawCmd.Execute();
            }
            else if (input.StartsWith("внести"))
            {
                Console.Write("Введите сумму для внесения: ");
                double amount = double.Parse(Console.ReadLine());
                depositCmd.SetAmount(amount);
                depositCmd.Execute();
            }
            else if (input.StartsWith("оплатить"))
            {
                if (balance >= 300)
                {
                    Console.WriteLine("Выберите услугу для оплаты:");
                    Console.WriteLine("1. Сотовая связь(300₮)");
                    if (balance >= 500)
                        Console.WriteLine("2. Коммунальные услуги(500₮)");

                    var choice = Console.ReadLine();
                    if ((choice == "1" || choice == "Сотовая связь") && balance >= 300)
                    {
                        Console.Write("Внесение суммы оплаты: ");
                        double amount = 300;
                        payCmd.SetAmount(amount);
                        payCmd.SetName("Сотовая связь");
                        payCmd.Execute();
                    }
                    else if ((choice == "2" || choice == "Коммунальные услуги") && balance >= 500)
                    {
                        Console.Write("Внесение суммы оплаты: ");
                        double amount = 500;
                        payCmd.SetAmount(amount);
                        payCmd.SetName("Коммунальные услуги");
                        payCmd.Execute();
                    }
                    else
                    {
                        Console.WriteLine("Неверный выбор услуги");
                    }
                }
                else { Console.WriteLine("Для оплаты услуг не хватает денег на счете"); }
            }
        }

    }
}
