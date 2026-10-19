using System;
using System.Configuration;
using System.Data;
using System.IO;
using System.Web;
using System.Web.UI.WebControls;
using WebApplication1.Dados;
using WebApplication1.Modelos;
using WebApplication1.Utilitarios;

namespace WebApplication1
{
    public partial class termo_conclusao : PaginaBase
    {
        // Texto do Manual: declaração de que a obra foi finalizada conforme o projeto aprovado e as normas técnicas
        private const string DeclaracaoPadrao =
            "Nós, abaixo assinados, proprietário e profissional responsável, pela execução da obra acima apontada, " +
            "declaramos que a obra foi finalizada conforme o projeto aprovado e as normas técnicas vigentes.";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            try
            {
                PreencherCombo(ddlObra, ListaDAO.Obras(), "ObraId", "Nome", "Selecione");
                PreencherCombo(ddlProprietario, ListaDAO.Proprietarios(false, 0), "ProprietarioId", "NomeRazaoSocial", "Selecione");
                PreencherCombo(ddlAno, ListaDAO.AnosTermos(), "Ano", "Ano", "Todos");
            }
            catch (Exception ex)
            {
                MensagemErro(TextoErroBanco(ex));
            }
            CarregarGrid();
        }

        private void CarregarGrid()
        {
            try
            {
                DataTable dados = TermoConclusaoDAO.Listar(txtPesquisa.Text, ddlFiltroStatus.SelectedValue, Texto.Inteiro(ddlAno.SelectedValue));
                lblTotal.Text = dados.Rows.Count + " registro(s)";
                Vincular(gvDados, dados);
            }
            catch (Exception ex)
            {
                MensagemErro(TextoErroBanco(ex));
            }
        }

        protected void btnPesquisar_Click(object sender, EventArgs e)
        {
            gvDados.PageIndex = 0;
            CarregarGrid();
        }

        protected void btnLimpar_Click(object sender, EventArgs e)
        {
            txtPesquisa.Text = "";
            ddlFiltroStatus.SelectedIndex = 0;
            ddlAno.SelectedIndex = 0;
            gvDados.PageIndex = 0;
            CarregarGrid();
        }

        protected void gvDados_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvDados.PageIndex = e.NewPageIndex;
            CarregarGrid();
        }

        protected void gvDados_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName != "Ver" && e.CommandName != "Editar" && e.CommandName != "Imprimir" && e.CommandName != "PDF") return;
            int id = Convert.ToInt32(e.CommandArgument);

            try
            {
                if (e.CommandName == "Editar")
                {
                    Editar(id);
                }
                else if (e.CommandName == "PDF")
                {
                    GerarPdf(id);
                }
                else
                {
                    Visualizar(id);
                    // "Imprimir" abre a visualização e chama a impressão do navegador
                    if (e.CommandName == "Imprimir")
                        ClientScript.RegisterStartupScript(GetType(), "imprimir", "window.print();", true);
                }
            }
            catch (Exception ex)
            {
                MensagemErro(TextoErroBanco(ex));
            }
        }

        // ---------- Visualização ----------
        private void Visualizar(int id)
        {
            TermoConclusao t = TermoConclusaoDAO.Obter(id);
            if (t == null) { MensagemErro("Registro não encontrado."); return; }
            CapaObra c = ObraDAO.ObterCapa(t.ObraId);

            lblTituloView.Text = "Termo de conclusão " + t.Numero;
            hfIdView.Value = t.Id.ToString();
            vNumero.Text = t.Numero;
            vData.Text = Texto.FormatarData(t.DataConclusao);
            vProfissional.Text = Texto.Html(c.ProfissionalNome);
            vRegistro.Text = Texto.Html((c.TipoRegistro + " " + c.NumeroRegistro).Trim());
            vEmpresa.Text = Texto.Html(c.Empresa);
            vObra.Text = Texto.Html(t.Obra);
            vProprietario.Text = Texto.Html(t.Proprietario);
            vDocProp.Text = Texto.FormatarDocumento(c.ProprietarioCpfCnpj);
            vTelefone.Text = Texto.FormatarTelefone(c.ProprietarioTelefone);
            vLocal.Text = Texto.Html(c.LocalObra);
            vStatus.Text = t.Status;
            vDocumento.Text = Texto.Html(t.DocumentoReferencia);
            vDeclaracao.Text = Texto.Html(t.Declaracao + "\n\n" + DocumentosPdf.TextoSancoes);
            vObservacoes.Text = Texto.Html(t.ObservacoesFinais);

            ucAssinaturas.Carregar("Termo", id, c.ProfissionalNome, t.Proprietario);
            AbrirModal(pnlView);
        }

        // ---------- Edição ----------
        private void Editar(int id)
        {
            TermoConclusao t = TermoConclusaoDAO.Obter(id);
            if (t == null) { MensagemErro("Registro não encontrado."); return; }

            LimparFormulario();
            hfId.Value = t.Id.ToString();
            lblTituloForm.Text = "Editar termo " + t.Numero;
            Selecionar(ddlObra, t.ObraId);
            Selecionar(ddlProprietario, t.ProprietarioId);
            txtData.Text = Texto.DataParaCampo(t.DataConclusao);
            Selecionar(ddlStatus, t.Status);
            txtDocumento.Text = t.DocumentoReferencia;
            txtDeclaracao.Text = t.Declaracao;
            txtObservacoes.Text = t.ObservacoesFinais;
            MostrarDadosObra(t.ObraId);
            AbrirModal(pnlForm);
        }

        protected void btnNovo_Click(object sender, EventArgs e)
        {
            LimparFormulario();
            lblTituloForm.Text = "Novo termo de conclusão";
            txtData.Text = Texto.DataParaCampo(DateTime.Today);
            txtDeclaracao.Text = DeclaracaoPadrao;
            AbrirModal(pnlForm);
        }

        private void LimparFormulario()
        {
            hfId.Value = "";
            lblErroForm.Visible = false;
            ddlObra.SelectedIndex = 0;
            ddlProprietario.SelectedIndex = 0;
            txtData.Text = "";
            ddlStatus.SelectedIndex = 0;
            txtDocumento.Text = "";
            txtDeclaracao.Text = "";
            txtObservacoes.Text = "";
            MostrarDadosObra(0);
        }

        // Ao escolher a obra, o termo já traz proprietário, profissional, registro, empresa, telefone e local
        protected void ddlObra_SelectedIndexChanged(object sender, EventArgs e)
        {
            int? obraId = Texto.Inteiro(ddlObra.SelectedValue);
            if (!obraId.HasValue) { MostrarDadosObra(0); return; }
            try
            {
                Selecionar(ddlProprietario, ObraDAO.ObterProprietarioId(obraId.Value));
                MostrarDadosObra(obraId.Value);
                if (txtDeclaracao.Text.Trim() == "") txtDeclaracao.Text = DeclaracaoPadrao;
            }
            catch (Exception ex)
            {
                ErroForm(lblErroForm, TextoErroBanco(ex));
            }
        }

        private void MostrarDadosObra(int obraId)
        {
            tProfissional.Text = "";
            tRegistro.Text = "";
            tEmpresa.Text = "";
            tDocProp.Text = "";
            tTelefone.Text = "";
            tLocal.Text = "";
            tAviso.Text = "";
            if (obraId == 0) return;

            CapaObra c = ObraDAO.ObterCapa(obraId);
            if (c == null) return;
            tProfissional.Text = Texto.Html(c.ProfissionalNome);
            tRegistro.Text = Texto.Html((c.TipoRegistro + " " + c.NumeroRegistro).Trim());
            tEmpresa.Text = Texto.Html(c.Empresa);
            tDocProp.Text = Texto.FormatarDocumento(c.ProprietarioCpfCnpj);
            tTelefone.Text = Texto.FormatarTelefone(c.ProprietarioTelefone);
            tLocal.Text = Texto.Html(c.LocalObra);
            if (!c.ProfissionalId.HasValue)
                tAviso.Text = "Esta obra ainda não tem responsável técnico: cadastre-o na tela Obras antes de salvar o termo.";
        }

        // ---------- Salvar ----------
        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            if (!PodeEditar) { ErroForm(lblErroForm, "Seu perfil não tem permissão para alterar dados."); return; }

            DateTime? data = Texto.ParseData(txtData.Text);

            if (ddlObra.SelectedValue == "") { ErroForm(lblErroForm, "Selecione a obra."); return; }
            if (!data.HasValue) { ErroForm(lblErroForm, "Informe a data de conclusão."); return; }
            if (txtDeclaracao.Text.Trim() == "") { ErroForm(lblErroForm, "Informe a declaração de conclusão."); return; }

            try
            {
                int obraId = int.Parse(ddlObra.SelectedValue);
                CapaObra capa = ObraDAO.ObterCapa(obraId);
                if (capa == null) { ErroForm(lblErroForm, "Obra não encontrada."); return; }
                if (!capa.ProfissionalId.HasValue)
                {
                    ErroForm(lblErroForm, "A obra selecionada não tem responsável técnico. Cadastre-o na tela Obras.");
                    return;
                }
                if (capa.DataInicio.HasValue && data.Value < capa.DataInicio.Value)
                {
                    ErroForm(lblErroForm, "A data de conclusão não pode ser anterior ao início da obra.");
                    return;
                }

                TermoConclusao t = new TermoConclusao();
                t.Id = hfId.Value == "" ? 0 : int.Parse(hfId.Value);
                t.ObraId = obraId;
                t.ProprietarioId = ObraDAO.ObterProprietarioId(obraId).Value;   // sempre o proprietário da obra
                t.UsuarioId = UsuarioLogadoId;
                t.DataConclusao = data.Value;
                t.Status = ddlStatus.SelectedValue;
                t.DocumentoReferencia = txtDocumento.Text.Trim();
                t.Declaracao = txtDeclaracao.Text.Trim();
                t.ObservacoesFinais = txtObservacoes.Text.Trim();

                int termoId = TermoConclusaoDAO.Salvar(t);
                hfId.Value = termoId.ToString();

                // termo concluído = obra concluída
                string aviso = "";
                if (t.Status == "Concluído")
                {
                    ObraDAO.AtualizarStatus(obraId, "Concluída");
                    aviso = " A obra foi marcada como Concluída.";
                }

                FecharModal(pnlForm);
                Mensagem("Termo de conclusão salvo com sucesso." + aviso);

                // o filtro de anos pode ter ganhado um ano novo
                string anoSelecionado = ddlAno.SelectedValue;
                PreencherCombo(ddlAno, ListaDAO.AnosTermos(), "Ano", "Ano", "Todos");
                Selecionar(ddlAno, anoSelecionado);
                CarregarGrid();
            }
            catch (Exception ex)
            {
                ErroForm(lblErroForm, TextoErroBanco(ex));
            }
        }

        // ---------- PDF único: capa + primeira página + termo (Manual, seção 4.2.6) ----------
        protected void btnGerarPdf_Click(object sender, EventArgs e)
        {
            int id;
            if (!int.TryParse(hfIdView.Value, out id)) return;
            try
            {
                GerarPdf(id);
            }
            catch (Exception ex)
            {
                MensagemErro(TextoErroBanco(ex));
            }
        }

        private void GerarPdf(int termoId)
        {
            TermoConclusao t = TermoConclusaoDAO.Obter(termoId);
            if (t == null) { MensagemErro("Registro não encontrado."); return; }

            CapaObra capa = ObraDAO.ObterCapa(t.ObraId);
            if (capa == null || !capa.ProfissionalId.HasValue)
            {
                MensagemErro("Cadastre o responsável técnico na obra antes de gerar o PDF.");
                return;
            }

            string cidade = ConfigurationManager.AppSettings["CidadeDocumentos"];
            byte[] pdf = DocumentosPdf.GerarCaderneta(capa, t,
                AssinaturaDAO.Listar("Obra", t.ObraId), AssinaturaDAO.Listar("Termo", termoId), cidade);

            // guarda uma cópia em App_Data/Pdfs e o caminho no termo (campo PdfFinal do Manual)
            string relativo = "~/App_Data/Pdfs/termo-" + termoId + ".pdf";
            string fisico = Server.MapPath(relativo);
            Directory.CreateDirectory(Path.GetDirectoryName(fisico));
            File.WriteAllBytes(fisico, pdf);
            TermoConclusaoDAO.AtualizarPdf(termoId, relativo);

            Response.Clear();
            Response.ContentType = "application/pdf";
            Response.AddHeader("Content-Disposition", "attachment; filename=\"caderneta-" + t.Numero + ".pdf\"");
            Response.BinaryWrite(pdf);
            Response.Flush();
            Response.SuppressContent = true;
            Context.ApplicationInstance.CompleteRequest();
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            FecharModal(pnlForm);
        }

        protected void btnFecharView_Click(object sender, EventArgs e)
        {
            FecharModal(pnlView);
        }
    }
}
