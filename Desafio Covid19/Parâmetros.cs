using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Desafio_Covid19
{
    public static class Parâmetros
    {
        public static string PessoaSaudável { get; set; }
        public static char PessoaInfectada { get; set; }
        public static int Tempo { get; set; }


        private static string Pergunta1()
        {
            Console.WriteLine("Quantos estados deseja monitorar ? ");

            return Console.ReadLine();
        }
        private static string Pergunta2()
        {
            Console.WriteLine("Quantas pessoas deseja monitorar?");

            return Console.ReadLine();
        }

        private static void Erro(this string valor)
        {
            var numero = Convert.ToInt64(valor);
            if (numero > 27)
            {
                Console.WriteLine("No Brasil temos apenas 27 estados");
                Thread.Sleep(100);
                Console.Clear();
                Resposta1();
            }
        }

        private static bool Énúmero(string valor)
        {
            try
            {
                var numero = Convert.ToInt64(valor);
                return true;
            }

            catch
            {
                Console.WriteLine("Digite um número");
                Thread.Sleep(100);
                Console.Clear();
                return false;

            }
        }

        private static int Resposta2()
        {
            var resp = true;
            var validação = "";
            do
            {
                validação = Pergunta2();
                resp = Énúmero(validação);

            } while (resp == false);
            var pessoas = Convert.ToInt32(validação);
            return pessoas;

        }
        public static (int, int) Resposta1()
        {
            var resp = true;
            var validação = "";
            do
            {
                validação = Pergunta1();
                resp = Énúmero(validação);

            } while (resp == false);
            Erro(validação);
            return (Resposta2(), Convert.ToInt32(validação));
        }


    }
}
