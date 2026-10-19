using System;

namespace WebApplication1.Modelos
{
    public class Servico
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int? UnidadeMedidaId { get; set; }
        public string Unidade { get; set; }
        public string Referencia { get; set; }
        public string Descricao { get; set; }
        public string Status { get; set; }
        public DateTime? AtualizadoEm { get; set; }
    }
}
