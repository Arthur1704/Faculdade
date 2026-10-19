using System;

namespace WebApplication1.Modelos
{
    public class SolicitacaoCadastro
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Mensagem { get; set; }
        public string Status { get; set; }
        public DateTime SolicitadoEm { get; set; }
    }
}
