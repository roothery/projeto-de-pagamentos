using ContextoDePagamento.Domain.Enums;
using ContextoDePagamento.Domain.ObjetosDeValores;

namespace ContextoDePagamento.Tests;

[TestClass]
public class DocumentoTests
{
    [TestMethod]
    public void Deve_retornar_erro_quando_cnpj_for_invalido()
    {
        var documento = new Documento("123", ETipoDeDocumento.CNPJ);
        Assert.IsTrue(documento.Invalid);
    }

    [TestMethod]
    public void Deve_retornar_sucesso_quando_cnpj_for_valido()
    {
        var documento = new Documento("34110468000150", ETipoDeDocumento.CNPJ);
        Assert.IsTrue(documento.Valid);
    }

    [TestMethod]
    public void Deve_retornar_erro_quando_cpf_for_invalido()
    {
        var documento = new Documento("123", ETipoDeDocumento.CPF);
        Assert.IsTrue(documento.Invalid);
    }

    [TestMethod]
    [DataTestMethod]
    [DataRow("34225545806")]
    [DataRow("54139739347")]
    [DataRow("01077284608")]
    public void Deve_retornar_sucesso_quando_cpf_for_valido(string cpf)
    {
        var documento = new Documento(cpf, ETipoDeDocumento.CPF);
        Assert.IsTrue(documento.Valid);
    }
}