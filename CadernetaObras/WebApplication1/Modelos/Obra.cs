using System;

namespace WebApplication1.Modelos
{
    public class Obra
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int ProprietarioId { get; set; }
        public string Proprietario { get; set; }
        public int TipoObraId { get; set; }
        public string TipoObra { get; set; }
        public int? AtividadeTecnicaId { get; set; }
        public string AtividadeTecnica { get; set; }
        public int? ProfissionalId { get; set; }
        public string Profissional { get; set; }
        public string NumeroRT { get; set; }
        public string Empresa { get; set; }
        public string NumeroCaderneta { get; set; }
        public decimal? ValorObra { get; set; }
        public DateTime? DataInicio { get; set; }
        public DateTime? PrevisaoTermino { get; set; }
        public string EnderecoObra { get; set; }
        public string Status { get; set; }
        public decimal? AreaConstruir { get; set; }
        public decimal? AreaAmpliar { get; set; }
        public decimal? AreaRegularizar { get; set; }
        public decimal? AreaReforma { get; set; }
        public decimal AreaTotal { get; set; }
        public string Observacoes { get; set; }
        public DateTime? AtualizadoEm { get; set; }
    }
}
