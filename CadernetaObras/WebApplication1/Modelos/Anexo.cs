using System;

namespace WebApplication1.Modelos
{
    public class Anexo
    {
        public int Id { get; set; }
        public int RelatoVisitaId { get; set; }
        public string NomeOriginal { get; set; }
        public string Descricao { get; set; }
        public string CaminhoArquivo { get; set; }
        public string ContentType { get; set; }
        public long? TamanhoBytes { get; set; }
    }
}
