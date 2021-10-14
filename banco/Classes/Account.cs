using System;

namespace banco
{
  public class Account
  {
    private string Name { get; set; }
    private AccountTypes AccountType { get; set; }
    private double Balance { get; set; }
    private double Credit { get; set; }

    public Account(string name, AccountTypes accountType, double balance = 0, double credit = 0)
    {
      this.Name = name;
      this.AccountType = accountType;
      this.Balance = balance;
      this.Credit = credit;
    }

    public bool Withdraw(double value)
    {
      if(this.Balance - value < (this.Credit * - 1)){
        Console.WriteLine("Saldo insuficiente");
        return false;
      } 

      this.Balance -= value;
      Console.WriteLine($"Saldo atual: R${this.Balance}");
      return true;
    }

    public void Deposit(double value){
      this.Balance += value;
      Console.WriteLine($"Saldo atual: R${this.Balance}");
    }

    public void Transfer(double value, Account destinyAccount){
      if(this.Withdraw(value)){
        destinyAccount.Deposit(value);
      }
    }

    public override string ToString()
    {
      string str = $"Dono(a): {this.Name} | ";
      str += $"Tipo da Conta: {this.AccountType} | ";
      str += $"Saldo: R$ {this.Balance.ToString("0.00")} | ";
      str += $"Crédito: R$ {this.Credit.ToString("0.00")}";
      return str;
    }
  }
}