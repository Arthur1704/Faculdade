using System;
using System.Data;
using System.Web.UI.WebControls;
using WebApplication1.Dados;
using WebApplication1.Modelos;
using WebApplication1.Utilitarios;

namespace WebApplication1
{
    public partial class recibos : PaginaBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            try
            {
                // Proprietários: todos (um recibo antigo pode ser de proprietário hoje inativo)
                PreencherCombo(ddlObra, ListaDAO.Obras(), "ObraId", "Nome", "Selecione");
                PreencherCombo(ddlProprietario, ListaDAO.Proprietarios(false, 0), "ProprietarioId", "NomeRazaoSocial", "Selecione");
                PreencherCombo(ddlForma, ListaDAO.FormasPagamento(), "FormaPagamentoId", "Descricao", "Selecione");
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
                DataTable dados = ReciboDAO.Listar(txtPesquisa.Text, ddlFiltroStatus.SelectedValue, ddlPeriodo.SelectedValue);
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
            ddlPeriodo.SelectedIndex = 0;
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
            if (e.CommandName != "Ver" && e.CommandName != "Editar" && e.CommandName != "Imprimir") return;
            int id = Convert.ToInt32(e.CommandArgument);

            try
            {
                if (e.CommandName == "Editar")
                {
                    Editar(id);
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

        private void Visualizar(int id)
        {
            Recibo r = ReciboDAO.Obter(id);
            if (r == null) { MensagemErro("Registro não encontrado."); return; }

            lblTituloView.Text = "Recibo " + r.Numero;
            vNumero.Text = r.Numero;
            vData.Text = Texto.FormatarData(r.DataEmissao);
            vObra.Text = Texto.Html(r.Obra);
            vProprietario.Text = Texto.Html(r.Proprietario);
            vValor.Text = Texto.FormatarMoeda(r.Valor);
            vForma.Text = Texto.Html(r.FormaPagamento);
            vStatus.Text = r.Status;
            vReferente.Text = Texto.Html(r.ReferenteA);
            vObservacoes.Text = Texto.Html(r.Observacoes);
            AbrirModal(pnlView);
        }

        private void Editar(int id)
        {
            Recibo r = ReciboDAO.Obter(id);
            if (r == null) { MensagemErro("Registro não encontrado."); return; }

            LimparFormulario();
            hfId.Value = r.Id.ToString();
            lblTituloForm.Text = "Editar recibo " + r.Numero;
            Selecionar(ddlObra, r.ObraId);
            Selecionar(ddlProprietario, r.ProprietarioId);
            txtData.Text = Texto.DataParaCampo(r.DataEmissao);
            txtValor.Text = r.Valor.ToString("N2");
            Selecionar(ddlForma, r.FormaPagamentoId);
            Selecionar(ddlStatus, r.Status);
            txtReferente.Text = r.ReferenteA;
            txtObservacoes.Text = r.Observacoes;
            AbrirModal(pnlForm);
        }

        protected void btnNovo_Click(object sender, EventArgs e)
        {
            LimparFormulario();
            lblTituloForm.Text = "Novo recibo";
            txtData.Text = Texto.DataParaCampo(DateTime.Today);
            AbrirModal(pnlForm);
        }

        private void LimparFormulario()
        {
            hfId.Value = "";
            lblErroForm.Visible = false;
            ddlObra.SelectedIndex = 0;
            ddlProprietario.SelectedIndex = 0;
            txtData.Text = "";
            txtValor.Text = "";
            ddlForma.SelectedIndex = 0;
            ddlStatus.SelectedIndex = 0;
            txtReferente.Text = "";
            txtObservacoes.Text = "";
        }

        // Ao escolher a obra, já sugere o proprietário dela
        protected void ddlObra_SelectedIndexChanged(object sender, EventArgs e)
        {
            int? obraId = Texto.Inteiro(ddlObra.SelectedValue);
            if (!obraId.HasValue) return;
            try
            {
                Selecionar(ddlProprietario, ObraDAO.ObterProprietarioId(obraId.Value));
            }
            catch (Exception ex)
            {
                ErroForm(lblErroForm, TextoErroBanco(ex));
            }
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            if (!PodeEditar) { ErroForm(lblErroForm, "Seu perfil não tem permissão para alterar dados."); return; }

            DateTime? data = Texto.ParseData(txtData.Text);
            decimal? valor = Texto.ParseDecimal(txtValor.Text);

            if (ddlObra.SelectedValue == "") { ErroForm(lblErroForm, "Selecione a obra."); return; }
            if (ddlProprietario.SelectedValue == "") { ErroForm(lblErroForm, "Selecione o proprietário."); return; }
            if (!data.HasValue) { ErroForm(lblErroForm, "Informe a data de emissão."); return; }
            if (!valor.HasValue || valor.Value <= 0) { ErroForm(lblErroForm, "Informe um valor maior que zero."); return; }

            Recibo r = new Recibo();
            r.Id = hfId.Value == "" ? 0 : int.Parse(hfId.Value);
            r.ObraId = int.Parse(ddlObra.SelectedValue);
            r.ProprietarioId = int.Parse(ddlProprietario.SelectedValue);
            r.DataEmissao = data.Value;
            r.Valor = valor.Value;
            r.FormaPagamentoId = Texto.Inteiro(ddlForma.SelectedValue);
            r.Status = ddlStatus.SelectedValue;
            r.ReferenteA = txtReferente.Text.Trim();
            r.Observacoes = txtObservacoes.Text.Trim();

            try
            {
                ReciboDAO.Salvar(r);
                FecharModal(pnlForm);
                Mensagem("Recibo salvo com sucesso.");
                CarregarGrid();
            }
            catch (Exception ex)
            {
                ErroForm(lblErroForm, TextoErroBanco(ex));
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
