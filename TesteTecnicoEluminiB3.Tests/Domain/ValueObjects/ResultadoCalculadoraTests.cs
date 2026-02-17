using Xunit;
using TesteTecnicoEluminiB3.Domain.ValueObjects;

namespace TesteTecnicoEluminiB3.Tests.Domain.ValueObjects
{
    public class ResultadoCalculadoraTests
    {
        [Fact]
        public void DeveCalcular_ValorImposto_e_ValorLiquido_ComArredondamento()
        {
            var resultado = new ResultadoCalculadora(
                valorBruto: 1100.001m,
                valorRendimento: 100.0009m,
                aliquota: 0.20m);

            // ValorImposto = round(100.0009 * 0.20, 2) = 20.00
            Assert.Equal(20.00m, resultado.ValorImposto);

            // ValorLiquido = round(1100.001 - 20.00, 2) = 1080.00
            Assert.Equal(1080.00m, resultado.ValorLiquido);
        }
    }
}