using Autofac;
using Moq;
using TesteTecnicoEluminiB3.Application;
using TesteTecnicoEluminiB3.Application.DTOs;
using TesteTecnicoEluminiB3.Application.Services;
using TesteTecnicoEluminiB3.Domain.Enum;
using TesteTecnicoEluminiB3.Domain.Services;
using Xunit;

namespace TesteTecnicoEluminiB3.Tests.Application.Services
{
    public class CalculoRendimentoServiceTests
    {
        [Fact]
        public void ObterCalculoInvestimento_CDB_DeveUtilizarFactory_CalcularEMapearResultado()
        {
            // Arrange
            var ctxMock = new Mock<IComponentContext>();

            // A factory vai pedir para resolver CalculadoraInvestimentoCDBService
            // Retornamos a implementação real para calcular de verdade:
            ctxMock
                .Setup(c => c.Resolve<CalculadoraInvestimentoCDBService>())
                .Returns(new CalculadoraInvestimentoCDBService());

            // Para LCI/LCA, nem precisamos setupar aqui, porque este teste foca no CDB.
            var factory = new InvestimentoFactory(ctxMock.Object); // construtor real
            var service = new CalculoRendimentoService(factory);

            var dto = new CalcularInvestimetoDTO
            {
                ValorInicial = 1000m,
                Prazo = 12,
                InvestmentType = TipoInvestimento.CDB
            };

            // Act
            var resultado = service.ObterCalculoInvestimento(dto);

            // Assert -- conferimos que o mapeamento trouxe campos coerentes:
            Assert.True(resultado.ValorBruto > 0);
            Assert.True(resultado.Rendimento > 0);
            Assert.True(resultado.ValorLiquido > 0);
            Assert.Equal(resultado.ValorBruto - resultado.ValorLiquido, resultado.ValorImposto);
            Assert.Equal(0.20m, resultado.AliquotaAplicada); // 12 meses -> 20%
        }
    }
}