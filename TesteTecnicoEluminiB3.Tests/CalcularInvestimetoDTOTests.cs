using System.ComponentModel.DataAnnotations;
using System.Linq;
using TesteTecnicoEluminiB3.Application.DTOs;
using TesteTecnicoEluminiB3.Domain.Enum;
using Xunit;

namespace TesteTecnicoEluminiB3.Tests.Application.DTOs
{
    public class CalcularInvestimetoDTOTests
    {
        [Theory]
        [InlineData(0, 2, "O valor inicial deve ser maior que 0.")]
        [InlineData(-10, 2, "O valor inicial deve ser maior que 0.")]
        [InlineData(100, 1, "O prazo deve ser maior que 1.")]
        [InlineData(0, 1, "O valor inicial deve ser maior que 0.")] // primeiro erro retornado
        public void Validate_DeveRetornarErros_QuandoDadosInvalidos(decimal valorInicial, int prazo, string mensagemEsperada)
        {
            var dto = new CalcularInvestimetoDTO
            {
                ValorInicial = valorInicial,
                Prazo = prazo,
                InvestmentType = TipoInvestimento.CDB
            };

            var ctx = new ValidationContext(dto);
            var resultados = dto.Validate(ctx).ToList();

            Assert.Contains(resultados, r => r.ErrorMessage == mensagemEsperada);
        }

        [Fact]
        public void Validate_DeveNaoRetornarErros_QuandoDadosValidos()
        {
            var dto = new CalcularInvestimetoDTO
            {
                ValorInicial = 1000m,
                Prazo = 12,
                InvestmentType = TipoInvestimento.CDB
            };

            var ctx = new ValidationContext(dto);
            var resultados = dto.Validate(ctx).ToList();

            Assert.Empty(resultados);
        }
    }
}