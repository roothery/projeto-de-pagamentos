using ContextoDePagamento.Domain.Entidades;
using ContextoDePagamento.Domain.Enums;
using ContextoDePagamento.Domain.ObjetosDeValores;

namespace ContextoDePagamento.Tests;

[TestClass]
public class AlunoTests
{
    private readonly NomeCompleto _nomeCompleto;
    private readonly Email _email;
    private readonly Documento _documento;
    private readonly Endereco _endereco;
    private readonly Aluno _aluno;

    public AlunoTests()
    {
        _nomeCompleto = new NomeCompleto("Bruce", "Wayne");
        _documento = new Documento("35111507795", ETipoDeDocumento.CPF);
        _email = new Email("batman@dc.com");
        _endereco = new Endereco("Rua 1", "1234", "Bairro Legal", "Gotham", "SP", "BR", "13400000");
        _aluno = new Aluno(_nomeCompleto, _documento, _email);

    }
    [TestMethod]
    public void Deve_retornar_erro_quando_possuir_assinatura_ativa()
    {
        var assinatura = new Assinatura(null);
        var pgtoPaypal = new Paypal("12345678", DateTime.Now, DateTime.Now.AddDays(5), 10, 10, "WAYNE CORP", _documento, _endereco, _email);

        assinatura.AdicionarFormaDePagamento(pgtoPaypal);
        _aluno.AdicionarAssinatura(assinatura);
        _aluno.AdicionarAssinatura(assinatura);

        Assert.IsTrue(_aluno.Invalid);
    }

    [TestMethod]
    public void Deve_retornar_sucesso_quando_nao_possuir_assinatura_ativa()
    {
        var assinatura = new Assinatura(null);
        var pgtoPaypal = new Paypal("12345678", DateTime.Now, DateTime.Now.AddDays(5), 10, 10, "WAYNE CORP", _documento, _endereco, _email);

        assinatura.AdicionarFormaDePagamento(pgtoPaypal);
        _aluno.AdicionarAssinatura(assinatura);

        Assert.IsTrue(_aluno.Valid);
    }

    [TestMethod]
    public void Deve_retornar_erro_para_assinatura_sem_pagamento()
    {
        var assinatura = new Assinatura(null);
        _aluno.AdicionarAssinatura(assinatura);

        Assert.IsTrue(_aluno.Invalid);
    }
}