using Autofac;
using TesteTecnicoEluminiB3.Application;
using TesteTecnicoEluminiB3.Application.Interfaces;
using TesteTecnicoEluminiB3.Application.Services;
using TesteTecnicoEluminiB3.Domain.Interfaces;
using TesteTecnicoEluminiB3.Domain.Services;

namespace TesteTecnicoEluminiB3.Infra.CrossCutting.IoC
{
    public class DefaultModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // Serviços de aplicação
            builder.RegisterType<CalculoRendimentoService>()
                   .As<ICalculoRendimentoService>()
                   .InstancePerLifetimeScope();

            builder.RegisterType<CalculadoraInvestimentoCdbService>()
                   .As<ICalculadoraInvestimentoCdbService>()
                   .InstancePerLifetimeScope();
        }
    }
}