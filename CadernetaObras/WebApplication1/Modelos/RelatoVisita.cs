using System;
using System.Collections.Generic;

namespace WebApplication1.Modelos
{
    public class RelatoVisita
    {
        public int Id { get; set; }
        public string Numero { get; set; }
        public int NumeroNaObra { get; set; }
        public int ObraId { get; set; }
        public string Obra { get; set; }
        public int UsuarioId { get; set; }
        public string Usuario { get; set; }
        public DateTime DataVisita { get; set; }
        public string Participantes { get; set; }
        public string SituacaoProjeto { get; set; }
        public string StatusObra { get; set; }
        public string Relato { get; set; }
        public string DecisoesOrientacoes { get; set; }
        public string Status { get; set; }
        public string Proprietario { get; set; }

        public List<int> EtapasIds { get; set; }
        public List<string> EtapasNomes { get; set; }

        public RelatoVisita()
        {
            EtapasIds = new List<int>();
            EtapasNomes = new List<string>();
        }
    }
}
