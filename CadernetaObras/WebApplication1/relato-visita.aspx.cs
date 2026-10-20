using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Web;
using System.Web.UI.WebControls;
using WebApplication1.Dados;
using WebApplication1.Modelos;
using WebApplication1.Utilitarios;

namespace WebApplication1
{
    public partial class relato_visita : PaginaBase
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            try
            {
                DataTable obras = ListaDAO.Obras();
                PreencherCombo(ddlObra, obras, "ObraId", "Nome", "Selecione");
                PreencherCombo(ddlFiltroObra, obras, "ObraId", "Nome", "Todas");
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
                DataTable dados = RelatoVisitaDAO.Listar(txtPesquisa.Text, Texto.Inteiro(ddlFiltroObra.SelectedValue), ddlFiltroStatus.SelectedValue);
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
            ddlFiltroObra.SelectedIndex = 0;
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
            if (e.CommandName != "Ver" && e.CommandName != "Editar" && e.CommandName != "Imprimir" && e.CommandName != "Excluir") return;
            int id = Convert.ToInt32(e.CommandArgument);

            try
            {
                if (e.CommandName == "Editar")
                {
                    Editar(id);
                }
                else if (e.CommandName == "Excluir")
                {
                    Excluir(id);
                }
                else
                {
                    Visualizar(id);
                    if (e.CommandName == "Imprimir")
                        ClientScript.RegisterStartupScript(GetType(), "imprimir", "window.print();", true);
                }
            }
            catch (Exception ex)
            {
                MensagemErro(TextoErroBanco(ex));
            }
        }

        private void Visualizar(int id)
        {
            RelatoVisita r = RelatoVisitaDAO.Obter(id);
            if (r == null) { MensagemErro("Registro não encontrado."); return; }

            lblTituloView.Text = "Relato de visita " + r.Numero;
            vNumero.Text = r.Numero;
            vNumeroNaObra.Text = r.NumeroNaObra.ToString("000");
            vData.Text = Texto.FormatarData(r.DataVisita);
            vObra.Text = Texto.Html(r.Obra);
            vProprietario.Text = Texto.Html(r.Proprietario);
            vSituacao.Text = Texto.Html(r.SituacaoProjeto);
            vStatusObra.Text = Texto.Html(r.StatusObra);
            vParticipantes.Text = Texto.Html(r.Participantes);
            vRelato.Text = Texto.Html(r.Relato);
            vDecisoes.Text = Texto.Html(r.DecisoesOrientacoes);
            vStatus.Text = r.Status;
            vEtapas.Text = r.EtapasNomes.Count == 0 ? "Nenhuma etapa marcada" : Texto.Html(string.Join(", ", r.EtapasNomes));

            // assinaturas digitais: o responsável técnico é o cadastrado na obra
            CapaObra capa = ObraDAO.ObterCapa(r.ObraId);
            ucAssinaturas.Carregar("Visita", id, capa.ProfissionalNome, r.Proprietario);

            rptAnexosView.DataSource = RelatoVisitaDAO.ListarAnexos(id);
            rptAnexosView.DataBind();
            AbrirModal(pnlView);
        }

        private void Editar(int id)
        {
            RelatoVisita r = RelatoVisitaDAO.Obter(id);
            if (r == null) { MensagemErro("Registro não encontrado."); return; }

            LimparFormulario();
            hfId.Value = r.Id.ToString();
            lblTituloForm.Text = "Editar relato " + r.Numero;
            Selecionar(ddlObra, r.ObraId);
            txtData.Text = Texto.DataParaCampo(r.DataVisita);
            txtParticipantes.Text = r.Participantes;
            Selecionar(ddlSituacao, r.SituacaoProjeto);
            Selecionar(ddlStatusObra, r.StatusObra);
            txtRelato.Text = r.Relato;
            txtDecisoes.Text = r.DecisoesOrientacoes;
            Selecionar(ddlStatus, r.Status);

            foreach (RepeaterItem linha in rptEtapas.Items)
            {
                HiddenField etapaId = (HiddenField)linha.FindControl("hfEtapaId");
                CheckBox marcada = (CheckBox)linha.FindControl("chkEtapa");
                marcada.Checked = r.EtapasIds.Contains(int.Parse(etapaId.Value));
            }

            CarregarAnexosForm(id);
            AbrirModal(pnlForm);
        }

        private void Excluir(int id)
        {
            if (!PodeEditar) { MensagemErro("Seu perfil não tem permissão para excluir."); return; }
            if (AssinaturaDAO.Existe("Visita", id))
            {
                MensagemErro("Este relato já tem assinatura digital e não pode ser excluído. O administrador pode remover as assinaturas primeiro.");
                return;
            }

            List<Anexo> anexos = RelatoVisitaDAO.ObterAnexosDoRelato(id);
            RelatoVisitaDAO.Excluir(id);
            foreach (Anexo a in anexos)
                Arquivos.Apagar(a.CaminhoArquivo);
            Arquivos.ApagarPasta("~/App_Data/Uploads/relatos/" + id);

            Mensagem("Relato excluído com sucesso.");
            CarregarGrid();
        }

        protected void btnNovo_Click(object sender, EventArgs e)
        {
            LimparFormulario();
            lblTituloForm.Text = "Novo relato de visita";
            txtData.Text = Texto.DataParaCampo(DateTime.Today);
            AbrirModal(pnlForm);
        }

        private void LimparFormulario()
        {
            hfId.Value = "";
            lblErroForm.Visible = false;
            ddlObra.SelectedIndex = 0;
            txtData.Text = "";
            txtParticipantes.Text = "";
            ddlSituacao.SelectedIndex = 0;
            ddlStatusObra.SelectedIndex = 0;
            txtRelato.Text = "";
            txtDecisoes.Text = "";
            ddlStatus.SelectedIndex = 0;

            rptEtapas.DataSource = ListaDAO.EtapasObra();
            rptEtapas.DataBind();

            txtDescricaoAnexo.Text = "";
            rptAnexosForm.DataSource = null;
            rptAnexosForm.DataBind();
        }

        private void CarregarAnexosForm(int relatoId)
        {
            rptAnexosForm.DataSource = RelatoVisitaDAO.ListarAnexos(relatoId);
            rptAnexosForm.DataBind();
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            if (!PodeEditar) { ErroForm(lblErroForm, "Seu perfil não tem permissão para alterar dados."); return; }

            DateTime? data = Texto.ParseData(txtData.Text);
            if (ddlObra.SelectedValue == "") { ErroForm(lblErroForm, "Selecione a obra."); return; }
            if (!data.HasValue) { ErroForm(lblErroForm, "Informe a data da visita."); return; }
            if (txtRelato.Text.Trim() == "") { ErroForm(lblErroForm, "Escreva o relato da visita."); return; }

            List<HttpPostedFile> anexosEnviados = Arquivos.Enviados(Request, fuAnexos.UniqueID);
            string erroAnexo = Arquivos.Validar(anexosEnviados);
            if (erroAnexo != "") { ErroForm(lblErroForm, erroAnexo); return; }

            RelatoVisita r = new RelatoVisita();
            r.Id = hfId.Value == "" ? 0 : int.Parse(hfId.Value);
            r.ObraId = int.Parse(ddlObra.SelectedValue);
            r.UsuarioId = UsuarioLogadoId;
            r.DataVisita = data.Value;
            r.Participantes = txtParticipantes.Text.Trim();
            r.SituacaoProjeto = ddlSituacao.SelectedValue;
            r.StatusObra = ddlStatusObra.SelectedValue;
            r.Relato = txtRelato.Text.Trim();
            r.DecisoesOrientacoes = txtDecisoes.Text.Trim();
            r.Status = ddlStatus.SelectedValue;

            foreach (RepeaterItem linha in rptEtapas.Items)
            {
                CheckBox marcada = (CheckBox)linha.FindControl("chkEtapa");
                HiddenField etapaId = (HiddenField)linha.FindControl("hfEtapaId");
                if (marcada.Checked) r.EtapasIds.Add(int.Parse(etapaId.Value));
            }

            try
            {
                int relatoId = RelatoVisitaDAO.Salvar(r);
                hfId.Value = relatoId.ToString();
                SalvarAnexos(relatoId, anexosEnviados);
                FecharModal(pnlForm);
                Mensagem("Relato de visita salvo com sucesso.");
                CarregarGrid();
            }
            catch (Exception ex)
            {
                ErroForm(lblErroForm, TextoErroBanco(ex));
            }
        }

        private void SalvarAnexos(int relatoId, List<HttpPostedFile> arquivos)
        {
            foreach (HttpPostedFile arquivo in arquivos)
            {
                Anexo a = new Anexo();
                a.RelatoVisitaId = relatoId;
                a.NomeOriginal = Path.GetFileName(arquivo.FileName);
                a.Descricao = txtDescricaoAnexo.Text.Trim();
                a.CaminhoArquivo = Arquivos.Salvar(arquivo, "~/App_Data/Uploads/relatos/" + relatoId);
                a.ContentType = arquivo.ContentType;
                a.TamanhoBytes = arquivo.ContentLength;
                try
                {
                    RelatoVisitaDAO.InserirAnexo(a);
                }
                catch
                {
                    Arquivos.Apagar(a.CaminhoArquivo);
                    throw;
                }
            }
        }

        protected void rptAnexos_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int anexoId = Convert.ToInt32(e.CommandArgument);
            try
            {
                Anexo a = RelatoVisitaDAO.ObterAnexo(anexoId);
                if (a == null) { MensagemErro("Anexo não encontrado."); return; }

                if (e.CommandName == "Baixar")
                {
                    if (!Arquivos.Baixar(a.CaminhoArquivo, a.NomeOriginal, a.ContentType))
                        MensagemErro("O arquivo não foi encontrado no servidor.");
                }
                else if (e.CommandName == "Remover")
                {
                    if (!PodeEditar) { ErroForm(lblErroForm, "Seu perfil não tem permissão para alterar dados."); return; }
                    RelatoVisitaDAO.ExcluirAnexo(anexoId);
                    Arquivos.Apagar(a.CaminhoArquivo);
                    CarregarAnexosForm(a.RelatoVisitaId);
                }
            }
            catch (Exception ex)
            {
                MensagemErro(TextoErroBanco(ex));
            }
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
