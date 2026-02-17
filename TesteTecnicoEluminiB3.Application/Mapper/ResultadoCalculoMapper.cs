using TesteTecnicoEluminiB3.Application.DTOs;
using TesteTecnicoEluminiB3.Domain.ValueObjects;

namespace TesteTecnicoEluminiB3.Application.Mapper
{
    public static class ResultadoCalculoMapper
    {
        public static ResultadoCalculoDto Map(this ResultadoCalculadora resultado)
        {
            return new ResultadoCalculoDto
            {
                ValorBruto = resultado.ValorBruto,
                Rendimento = resultado.Rendimento,
                ValorLiquido = resultado.ValorLiquido,
                ValorImposto = resultado.ValorImposto,
                AliquotaAplicada = resultado.Aliquota
            };
        }
    }
}
