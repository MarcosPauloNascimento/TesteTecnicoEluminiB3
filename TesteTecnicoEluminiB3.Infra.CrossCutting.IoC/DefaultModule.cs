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

            //builder.RegisterType<CalculadoraInvestimentoCDBService>()
            //       .As<ICalculadoraInvestimentoService>()
            //       .InstancePerLifetimeScope();

            //builder.RegisterType<CalculadoraInvestimentoLCIService>()
            //       .As<ICalculadoraInvestimentoService>()
            //       .InstancePerLifetimeScope();

            //builder.RegisterType<CalculadoraInvestimentoLCAService>()
            //       .As<ICalculadoraInvestimentoService>()
            //       .InstancePerLifetimeScope();


            builder.RegisterType<CalculadoraInvestimentoCDBService>().AsSelf().InstancePerDependency();
            builder.RegisterType<CalculadoraInvestimentoLCIService>().AsSelf().InstancePerDependency();
            builder.RegisterType<CalculadoraInvestimentoLCAService>().AsSelf().InstancePerDependency();

            // Factory
            builder.RegisterType<InvestimentoFactory>().AsSelf().SingleInstance();




        }
    }
}