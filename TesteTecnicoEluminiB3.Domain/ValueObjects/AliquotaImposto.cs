using System.Collections.Generic;
using System.Linq;

namespace TesteTecnicoEluminiB3.Domain.ValueObjects
{
    public static class AliquotaImposto
    {
        private static readonly Dictionary<int, decimal> Aliquotas = new Dictionary<int, decimal>
        {
            { 6, 0.225m },
            { 12, 0.20m },
            { 24, 0.175m }
        };

        public static decimal ObterAliquota(int prazo)
        {
            var aliquota = Aliquotas.OrderBy(k => k.Key).FirstOrDefault(x => x.Key >= prazo).Value;

            return aliquota > 0 ? aliquota : 0.15m;
        }

    }
}
