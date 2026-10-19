using System;

namespace WebApplication1.Modelos
{
    public class Proprietario
    {
        public int Id { get; set; }
        public string NomeRazaoSocial { get; set; }
        public string CpfCnpj { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public string Cep { get; set; }
        public string Endereco { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Status { get; set; }
        public DateTime? AtualizadoEm { get; set; }
    }
}
