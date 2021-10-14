using System;
using System.Collections.Generic;

namespace hello_world
{
  class Desafio
  {
    public static void Desafio1()
    {
      int quilometros = Int32.Parse(Console.ReadLine());
      int minutos = 2 * quilometros;
      Console.WriteLine(minutos + " minutos");
    }

    public static void Desafio2()
    {
      int A = Convert.ToInt32(Console.ReadLine());
      int B = Convert.ToInt32(Console.ReadLine());

      int SOMA = A + B;

      Console.WriteLine("SOMA = {0}", SOMA);
    }

    public static void Desafio3()
    {
      int limit = Int32.Parse(Console.ReadLine());
      for (int i = 0; i < limit; i++)
      {
        string[] line = Console.ReadLine().Split(" ");
        double X = double.Parse(line[0]);
        double Y = double.Parse(line[1]);
        if (Y == 0)
        {
          Console.WriteLine("divisao impossivel");
        }
        else
        {
          double divisao = X / Y;
          Console.WriteLine(divisao.ToString("N1"));
        }
      }
    }

    public static void Desafio4(){
      List<float> notas = new List<float>();
      
     	while(notas.Count < 2){
  			float n = float.Parse(Console.ReadLine());
  			if(n >= 0.0 && n <= 10.0){
  				notas.Add(n);
  			} else {
  				Console.WriteLine("nota invalida");
  			}
  		}
  		
      float media = (notas[0] + notas[1]) / notas.Count;
  		Console.WriteLine($"media = {string.Format("{0:0.00}", media)}");
    }

    public static void Desafio5(){
      string c1; //declare as suas variaveis
      string c2;
      string c3;

      c1 = Console.ReadLine(); //insira suas variaveis
      c2 = Console.ReadLine();
      c3 = Console.ReadLine();
    
      if(c1 == "vertebrado") {
        if(c2 == "ave"){
          if(c3 == "carnivoro"){
            Console.WriteLine("aguia");
          } else if(c3 == "onivoro"){
            Console.WriteLine("pomba");
          }
        } else if(c2 == "mamifero"){
          if(c3 == "herbivoro"){
            Console.WriteLine("vaca");
          } else if(c3 == "onivoro"){
            Console.WriteLine("homem");
          }
        }
      } else if(c1 == "invertebrado"){
        if(c2 == "inseto"){
          if(c3 == "hematofago"){
            Console.WriteLine("pulga");
          } else if(c3 == "herbivoro"){
            Console.WriteLine("lagarta");
          }
        } else if(c2 == "anelideo"){
          if(c3 == "hematofago"){
            Console.WriteLine("sanguessuga");
          } else if(c3 == "onivoro"){
            Console.WriteLine("minhoca");
          }
        }
      }
    }
  }
}