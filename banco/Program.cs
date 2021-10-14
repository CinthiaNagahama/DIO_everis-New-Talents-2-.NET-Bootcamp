using System;
using System.Collections.Generic;

namespace banco
{
  class Program
  {
    static List<Account> listAccounts = new List<Account>();

    private static Account GetAccount(int index){
      if(index < listAccounts.Count - 1){
        return listAccounts[index];
      }
      Console.Write($"Conta {index} não encontrada.");
      return null;
    }
    private static string UserOptions()
    {
      Console.WriteLine("\nDIOBank ao seu dispor!");
      Console.WriteLine("O que deseja fazer agora?");

      Console.WriteLine("1 - Listar Contas");
      Console.WriteLine("2 - Criar Nova Conta");
      Console.WriteLine("3 - Tranferir");
      Console.WriteLine("4 - Sacar");
      Console.WriteLine("5 - Depositar");
      Console.WriteLine("C - Limpar Tela");
      Console.WriteLine("X - Sair\n");

      string option = Console.ReadLine().ToUpper();
      Console.WriteLine();
      return option;
    } 
    private static void ListAccounts()
    {
      if (listAccounts.Count == 0)
      {
        Console.WriteLine("Nenhuma conta cadastrada.\n");
        return;
      }
      foreach (Account account in listAccounts)
      {
        Console.Write("Número da Conta: " + listAccounts.FindIndex(a => a.Equals(account)) + " | " + account.ToString() + "\n");
      }
    }
    private static void CreateAccount()
    {
      Console.WriteLine("Criar nova conta");

      Console.Write("Digite 1 para Conta Física ou 2 para Conta Jurídica: \n");
      int accountType = int.Parse(Console.ReadLine());

      Console.Write("Digite o Nome do Cliente: \n");
      string ownerName = Console.ReadLine();

      Console.Write("Digite o Saldo Inicial: \n");
      double initialBalance = double.Parse(Console.ReadLine());

      Console.Write("Digite o Crédito: \n");
      double initialCredit = double.Parse(Console.ReadLine());

      listAccounts.Add(
        new Account(
          name: ownerName,
          accountType: (AccountTypes)accountType,
          balance: initialBalance,
          credit: initialCredit
        )
      );
    }
    private static void Transfer()
    {
      Console.Write("Digite o número da conta de origem: \n");
      int indexOrigin = int.Parse(Console.ReadLine());

      Console.Write("Digite o número da conta de destino: \n");
      int indexDestiny = int.Parse(Console.ReadLine());

      Console.Write("Digite o valor a ser tranferido: \n");
      double value = double.Parse(Console.ReadLine());

      GetAccount(indexOrigin).Transfer(value, GetAccount(indexDestiny));
    }
    private static void Withdraw()
    {
      Console.Write("Digite o número da conta: \n");
      int index = int.Parse(Console.ReadLine());

      Console.Write("Digite o valor a ser sacado: \n");
      double value = double.Parse(Console.ReadLine());

      GetAccount(index).Withdraw(value);
    }
    private static void Deposit()
    {
      Console.Write("Digite o número da conta: \n");
      int index = int.Parse(Console.ReadLine());

      Console.Write("Digite o valor a ser depositado: \n");
      double value = double.Parse(Console.ReadLine());

      GetAccount(index).Deposit(value);
    }
    private static void CleanScreen()
    {
      Console.Clear();
    }

    static void Main(string[] args)
    {
      string option = UserOptions();

      while (option != "X")
      {
        switch (option)
        {
          case "1":
            ListAccounts();
            break;
          case "2":
            CreateAccount();
            break;
          case "3":
            Transfer();
            break;
          case "4":
            Withdraw();
            break;
          case "5":
            Deposit();
            break;
          case "C":
            CleanScreen();
            break;
          default:
            throw new ArgumentOutOfRangeException("Opção inválida");
        }

        option = UserOptions();
      }

      Console.WriteLine("Obrigado por utilizar nossos serviços!\nAté apróxima o/\n");
    }
  }
}
