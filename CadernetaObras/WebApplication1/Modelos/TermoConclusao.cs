using System;

namespace WebApplication1.Modelos
{
    public class TermoConclusao
    {
        public int Id { get; set; }
        public string Numero { get; set; }
        public int ObraId { get; set; }
        public string Obra { get; set; }
        public int ProprietarioId { get; set; }
        public string Proprietario { get; set; }
        public int UsuarioId { get; set; }
        public string Usuario { get; set; }
        public DateTime DataConclusao { get; set; }
        public string Status { get; set; }
        public string DocumentoReferencia { get; set; }
        public string Declaracao { get; set; }
        public string ObservacoesFinais { get; set; }
        public string PdfFinal { get; set; }
    }
}
