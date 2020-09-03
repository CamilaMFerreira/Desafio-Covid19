using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Desafio_Covid19
{
    class Program
    {
        static void Main(string[] args)
        {
            Parâmetros.PessoaInfectada ='_';
            Parâmetros.PessoaSaudável ="|";
            Parâmetros.Tempo =60;

            var resp = Parâmetros.Resposta1();

            var calculo = new Calculo();
            calculo.Pessoas = resp.Item1;
            calculo.Estados = resp.Item2;
            var linhainteira = "";
            var lista = new List<string>();
            for(int i =0; i < calculo.Pessoas; i++) 
            {
                linhainteira += Parâmetros.PessoaSaudável;
            }
            for (int i = 0; i < calculo.Estados; i++)
            {
                lista.Add(linhainteira);
            }
            Console.Clear();
            foreach (var x in lista) 
                Console.WriteLine(x);

            Thread.Sleep(100);
            Console.Clear();
            for (int i=0; i< Parâmetros.Tempo; i++) 
            {

                Console.Clear();
                var localização = calculo.LocalizaInfectado();

                for(var k = 0; k < lista.Count(); k++) 
                {
                    if (k == localização.Item1) 
                    {
                        char[] linhaarray = lista[k].ToCharArray();
                        Console.ForegroundColor = ConsoleColor.Red;
                        for (var j =0; j< calculo.Pessoas; j++) 
                        {
                            if (j == localização.Item2) 
                            {
                                linhaarray[j] = Parâmetros.PessoaInfectada ;
                                lista[k] = new string(linhaarray);
                            }
                        }
                        Console.WriteLine($"Estado {k}\t {lista[k]}");
                    }
                    else 
                    {
                        Console.ResetColor();
                        Console.WriteLine($"Estado {k}\t {lista[k]}");
                    }
                }
                
                Thread.Sleep(1000);
            }

            Console.ReadKey();
        }
    }
}
