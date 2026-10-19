using System;
using System.Data;
using System.Web.UI.WebControls;
using WebApplication1.Dados;
using WebApplication1.Modelos;
using WebApplication1.Utilitarios;

namespace WebApplication1
{
    public partial class servicos : PaginaBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            try
            {
                PreencherCombo(ddlUnidade, ListaDAO.UnidadesMedida(), "UnidadeMedidaId", "Sigla", "Selecione");
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
                DataTable dados = ServicoDAO.Listar(txtPesquisa.Text, ddlFiltroStatus.SelectedValue, ddlOrdem.SelectedValue);
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
            Servico s = ServicoDAO.Obter(id);
            if (s == null) { MensagemErro("Registro não encontrado."); return; }

            lblTituloView.Text = "Serviço";
            vNome.Text = Texto.Html(s.Nome);
            vUnidade.Text = Texto.Html(s.Unidade);
            vReferencia.Text = Texto.Html(s.Referencia);
            vStatus.Text = s.Status;
            vAtualizacao.Text = Texto.FormatarData(s.AtualizadoEm);
            vDescricao.Text = Texto.Html(s.Descricao);
            AbrirModal(pnlView);
        }

        private void Editar(int id)
        {
            Servico s = ServicoDAO.Obter(id);
            if (s == null) { MensagemErro("Registro não encontrado."); return; }

            LimparFormulario();
            hfId.Value = s.Id.ToString();
            lblTituloForm.Text = "Editar serviço";
            txtNome.Text = s.Nome;
            Selecionar(ddlUnidade, s.UnidadeMedidaId);
            txtReferencia.Text = s.Referencia;
            Selecionar(ddlStatus, s.Status);
            txtDescricao.Text = s.Descricao;
            AbrirModal(pnlForm);
        }

        private void Excluir(int id)
        {
            if (!PodeEditar) { MensagemErro("Seu perfil não tem permissão para excluir."); return; }
            ServicoDAO.Excluir(id);
            Mensagem("Serviço excluído com sucesso.");
            CarregarGrid();
        }

        protected void btnNovo_Click(object sender, EventArgs e)
        {
            LimparFormulario();
            lblTituloForm.Text = "Novo serviço";
            AbrirModal(pnlForm);
        }

        private void LimparFormulario()
        {
            hfId.Value = "";
            lblErroForm.Visible = false;
            txtNome.Text = "";
            ddlUnidade.SelectedIndex = 0;
            txtReferencia.Text = "";
            ddlStatus.SelectedIndex = 0;
            txtDescricao.Text = "";
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            if (!PodeEditar) { ErroForm(lblErroForm, "Seu perfil não tem permissão para alterar dados."); return; }
            if (txtNome.Text.Trim() == "") { ErroForm(lblErroForm, "Informe o nome do serviço."); return; }

            Servico s = new Servico();
            s.Id = hfId.Value == "" ? 0 : int.Parse(hfId.Value);
            s.Nome = txtNome.Text.Trim();
            s.UnidadeMedidaId = Texto.Inteiro(ddlUnidade.SelectedValue);
            s.Referencia = txtReferencia.Text.Trim();
            s.Status = ddlStatus.SelectedValue;
            s.Descricao = txtDescricao.Text.Trim();

            try
            {
                ServicoDAO.Salvar(s);
                FecharModal(pnlForm);
                Mensagem("Serviço salvo com sucesso.");
                CarregarGrid();
            }
            catch (Exception ex)
            {
                ErroForm(lblErroForm, TextoErroBanco(ex));
            }
        }
    }
}
