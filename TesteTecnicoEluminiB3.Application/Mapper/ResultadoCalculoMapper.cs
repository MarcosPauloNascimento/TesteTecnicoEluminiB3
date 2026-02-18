using TesteTecnicoEluminiB3.Application.DTOs;
using TesteTecnicoEluminiB3.Domain.ValueObjects;

namespace TesteTecnicoEluminiB3.Application.Mapper
{
    public static class ResultadoCalculoMapper
    {
        public static ResultadoCalculoDto Map(this ResultadoCalculadora resultado, CalcularInvestimetoDto calcularInvestimento)
        {
            return new ResultadoCalculoDto
            {
                ValorBruto = $"R$ {resultado.ValorBruto:F2}",
                Rendimento = $"R$ {resultado.Rendimento:F2}",
                ValorLiquido = $"R$ {resultado.ValorLiquido:F2}",
                ValorImposto = $"R$ {resultado.ValorImposto:F2}",
                AliquotaAplicada = $"{decimal.Round((resultado.Aliquota * 100), 2)}%",
                ValorInicial = $"R$ {calcularInvestimento.ValorInicial:F2}",
                Prazo = calcularInvestimento.Prazo,
                TipoInvestimento = resultado.TipoInvestimento.ToString()
            };
        }
    }
}
