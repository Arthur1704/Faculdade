using System;

namespace WebApplication1.Modelos
{
    public class ObraDocumento
    {
        public int Id { get; set; }
        public int ObraId { get; set; }
        public string NomeDocumento { get; set; }
        public string TipoDocumento { get; set; }
        public string NomeOriginal { get; set; }
        public string CaminhoArquivo { get; set; }
        public string ContentType { get; set; }
        public long? TamanhoBytes { get; set; }
    }
}
