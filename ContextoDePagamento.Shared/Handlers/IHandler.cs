using ContextoDePagamento.Shared.Comandos;

namespace ContextoDePagamento.Shared.Handlers
{
    public interface IHandler<T> where T : IComando
    {
        IComandoResult Handle(T comando);
    }
}