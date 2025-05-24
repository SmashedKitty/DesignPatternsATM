using System;
using ATM;
using ATM.Commands;

// Инициализация банковского счета
var account = new BankAccount(50000, "Иван Золо", "ASS12345");

//(Invoker)
var bank = new Therminal();

// Регистрация команд (без конкретных сумм)
var withdrawCmd = new Withdraw(account, 0);
var depositCmd = new Deposit(account, 0);
var payCmd = new Pay(account, "", 0);

while (true)
{
    account.DisplayInfo();
    Console.Write("\nВведите команду: ");
    var input = Console.ReadLine()?.Trim().ToLower();
    
    if (string.IsNullOrEmpty(input)) continue;
    if (input == "выход") break;

    bank.ProcessUserCommand(input, withdrawCmd, depositCmd, payCmd, account.GetBalance());
}