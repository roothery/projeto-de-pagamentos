using ContextoContextoDePagamento.Shared.ObjetosDeValores;
using ContextoDePagamento.Domain.Enums;

namespace ContextoDePagamento.Domain.ObjetosDeValores
{
    public class Documento : ObjetoDeValor
    {
        public Documento(string numero, ETipoDeDocumento tipoDeDocumento)
        {
            Numero = numero;
            TipoDeDocumento = tipoDeDocumento;
        }

        public string Numero { get; private set; }
        public ETipoDeDocumento TipoDeDocumento { get; private set; }
    }
}