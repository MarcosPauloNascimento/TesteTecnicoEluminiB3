using Xunit;
using TesteTecnicoEluminiB3.Domain.ValueObjects;

namespace TesteTecnicoEluminiB3.Tests.Domain.ValueObjects
{
    public class CalculadoraTaxaCDBTests
    {
        [Fact]
        public void ObterTaxaMensal_DeveRetornar_0_00972()
        {
            // Taxa: 0,9% * 108% = 0,00972
            var taxa = CalculadoraTaxaCdb.ObterTaxaMensal();
            Assert.Equal(0.00972m, taxa);
        }

        [Fact]
        public void ObterFatorMensal_DeveRetornar_1_00972()
        {
            var fator = CalculadoraTaxaCdb.ObterFatorMensal();
            Assert.Equal(1.00972m, fator);
        }
    }
}