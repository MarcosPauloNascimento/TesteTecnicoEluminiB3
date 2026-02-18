using System;
using TesteTecnicoEluminiB3.Domain.Interfaces;
using TesteTecnicoEluminiB3.Domain.ValueObjects;

namespace TesteTecnicoEluminiB3.Domain.Services
{
    public class CalculadoraInvestimentoCdbService : ICalculadoraInvestimentoCdbService
    {
        public ResultadoCalculadora CalcularInvestimento(decimal valorInicial, int prazo)
        {
            var fator = CalculadoraTaxaCdb.ObterFatorMensal();

            var valorBruto = CalcularValorFinal(valorInicial, fator, prazo);

            var rendimento = valorBruto - valorInicial;

            var aliquota = AliquotaImposto.ObterAliquota(prazo);

            return ResultadoCalculadora.ResultadoRendimentoCDB(valorBruto, rendimento, aliquota);
        }


        private static decimal CalcularValorFinal(decimal valorInicial, decimal fator, int prazo)
        {
            var pot = Math.Pow((double)fator, prazo);

            var valorFinal = valorInicial * (decimal)pot;

            return decimal.Round(valorFinal, 2);
        }

    }
}
