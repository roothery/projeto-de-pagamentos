using ContextoDePagamento.Shared.Comandos;
using ContextoDePagamento.Shared.Handlers;
using ContextoDePagamento.Domain.Comandos;
using Flunt.Notifications;
using ContextoDePagamento.Domain.Repositorios;
using ContextoDePagamento.Domain.ObjetosDeValores;
using ContextoDePagamento.Domain.Enums;
using ContextoDePagamento.Domain.Entidades;
using ContextoDePagamento.Domain.Servicos;

namespace ContextoDePagamento.Domain.Handlers
{
    public class AssinaturaHandler : Notifiable,
        IHandler<CriarAssinaturaBoletoComando>,
        IHandler<CriarAssinaturaPaypalComando>
    {
        private readonly IAlunoRepositorio _alunoRepositorio;
        private readonly IEmailServico _emailServico;

        public AssinaturaHandler(
            IAlunoRepositorio alunoRepositorio,
            IEmailServico emailServico)
        {
            _alunoRepositorio = alunoRepositorio;
            _emailServico = emailServico;
        }
        public IComandoResult Handle(CriarAssinaturaBoletoComando comando)
        {
            comando.Validar();

            if (comando.Invalid)
            {
                AddNotifications(comando);
                return new ComandoResult(false, "Não foi possível realizar sua assinatura");
            }

            if (_alunoRepositorio.ExisteDocumento(comando.Documento))
                AddNotification("Documento", "Este CPF já está em uso");

            if (_alunoRepositorio.ExisteEmail(comando.Email))
                AddNotification("Email", "Este E-mail já está em uso");

            var nomeCompleto = new NomeCompleto(comando.Nome, comando.Sobrenome);
            var documento = new Documento(comando.Documento, ETipoDeDocumento.CPF);
            var email = new Email(comando.Email);
            var endereco = new Endereco(comando.Rua, comando.Numero, comando.Bairro, comando.Cidade,
                                        comando.Estado, comando.Pais, comando.Cep);

            var aluno = new Aluno(nomeCompleto, documento, email);
            var assinatura = new Assinatura(DateTime.Now.AddMonths(1));
            var boleto = new Boleto(
                comando.CodigoDeBarras,
                comando.NumeroDoBoleto,
                comando.DataDoPagamento,
                comando.DateDeExpiracaoDoPagamento,
                comando.Total,
                comando.TotalPago,
                comando.Proprietario,
                new Documento(comando.DocumentoDoProprietario, comando.TipoDeDocumentoDoProprietario),
                endereco,
                email
            );

            assinatura.AdicionarFormaDePagamento(boleto);
            aluno.AdicionarAssinatura(assinatura);

            AddNotifications(nomeCompleto, documento, email, endereco, aluno, assinatura, boleto);

            if (Invalid)
                return new ComandoResult(false, "Não foi possível realizar sua assinatura");

            _alunoRepositorio.CriarAssinatura(aluno);

            _emailServico.Enviar(aluno.Nome.ToString(), aluno.Email.Endereco, "Bem vindo ao balta.io", "Sua assinatura foi criada!");

            return new ComandoResult(true, "Assinatura realizada com sucesso");
        }

        public IComandoResult Handle(CriarAssinaturaPaypalComando comando)
        {
            if (_alunoRepositorio.ExisteDocumento(comando.Documento))
                AddNotification("Documento", "Este CPF já está em uso");

            if (_alunoRepositorio.ExisteEmail(comando.Email))
                AddNotification("Email", "Este E-mail já está em uso");

            var nomeCompleto = new NomeCompleto(comando.Nome, comando.Sobrenome);
            var documento = new Documento(comando.Documento, ETipoDeDocumento.CPF);
            var email = new Email(comando.Email);
            var endereco = new Endereco(comando.Rua, comando.Numero, comando.Bairro, comando.Cidade,
                                        comando.Estado, comando.Pais, comando.Cep);

            var aluno = new Aluno(nomeCompleto, documento, email);
            var assinatura = new Assinatura(DateTime.Now.AddMonths(1));

            var payPal = new Paypal(
                comando.CodigoDaTransacao,
                comando.DataDoPagamento,
                comando.DateDeExpiracaoDoPagamento,
                comando.Total,
                comando.TotalPago,
                comando.Proprietario,
                new Documento(comando.DocumentoDoProprietario, comando.TipoDeDocumentoDoProprietario),
                endereco,
                email
            );

            assinatura.AdicionarFormaDePagamento(payPal);
            aluno.AdicionarAssinatura(assinatura);

            AddNotifications(nomeCompleto, documento, email, endereco, aluno, assinatura, payPal);

            if (Invalid)
                return new ComandoResult(false, "Não foi possível realizar sua assinatura");

            _alunoRepositorio.CriarAssinatura(aluno);

            _emailServico.Enviar(aluno.Nome.ToString(), aluno.Email.Endereco, "Bem vindo ao balta.io", "Sua assinatura foi criada!");

            return new ComandoResult(true, "Assinatura realizada com sucesso");
        }
    }
}