using Spotify.Domain.Banco.Exception;
using Syncfusion.XForms.Android.Core;

namespace Spotify.Domain.Banco.Agreggate;
public class Cartao
{

    private const int TRANSACTION_TIME_INTERVAL = -2;
    private const int TRANSACTION_MERCHANT_REPEAT = 2;


    public Guid Id { get; set; }
    public Boolean CartaoAtivo { get; set; }
    public Decimal LimiteDisponivel { get; set; }
    public String NumeroCartao { get; set; }
    public List<Transacao.Agreggate.Transferencia> Transferencias { get; set; }

    public Cartao()
    {
        this.Transferencias = new List<Transacao.Agreggate.Transferencia>();
    }

    public void CriarTransacao(string comerciante, Decimal valor, string aviso)
    {
        CartaoException validationErrors = new CartaoException();

        //Verificar se o cartao está ativo
        this.IsCartaoAtivo(validationErrors);

        Transacao.Agreggate.Transferencia transferencia = new Transacao.Agreggate.Transferencia();
        transferencia.Comerciante = new Transacao.ValueObject.Comerciante() { NomeEmpresa = comerciante };
        transferencia.Valor = valor;
        transferencia.AvisoConfirmacao = aviso;
        transferencia.TempoTranferencia = DateTime.Now;

        //Verificar o Limite
        this.VerificaLimiteDisponivel(transferencia, validationErrors);

        //Validar a transação
        this.ValidarTransacao(transferencia, validationErrors);

        //Verifica senão ocorreu erros de validação
        validationErrors.ValidateAndThrow();

        //Criar numero de Autorização
        transferencia.Id = Guid.NewGuid();

        //Diminui o limite com o valor da transação
        this.LimiteDisponivel = this.LimiteDisponivel - transferencia.Valor;

        //Adicionar uma nova transação
        this.Transferencias.Add(transferencia);

    }

    private void IsCartaoAtivo(CartaoException validationErrors)
    {
        if (this.CartaoAtivo == false)
        {
            validationErrors.AddError(new Core.Exception.BusinessValidation()
            {
                ErrorMessage = "Cartão não está ativo",
                ErrorName = nameof(CartaoException)
            });

        }

    }

    private void VerificaLimiteDisponivel(Transacao.Agreggate.Transferencia transferencia, CartaoException validationErrors)
    {
        if (transferencia.Valor > this.LimiteDisponivel)
        {
            validationErrors.AddError(new Core.Exception.BusinessValidation()
            {
                ErrorMessage = "Cartão não possui limite para esta transação",
                ErrorName = nameof(CartaoException)
            });
        }
    }

    private void ValidarTransacao(Transacao.Agreggate.Transferencia transferencia, CartaoException validationErrors)
    {
        var ultimasTransacoes = this.Transferencias.Where(x => x.TempoTranferencia >= DateTime.Now.AddMinutes(TRANSACTION_TIME_INTERVAL));

        if (ultimasTransacoes?.Count() >= 3)
        {
            validationErrors.AddError(new Core.Exception.BusinessValidation()
            {
                ErrorMessage = "Cartão utilizado muitas vezes em um período curto",
                ErrorName = nameof(CartaoException)
            });
        }

        if (ultimasTransacoes?.Where(x => x.Comerciante.NomeEmpresa.ToUpper() == transferencia.Comerciante.NomeEmpresa.ToUpper()
                                     && x.Valor == transferencia.Valor).Count() == TRANSACTION_MERCHANT_REPEAT)
        {
            validationErrors.AddError(new Core.Exception.BusinessValidation()
            {
                ErrorMessage = "Transação duplicada para o mesmo cartão e mesmo merchant",
                ErrorName = nameof(CartaoException)
            });
        }
    }
}