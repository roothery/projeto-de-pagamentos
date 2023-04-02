using ContextoDePagamento.Shared.Comandos;
using ContextoDePagamento.Domain.Enums;
using Flunt.Notifications;
using Flunt.Validations;

namespace ContextoDePagamento.Domain.Comandos
{
    public class CriarAssinaturaBoletoComando : Notifiable, IComando
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Documento { get; set; }
        public string Email { get; set; }

        public string CodigoDeBarras { get; set; }
        public string NumeroDoBoleto { get; set; }

        public string NumeroDoPagamento { get; set; }
        public DateTime DataDoPagamento { get; set; }
        public DateTime DateDeExpiracaoDoPagamento { get; set; }
        public decimal Total { get; set; }
        public decimal TotalPago { get; set; }
        public string Proprietario { get; set; }
        public string DocumentoDoProprietario { get; set; }
        public ETipoDeDocumento TipoDeDocumentoDoProprietario { get; set; }
        public string EmailDoProprietario { get; set; }

        public string Rua { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Pais { get; set; }
        public string Cep { get; set; }

        public void Validar()
        {
            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(Nome, 3, "NomeCompleto.Nome", "Nome deve conter pelo menos 3 caracteres")
                .HasMaxLen(Nome, 40, "NomeCompleto.Nome", "Nome deve conter até 40 caracteres")
            );
        }
    }
}