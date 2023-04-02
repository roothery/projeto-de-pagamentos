using ContextoDePagamento.Shared.ObjetosDeValores;
using ContextoDePagamento.Domain.Enums;
using Flunt.Validations;

namespace ContextoDePagamento.Domain.ObjetosDeValores
{
    public class Documento : ObjetoDeValor
    {
        public Documento(string numero, ETipoDeDocumento tipoDeDocumento)
        {
            Numero = numero;
            TipoDeDocumento = tipoDeDocumento;

            AddNotifications(new Contract()
                .Requires()
                .IsTrue(Validar(), "Documento.Numero", "Documento inválido"));
        }

        public string Numero { get; private set; }
        public ETipoDeDocumento TipoDeDocumento { get; private set; }

        private bool Validar()
        {
            if (TipoDeDocumento == ETipoDeDocumento.CNPJ && Numero.Length == 14)
                return true;

            if (TipoDeDocumento == ETipoDeDocumento.CPF && Numero.Length == 11)
                return true;

            return false;
        }
    }
}