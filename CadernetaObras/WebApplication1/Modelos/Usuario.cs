using System;

namespace WebApplication1.Modelos
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Matricula { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public int PerfilId { get; set; }
        public string Perfil { get; set; }
        public string Status { get; set; }
        public string SenhaHash { get; set; }
        public DateTime? AtualizadoEm { get; set; }
    }
}
