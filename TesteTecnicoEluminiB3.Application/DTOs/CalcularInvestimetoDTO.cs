using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TesteTecnicoEluminiB3.Application.DTOs
{
    public class CalcularInvestimetoDto : IValidatableObject
    {
        [Required(ErrorMessage = "O valor inicial é obrigatório.")]
        public decimal ValorInicial { get; set; }

        [Required(ErrorMessage = "O prazo é obrigatório.")]
        public int Prazo { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (ValorInicial <= 0)
            {
                yield return new ValidationResult(
                    "O valor inicial deve ser maior que 0.",
                    new[] { nameof(ValorInicial) }
                );
            }

            if (Prazo <= 1)
            {
                yield return new ValidationResult(
                    "O prazo deve ser maior que 1.",
                    new[] { nameof(Prazo) }
                );
            }
        }
    }
}
