using System.Collections.Generic;
using System.Linq;

namespace TesteTecnicoEluminiB3.Domain.ValueObjects
{
    public sealed class AliquotaImposto
    {
        private static readonly Dictionary<int, decimal> Aliquotas = new Dictionary<int, decimal>
        {
            { 6, 0.225m },
            { 12, 0.20m },
            { 24, 0.175m }
        };

        public static decimal ObterAliquota(int prazo)
        {
            foreach (var x in Aliquotas.Keys.OrderBy(k => k))
            {
                if (prazo <= x)
                    return Aliquotas[x];
            }

            // senão encontrar um prazo específico, aplica a alíquota mais baixa (15%)
            return 0.15m;
        }

    }
}
