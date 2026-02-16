using TesteTecnicoEluminiB3.Domain.ValueObjects;

namespace TesteTecnicoEluminiB3.Domain.Interfaces
{
    public interface ICalculadoraInvestimentoService
    {
        ResultadoCalculadora CalcularInvestimento(decimal valorInicial, int prazo);
    }
}
