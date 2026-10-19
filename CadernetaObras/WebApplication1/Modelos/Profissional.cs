using System;

namespace WebApplication1.Modelos
{
    public class Profissional
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public int TipoProfissionalId { get; set; }
        public string TipoProfissional { get; set; }
        public int? TipoRegistroId { get; set; }
        public string TipoRegistro { get; set; }
        public string NumeroRegistro { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public string Status { get; set; }
        public string Observacoes { get; set; }
        public DateTime? AtualizadoEm { get; set; }
    }
}
