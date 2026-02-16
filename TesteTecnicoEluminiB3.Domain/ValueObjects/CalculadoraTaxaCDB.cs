namespace TesteTecnicoEluminiB3.Domain.ValueObjects
{
    public static class CalculadoraTaxaCDB
    {
        // CDI de 0,9% a.m. => 0.009m
        private const decimal TaxaCDI = 0.009m; //CDI

        // Banco paga 108% do CDI => 1.08m
        private const decimal MultiplicadorBanco = 1.08m; // TB

        public static decimal ObterFatorMensal()
        {
            return 1m + (TaxaCDI * MultiplicadorBanco);
        }

        public static decimal ObterTaxaMensal()
        {
            return TaxaCDI * MultiplicadorBanco;
        }
    }
}
