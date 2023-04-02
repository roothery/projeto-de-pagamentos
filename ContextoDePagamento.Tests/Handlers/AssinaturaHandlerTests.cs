using ContextoDePagamento.Domain.Comandos;
using ContextoDePagamento.Domain.Enums;
using ContextoDePagamento.Domain.Handlers;
using ContextoDePagamento.Tests.Mocks;

namespace ContextoDePagamento.Tests
{
    [TestClass]
    public class SubscriptionHandlerTests
    {
        // Red, Green, Refactor

        [TestMethod]
        public void Deve_retornar_erro_quando_existir_documento()
        {
            var handler = new AssinaturaHandler(new FakeAlunoRepositorio(), new FakeEmailServico());
            var comando = new CriarAssinaturaBoletoComando();
            comando.Nome = "Bruce";
            comando.Sobrenome = "Wayne";
            comando.Documento = "99999999999";
            comando.Email = "hello@balta.io2";
            comando.CodigoDeBarras = "123456789";
            comando.NumeroDoBoleto = "1234654987";
            comando.NumeroDoPagamento = "123121";
            comando.DataDoPagamento = DateTime.Now;
            comando.DateDeExpiracaoDoPagamento = DateTime.Now.AddMonths(1);
            comando.Total = 60;
            comando.TotalPago = 60;
            comando.Proprietario = "WAYNE CORP";
            comando.DocumentoDoProprietario = "12345678911";
            comando.TipoDeDocumentoDoProprietario = ETipoDeDocumento.CPF;
            comando.EmailDoProprietario = "batman@dc.com";
            comando.Rua = "rua teste";
            comando.Numero = "132";
            comando.Bairro = "bairro teste";
            comando.Cidade = "cidade fake";
            comando.Estado = "estado fake";
            comando.Pais = "Brazuka";
            comando.Cep = "12345678";

            handler.Handle(comando);
            Assert.AreEqual(false, handler.Valid);
        }
    }
}