using Moq;
using TesteTecnicoEluminiB3.Application.DTOs;
using TesteTecnicoEluminiB3.Application.Services;
using TesteTecnicoEluminiB3.Domain.Interfaces;
using TesteTecnicoEluminiB3.Domain.ValueObjects;
using Xunit;

namespace TesteTecnicoEluminiB3.Tests.Application.Services
{
    public class CalculoRendimentoServiceTests
    {
        [Fact]
        public void ObterCalculoInvestimento_DeveRetornarResultadoMapeadoCorretamente()
        {
            // Arrange (Configuração)
            var mockCalculadora = new Mock<ICalculadoraInvestimentoCdbService>();

            var dtoEntrada = new CalcularInvestimetoDto
            {
                ValorInicial = 1000,
                Prazo = 12                
            };

            // Simulamos o que o serviço de cálculo (CDB) deve retornar
            var retornoEsperadoDaCalculadora = new ResultadoCalculadora(1100, 100, 0.225m);

            mockCalculadora
                .Setup(x => x.CalcularInvestimento(dtoEntrada.ValorInicial, dtoEntrada.Prazo))
                .Returns(retornoEsperadoDaCalculadora);

            var service = new CalculoRendimentoService(mockCalculadora.Object);

            // Act (Execução)
            var resultado = service.ObterCalculoInvestimento(dtoEntrada);

            // Assert (Verificação)
            Assert.NotNull(resultado);
            // Aqui você verifica se o Mapper funcionou (supondo que o DTO de saída tenha ValorBruto)
            Assert.Equal(1100, resultado.ValorBruto);

            // Verifica se a calculadora foi chamada exatamente uma vez com os parâmetros corretos
            mockCalculadora.Verify(x => x.CalcularInvestimento(1000, 12), Times.Once);
        }
    }
}