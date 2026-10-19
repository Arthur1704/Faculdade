using System;

namespace WebApplication1.Modelos
{
    public class Recibo
    {
        public int Id { get; set; }
        public string Numero { get; set; }
        public int ObraId { get; set; }
        public string Obra { get; set; }
        public int ProprietarioId { get; set; }
        public string Proprietario { get; set; }
        public DateTime DataEmissao { get; set; }
        public decimal Valor { get; set; }
        public int? FormaPagamentoId { get; set; }
        public string FormaPagamento { get; set; }
        public string Status { get; set; }
        public string ReferenteA { get; set; }
        public string Observacoes { get; set; }
    }
}
