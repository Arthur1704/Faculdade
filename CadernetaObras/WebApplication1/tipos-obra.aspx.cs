using System;
using System.Data;
using System.Web.UI.WebControls;
using WebApplication1.Dados;
using WebApplication1.Modelos;
using WebApplication1.Utilitarios;

namespace WebApplication1
{
    public partial class tipos_obra : PaginaBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) CarregarGrid();
        }

        private void CarregarGrid()
        {
            try
            {
                DataTable dados = TipoObraDAO.Listar(txtPesquisa.Text, ddlFiltroStatus.SelectedValue, ddlOrdem.SelectedValue);
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
            ddlOrdem.SelectedIndex = 0;
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
            if (e.CommandName != "Ver" && e.CommandName != "Editar" && e.CommandName != "Excluir") return;
            int id = Convert.ToInt32(e.CommandArgument);

            try
            {
                if (e.CommandName == "Ver") Visualizar(id);
                else if (e.CommandName == "Editar") Editar(id);
                else Excluir(id);
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

        private void Visualizar(int id)
        {
            TipoObra t = TipoObraDAO.Obter(id);
            if (t == null) { MensagemErro("Registro não encontrado."); return; }

            lblTituloView.Text = "Tipo de obra";
            vDescricao.Text = Texto.Html(t.Descricao);
            vStatus.Text = t.Status;
            vAtualizacao.Text = Texto.FormatarData(t.AtualizadoEm);
            vObservacoes.Text = Texto.Html(t.Observacoes);
            AbrirModal(pnlView);
        }

        private void Editar(int id)
        {
            TipoObra t = TipoObraDAO.Obter(id);
            if (t == null) { MensagemErro("Registro não encontrado."); return; }

            LimparFormulario();
            hfId.Value = t.Id.ToString();
            lblTituloForm.Text = "Editar tipo de obra";
            txtDescricao.Text = t.Descricao;
            Selecionar(ddlStatus, t.Status);
            txtObservacoes.Text = t.Observacoes;
            AbrirModal(pnlForm);
        }

        private void Excluir(int id)
        {
            if (!PodeEditar) { MensagemErro("Seu perfil não tem permissão para excluir."); return; }
            TipoObraDAO.Excluir(id);
            Mensagem("Tipo de obra excluído com sucesso.");
            CarregarGrid();
        }

        protected void btnNovo_Click(object sender, EventArgs e)
        {
            LimparFormulario();
            lblTituloForm.Text = "Novo tipo de obra";
            AbrirModal(pnlForm);
        }

        private void LimparFormulario()
        {
            hfId.Value = "";
            lblErroForm.Visible = false;
            txtDescricao.Text = "";
            ddlStatus.SelectedIndex = 0;
            txtObservacoes.Text = "";
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            if (!PodeEditar) { ErroForm(lblErroForm, "Seu perfil não tem permissão para alterar dados."); return; }
            if (txtDescricao.Text.Trim() == "") { ErroForm(lblErroForm, "Informe a descrição do tipo de obra."); return; }

            TipoObra t = new TipoObra();
            t.Id = hfId.Value == "" ? 0 : int.Parse(hfId.Value);
            t.Descricao = txtDescricao.Text.Trim();
            t.Status = ddlStatus.SelectedValue;
            t.Observacoes = txtObservacoes.Text.Trim();

            try
            {
                TipoObraDAO.Salvar(t);
                FecharModal(pnlForm);
                Mensagem("Tipo de obra salvo com sucesso.");
                CarregarGrid();
            }
            catch (Exception ex)
            {
                ErroForm(lblErroForm, TextoErroBanco(ex));
            }
        }
    }
}
