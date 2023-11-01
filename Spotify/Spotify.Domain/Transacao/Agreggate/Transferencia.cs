using Spotify.Domain.Transacao.ValueObject;
using System;

namespace Spotify.Domain.Transacao.Agreggate;
public class Transferencia
{
    public Guid Id { get; set; }
    public bool Autorizacao { get; set; }
    public string AvisoConfirmacao { get; set; }
    public DateTime TempoTranferencia { get; set; }
    public Decimal Valor { get; set; }
    public Comerciante Comerciante { get; set; }

  
}