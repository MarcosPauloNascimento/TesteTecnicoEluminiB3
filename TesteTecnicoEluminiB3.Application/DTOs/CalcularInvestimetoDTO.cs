using System.ComponentModel.DataAnnotations;
using TesteTecnicoEluminiB3.Domain.Enum;

namespace TesteTecnicoEluminiB3.Application.DTOs
{
    public class CalcularInvestimetoDTO
    {
        [Required(ErrorMessage = "O valor inicial é obrigatório.")]
        public decimal ValorInicial { get; set; }

        [Required(ErrorMessage = "O prazo é obrigatório.")]
        public int Prazo { get; set; }

        public TipoInvestimento  InvestmentType { get; set; }
    }
}
