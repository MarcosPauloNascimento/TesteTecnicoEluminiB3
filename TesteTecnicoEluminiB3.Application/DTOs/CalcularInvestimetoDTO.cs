using TesteTecnicoEluminiB3.Domain.Enum;

namespace TesteTecnicoEluminiB3.Application.DTOs
{
    public class CalcularInvestimetoDTO
    {
        public decimal ValorInicial { get; set; }

        public int Prazo { get; set; }

        public TipoInvestimento  InvestmentType { get; set; }
    }
}
