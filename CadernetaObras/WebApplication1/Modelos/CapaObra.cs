using System;

namespace WebApplication1.Modelos
{
    public class CapaObra
    {
        public int ObraId { get; set; }
        public string NumeroCaderneta { get; set; }
        public string NomeObra { get; set; }
        public int? ProfissionalId { get; set; }
        public string ProfissionalNome { get; set; }
        public string TituloProfissional { get; set; }
        public string TipoRegistro { get; set; }
        public string NumeroRegistro { get; set; }
        public string ProfissionalCpf { get; set; }
        public string NumeroRT { get; set; }
        public string Empresa { get; set; }
        public string ProprietarioNome { get; set; }
        public string ProprietarioCpfCnpj { get; set; }
        public string ProprietarioTelefone { get; set; }
        public string LocalObra { get; set; }
        public string TipoEdificacao { get; set; }
        public string AtividadeTecnica { get; set; }
        public decimal AreaConstruir { get; set; }
        public decimal AreaAmpliar { get; set; }
        public decimal AreaRegularizar { get; set; }
        public decimal AreaReforma { get; set; }
        public decimal AreaTotal { get; set; }
        public decimal? ValorObra { get; set; }
        public DateTime? DataInicio { get; set; }
        public string StatusObra { get; set; }
    }
}
