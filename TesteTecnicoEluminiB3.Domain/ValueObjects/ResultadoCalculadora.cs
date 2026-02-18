using TesteTecnicoEluminiB3.Domain.Enum;

namespace TesteTecnicoEluminiB3.Domain.ValueObjects
{
    public sealed class ResultadoCalculadora
    {
        public ResultadoCalculadora(decimal valorBruto, decimal valorRendimento, decimal aliquota, TipoInvestimento tipoInvestimento)
        {
            ValorBruto = valorBruto;
            Rendimento = valorRendimento;
            Aliquota = aliquota;
            TipoInvestimento = tipoInvestimento;
        }

        public decimal ValorBruto { get; set; }

        public decimal Rendimento { get; set; }

        public decimal Aliquota { get; set; }

        public TipoInvestimento TipoInvestimento { get; set; }

        public decimal ValorLiquido
        { 
            get
            {
                return decimal.Round(ValorBruto - ValorImposto, 2);
            }
        }

        public decimal ValorImposto
        {
            get
            {
                return decimal.Round(Rendimento * Aliquota, 2);
            } 
        }

        public static ResultadoCalculadora ResultadoRendimentoCDB(decimal valorBruto, decimal valorRendimento, decimal aliquota)
            => new ResultadoCalculadora(valorBruto, valorRendimento, aliquota, TipoInvestimento.CDB);
    }
}
