using TesteTecnicoEluminiB3.Application.DTOs;
using TesteTecnicoEluminiB3.Domain.ValueObjects;

namespace TesteTecnicoEluminiB3.Application.Mapper
{
    public static class ResultadoCalculoMapper
    {
        public static ResultadoCalculoDTO Map(this ResultadoCalculadora resultado)
        {
            return new ResultadoCalculoDTO
            {
                ValorBruto = resultado.ValorBruto,
                Rendimento = resultado.Rendimento,
                ValorLiquido = resultado.ValorLiquido,
                ValorImposto = resultado.ValorImposto,
                Aliquota = resultado.Aliquota
            };
        }
    }
}
