using ContextoContextoDePagamento.Domain.Comandos;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ContextoContextoDePagamento.Tests
{
    [TestClass]
    public class CriarAssinaturaBoletoComandoTests
    {
        [TestMethod]
        public void Deve_retornar_erro_para_nome_invalido()
        {
            var comando = new CriarAssinaturaBoletoComando();
            comando.Nome = "";

            comando.Validar();
            Assert.AreEqual(false, comando.Valid);
        }
    }
}