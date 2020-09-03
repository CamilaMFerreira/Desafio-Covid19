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
            Parâmetros.PessoaInfectada ='I';
            Parâmetros.PessoaSaudável ="-";
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
                        string linha = lista[k];
                        char[] linhaarray = linha.ToCharArray();
                        Console.ForegroundColor = ConsoleColor.Red;
                        for (var j =0; j< calculo.Pessoas; j++) 
                        {
                            if (j == localização.Item2) 
                            {
                                linhaarray[j] = Parâmetros.PessoaInfectada ;
                                linha = new string(linhaarray);
                            }
                        }
                        lista[k] = linha;
                        Console.WriteLine(lista[k]);
                    }
                    Console.ResetColor();
                    Console.WriteLine(lista[k]);
                }
                
                Thread.Sleep(1000);
            }

            Console.ReadKey();
        }
    }
}
