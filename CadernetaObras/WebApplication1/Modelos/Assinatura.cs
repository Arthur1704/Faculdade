using System;

namespace WebApplication1.Modelos
{
    public class Assinatura
    {
        public string Papel { get; set; }
        public string NomeAssinante { get; set; }
        public int UsuarioId { get; set; }
        public string Imagem { get; set; }
        public string Hash { get; set; }
        public string Ip { get; set; }
        public DateTime Data { get; set; }
    }
}
