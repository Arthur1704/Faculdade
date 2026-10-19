using System;
using System.Collections.Generic;
using System.Data;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.Dados;
using WebApplication1.Modelos;
using WebApplication1.Utilitarios;

namespace WebApplication1
{
    // Controle reutilizado na Obra (capa), no Relato de visita e no Termo de conclusão.
    public partial class Assinaturas : System.Web.UI.UserControl
    {
        private const int TamanhoMaximoImagem = 400000;   // caracteres do data URL

        // Guardados no ViewState para os botões "Assinar" funcionarem nas próximas requisições
        private string Tipo
        {
            get { return (string)ViewState["tipo"]; }
            set { ViewState["tipo"] = value; }
        }

        private int DocumentoId
        {
            get { return ViewState["docId"] == null ? 0 : (int)ViewState["docId"]; }
            set { ViewState["docId"] = value; }
        }

        private string NomeRT
        {
            get { return (string)ViewState["nomeRT"]; }
            set { ViewState["nomeRT"] = value; }
        }

        private string NomeProprietario
        {
            get { return (string)ViewState["nomeProp"]; }
            set { ViewState["nomeProp"] = value; }
        }

        // tipo: "Obra", "Visita" ou "Termo"
        public void Carregar(string tipo, int documentoId, string nomeResponsavelTecnico, string nomeProprietario)
        {
            Tipo = tipo;
            DocumentoId = documentoId;
            NomeRT = nomeResponsavelTecnico;
            NomeProprietario = nomeProprietario;
            lblErroAssinatura.Visible = false;
            Montar();
        }

        private string PerfilLogado
        {
            get { return Convert.ToString(Session["UsuarioPerfil"]); }
        }

        private void Montar()
        {
            List<Assinatura> gravadas = AssinaturaDAO.Listar(Tipo, DocumentoId);
            string hashAtual = AssinaturaDAO.CalcularHash(Tipo, DocumentoId);
            bool podeAssinar = PerfilLogado != "Visualizador";
            bool administrador = PerfilLogado == "Administrador";

            DataTable dt = new DataTable();
            dt.Columns.Add("Papel", typeof(string));
            dt.Columns.Add("Titulo", typeof(string));
            dt.Columns.Add("Nome", typeof(string));
            dt.Columns.Add("Assinado", typeof(bool));
            dt.Columns.Add("Valido", typeof(bool));
            dt.Columns.Add("MostrarPad", typeof(bool));
            dt.Columns.Add("PodeRemover", typeof(bool));
            dt.Columns.Add("Imagem", typeof(string));
            dt.Columns.Add("DataTexto", typeof(string));
            dt.Columns.Add("Ip", typeof(string));

            AdicionarPapel(dt, gravadas, "RT", "Assinatura do Responsável Técnico", NomeRT, hashAtual, podeAssinar, administrador);
            AdicionarPapel(dt, gravadas, "PROPRIETARIO", "Assinatura do Proprietário", NomeProprietario, hashAtual, podeAssinar, administrador);

            rptPapeis.DataSource = dt;
            rptPapeis.DataBind();
        }

        private void AdicionarPapel(DataTable dt, List<Assinatura> gravadas, string papel, string titulo, string nome,
                                    string hashAtual, bool podeAssinar, bool administrador)
        {
            Assinatura a = null;
            foreach (Assinatura g in gravadas) if (g.Papel == papel) a = g;

            bool assinado = (a != null);
            bool valido = assinado && a.Hash == hashAtual;

            DataRow r = dt.NewRow();
            r["Papel"] = papel;
            r["Titulo"] = titulo;
            r["Nome"] = Texto.Html(nome);
            r["Assinado"] = assinado;
            r["Valido"] = valido;
            // mostra o quadro de desenho se ainda não assinou (ou se o documento mudou depois da assinatura)
            r["MostrarPad"] = podeAssinar && (!assinado || !valido);
            r["PodeRemover"] = assinado && administrador;
            r["Imagem"] = assinado ? a.Imagem : "";
            r["DataTexto"] = assinado ? a.Data.ToString("dd/MM/yyyy HH:mm") : "";
            r["Ip"] = assinado ? Texto.Html(a.Ip) : "";
            dt.Rows.Add(r);
        }

        protected void rptPapeis_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string papel = Convert.ToString(e.CommandArgument);
            if (papel != "RT" && papel != "PROPRIETARIO") return;

            try
            {
                if (e.CommandName == "Assinar")
                {
                    if (PerfilLogado == "Visualizador") { Erro("Seu perfil não pode assinar documentos."); return; }

                    string imagem = hfImagem.Value;
                    hfImagem.Value = "";
                    if (!ImagemValida(imagem)) { Erro("Desenhe a assinatura no quadro antes de clicar em Assinar."); Montar(); return; }

                    Assinatura a = new Assinatura();
                    a.Papel = papel;
                    a.NomeAssinante = papel == "RT" ? NomeRT : NomeProprietario;
                    if (string.IsNullOrWhiteSpace(a.NomeAssinante)) { Erro("Este documento ainda não tem o nome do assinante (cadastre o responsável técnico na obra)."); Montar(); return; }
                    a.UsuarioId = (int)Session["UsuarioId"];
                    a.Imagem = imagem;
                    a.Ip = Request.UserHostAddress;
                    a.Hash = AssinaturaDAO.CalcularHash(Tipo, DocumentoId);
                    AssinaturaDAO.Salvar(Tipo, DocumentoId, a);
                }
                else if (e.CommandName == "Remover")
                {
                    if (PerfilLogado != "Administrador") { Erro("Só o administrador pode remover assinaturas."); return; }
                    AssinaturaDAO.Remover(Tipo, DocumentoId, papel);
                }
                lblErroAssinatura.Visible = false;
                Montar();
            }
            catch (Exception ex)
            {
                Registro.Erro(ex);
                Erro("Não foi possível registrar a assinatura. Tente novamente.");
            }
        }

        // O valor vem do navegador, então confere o formato antes de gravar ou exibir
        private bool ImagemValida(string imagem)
        {
            if (string.IsNullOrEmpty(imagem) || imagem.Length > TamanhoMaximoImagem) return false;
            if (!Regex.IsMatch(imagem, @"^data:image/jpeg;base64,[A-Za-z0-9+/]+={0,2}$")) return false;
            try
            {
                byte[] bytes = Convert.FromBase64String(imagem.Substring(imagem.IndexOf(',') + 1));
                return bytes.Length > 4 && bytes[0] == 0xFF && bytes[1] == 0xD8;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        private void Erro(string texto)
        {
            lblErroAssinatura.Text = HttpUtility.HtmlEncode(texto);
            lblErroAssinatura.Visible = true;
        }
    }
}
