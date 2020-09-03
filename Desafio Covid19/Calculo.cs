using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio_Covid19
{
    public class Calculo : Monitoramento
    {
        public (int,int) LocalizaInfectado()
        {
            var pessoasmonitoradas = Estados * Pessoas;
            var numeroaleatório =  new Random().Next(1,pessoasmonitoradas );
            var linha = numeroaleatório/Pessoas ;
            var posição = numeroaleatório - (Pessoas * linha);
            return (linha, posição);
        }
    }
}
