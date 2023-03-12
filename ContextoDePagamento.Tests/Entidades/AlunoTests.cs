using ContextoDePagamento.Domain.Entidades;

namespace ContextoDePagamento.Tests;

[TestClass]
public class AlunoTests
{
    [TestMethod]
    public void AdicionarAssinatura()
    {
        var assinatura = new Assinatura(null);
        var aluno = new Aluno("Enzo", "Tenório", "70226403190", "enzo_tenorio@outlook.com");
        aluno.AdicionarAssinatura(assinatura);
    }
}