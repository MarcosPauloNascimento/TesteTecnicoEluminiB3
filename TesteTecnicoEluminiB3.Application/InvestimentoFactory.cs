using Autofac;
using System;
using TesteTecnicoEluminiB3.Domain.Enum;
using TesteTecnicoEluminiB3.Domain.Interfaces;
using TesteTecnicoEluminiB3.Domain.Services;

namespace TesteTecnicoEluminiB3.Application
{
    public class InvestimentoFactory
    {
        private readonly IComponentContext _ctx;

        public InvestimentoFactory(IComponentContext ctx)
        {
            _ctx = ctx;
        }

        public ICalculadoraInvestimentoService Criar(TipoInvestimento investimentType)
        {
            switch (investimentType)
            {
                case TipoInvestimento.CDB:
                    return _ctx.Resolve<CalculadoraInvestimentoCDBService>();
                case TipoInvestimento.LCI:
                    return _ctx.Resolve<CalculadoraInvestimentoLCIService>();
                case TipoInvestimento.LCA:
                    return _ctx.Resolve<CalculadoraInvestimentoLCAService>();
                default:
                    throw new NotSupportedException($"Tipo {investimentType} não suportado.");
            }
        }
    }
}
