using Xunit;
using TesteTecnicoEluminiB3.Domain.ValueObjects;

namespace TesteTecnicoEluminiB3.Tests.Domain.ValueObjects
{
    public class AliquotaImpostoTests
    {
        [Theory]
        [InlineData(1, 0.225)]
        [InlineData(6, 0.225)]
        [InlineData(7, 0.20)]
        [InlineData(12, 0.20)]
        [InlineData(18, 0.175)]
        [InlineData(24, 0.175)]
        [InlineData(25, 0.15)]
        [InlineData(36, 0.15)]
        public void ObterAliquota_DeveRespeitar_FaixasDePrazo(int prazo, decimal esperada)
        {
            var aliquota = AliquotaImposto.ObterAliquota(prazo);
            Assert.Equal(esperada, aliquota);
        }
    }
}