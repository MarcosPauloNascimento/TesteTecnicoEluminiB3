namespace TesteTecnicoEluminiB3.Domain.ValueObjects
{
    public sealed class ResultadoCalculadora
    {
        private decimal valorRendimento;

        public ResultadoCalculadora(decimal valorBruto, decimal valorRendimento, decimal aliquota)
        {
            ValorBruto = valorBruto;
            Rendimento = valorRendimento;
            Aliquota = aliquota;
        }

        public decimal ValorBruto { get; set; }

        public decimal Rendimento { get; set; }

        public decimal Aliquota { get; set; }

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
    }
}
