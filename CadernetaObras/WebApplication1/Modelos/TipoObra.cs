using System;

namespace WebApplication1.Modelos
{
    public class TipoObra
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public string Observacoes { get; set; }
        public string Status { get; set; }
        public DateTime? AtualizadoEm { get; set; }
    }
}
