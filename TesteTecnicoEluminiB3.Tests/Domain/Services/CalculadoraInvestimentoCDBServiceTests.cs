using System;
using TesteTecnicoEluminiB3.Domain.Services;
using TesteTecnicoEluminiB3.Domain.ValueObjects;
using Xunit;

namespace TesteTecnicoEluminiB3.Tests.Domain.Services
{
    public class CalculadoraInvestimentoCDBServiceTests
    {
        private static decimal Fator => CalculadoraTaxaCdb.ObterFatorMensal();

        private static decimal ValorBrutoEsperado(decimal valorInicial, int prazo)
        {
            var pot = Math.Pow((double)Fator, prazo);
            var bruto = valorInicial * (decimal)pot;
            return decimal.Round(bruto, 2);
        }

        [Theory]
        [InlineData(1000, 6, 0.225)]
        [InlineData(1000, 12, 0.20)]
        [InlineData(1000, 24, 0.175)]
        [InlineData(1000, 36, 0.15)]
        public void CalcularInvestimento_DeveAplicar_AliquotaPorPrazoEFormula(decimal valorInicial, int prazo, decimal aliquotaEsperada)
        {
            var calc = new CalculadoraInvestimentoCdbService();

            var result = calc.CalcularInvestimento(valorInicial, prazo);

            var brutoEsperado = ValorBrutoEsperado(valorInicial, prazo);
            var rendimentoEsperado = brutoEsperado - valorInicial;

            Assert.Equal(brutoEsperado, result.ValorBruto);
            Assert.Equal(rendimentoEsperado, result.Rendimento);
            Assert.Equal(aliquotaEsperada, result.Aliquota);

            // Checagem dos derivados (imposto/liquido) por consistência:
            var impostoEsperado = decimal.Round(rendimentoEsperado * aliquotaEsperada, 2);
            var liquidoEsperado = decimal.Round(brutoEsperado - impostoEsperado, 2);

            Assert.Equal(impostoEsperado, result.ValorImposto);
            Assert.Equal(liquidoEsperado, result.ValorLiquido);
        }
    }
}