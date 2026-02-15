using System;
using TesteTecnicoEluminiB3.Domain.Enum;
using TesteTecnicoEluminiB3.Domain.Interfaces;
using TesteTecnicoEluminiB3.Domain.Services;

namespace TesteTecnicoEluminiB3.Application
{
    public class InvestimentoFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public InvestimentoFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public CalculadoraInvestimentoService Criar(TipoInvestimento investimentType)
        {
            switch (investimentType)
            {
                case TipoInvestimento.CDB:
                    return _serviceProvider.GetService(typeof(CalculadoraInvestimentoCDBService))
                        as CalculadoraInvestimentoService;

                case TipoInvestimento.LCI:
                    return _serviceProvider.GetService(typeof(CalculadoraInvestimentoLCIService))
                        as CalculadoraInvestimentoService;

                case TipoInvestimento.LCA:
                    return _serviceProvider.GetService(typeof(CalculadoraInvestimentoLCAService))
                        as CalculadoraInvestimentoService;

                default:
                    throw new NotImplementedException();
            }
        }
    }
}
