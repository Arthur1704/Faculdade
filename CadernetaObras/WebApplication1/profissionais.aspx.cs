using System;
using System.Data;
using System.Web.UI.WebControls;
using WebApplication1.Dados;
using WebApplication1.Modelos;
using WebApplication1.Utilitarios;

namespace WebApplication1
{
    public partial class profissionais : PaginaBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            try
            {
                PreencherCombo(ddlTipo, ListaDAO.TiposProfissional(), "TipoProfissionalId", "Descricao", "Selecione");
                PreencherCombo(ddlTipoRegistro, ListaDAO.TiposRegistro(), "TipoRegistroId", "Sigla", "Nenhum");
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
                DataTable dados = ProfissionalDAO.Listar(txtPesquisa.Text, ddlFiltroStatus.SelectedValue, ddlOrdem.SelectedValue);
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

        private void Visualizar(int id)
        {
            Profissional p = ProfissionalDAO.Obter(id);
            if (p == null) { MensagemErro("Registro não encontrado."); return; }

            lblTituloView.Text = "Profissional";
            vNome.Text = Texto.Html(p.Nome);
            vCpf.Text = Texto.FormatarDocumento(p.Cpf);
            vTipo.Text = Texto.Html(p.TipoProfissional);
            vRegistro.Text = Texto.Html((p.TipoRegistro + " " + p.NumeroRegistro).Trim());
            vEmail.Text = Texto.Html(p.Email);
            vTelefone.Text = Texto.FormatarTelefone(p.Telefone);
            vCelular.Text = Texto.FormatarTelefone(p.Celular);
            vStatus.Text = p.Status;
            vAtualizacao.Text = Texto.FormatarData(p.AtualizadoEm);
            vObservacoes.Text = Texto.Html(p.Observacoes);
            AbrirModal(pnlView);
        }

        private void Editar(int id)
        {
            Profissional p = ProfissionalDAO.Obter(id);
            if (p == null) { MensagemErro("Registro não encontrado."); return; }

            LimparFormulario();
            hfId.Value = p.Id.ToString();
            lblTituloForm.Text = "Editar profissional";
            txtNome.Text = p.Nome;
            txtCpf.Text = Texto.FormatarDocumento(p.Cpf);
            Selecionar(ddlTipo, p.TipoProfissionalId);
            Selecionar(ddlTipoRegistro, p.TipoRegistroId);
            txtNumeroRegistro.Text = p.NumeroRegistro;
            txtEmail.Text = p.Email;
            txtTelefone.Text = Texto.FormatarTelefone(p.Telefone);
            txtCelular.Text = Texto.FormatarTelefone(p.Celular);
            Selecionar(ddlStatus, p.Status);
            txtObservacoes.Text = p.Observacoes;
            AbrirModal(pnlForm);
        }

        private void Excluir(int id)
        {
            if (!PodeEditar) { MensagemErro("Seu perfil não tem permissão para excluir."); return; }
            ProfissionalDAO.Excluir(id);
            Mensagem("Profissional excluído com sucesso.");
            CarregarGrid();
        }

        protected void btnNovo_Click(object sender, EventArgs e)
        {
            LimparFormulario();
            lblTituloForm.Text = "Novo profissional";
            AbrirModal(pnlForm);
        }

        private void LimparFormulario()
        {
            hfId.Value = "";
            lblErroForm.Visible = false;
            txtNome.Text = "";
            txtCpf.Text = "";
            ddlTipo.SelectedIndex = 0;
            ddlTipoRegistro.SelectedIndex = 0;
            txtNumeroRegistro.Text = "";
            txtEmail.Text = "";
            txtTelefone.Text = "";
            txtCelular.Text = "";
            ddlStatus.SelectedIndex = 0;
            txtObservacoes.Text = "";
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            if (!PodeEditar) { ErroForm(lblErroForm, "Seu perfil não tem permissão para alterar dados."); return; }

            string cpf = Texto.SoDigitos(txtCpf.Text);
            string email = txtEmail.Text.Trim();

            if (txtNome.Text.Trim() == "") { ErroForm(lblErroForm, "Informe o nome do profissional."); return; }
            if (ddlTipo.SelectedValue == "") { ErroForm(lblErroForm, "Selecione o tipo de profissional."); return; }
            if (cpf == "") { ErroForm(lblErroForm, "Informe o CPF do profissional."); return; }
            if (!Validacao.Cpf(cpf)) { ErroForm(lblErroForm, "CPF inválido."); return; }
            if (email != "" && !Validacao.Email(email)) { ErroForm(lblErroForm, "E-mail inválido."); return; }
            if (ddlTipoRegistro.SelectedValue == "") { ErroForm(lblErroForm, "Selecione o tipo de registro (CREA, CAU...)."); return; }
            if (txtNumeroRegistro.Text.Trim() == "") { ErroForm(lblErroForm, "Informe o número do registro profissional."); return; }

            string telefone = Texto.SoDigitos(txtTelefone.Text);
            string celular = Texto.SoDigitos(txtCelular.Text);
            if (telefone != "" && !Validacao.Telefone(telefone)) { ErroForm(lblErroForm, "Telefone inválido. Informe o DDD e o número."); return; }
            if (celular != "" && !Validacao.Telefone(celular)) { ErroForm(lblErroForm, "Celular inválido. Informe o DDD e o número."); return; }

            Profissional p = new Profissional();
            p.Id = hfId.Value == "" ? 0 : int.Parse(hfId.Value);
            p.Nome = txtNome.Text.Trim();
            p.Cpf = cpf;
            p.TipoProfissionalId = int.Parse(ddlTipo.SelectedValue);
            p.TipoRegistroId = Texto.Inteiro(ddlTipoRegistro.SelectedValue);
            p.NumeroRegistro = txtNumeroRegistro.Text.Trim();
            p.Email = email;
            p.Telefone = telefone;
            p.Celular = celular;
            p.Status = ddlStatus.SelectedValue;
            p.Observacoes = txtObservacoes.Text.Trim();

            try
            {
                ProfissionalDAO.Salvar(p);
                FecharModal(pnlForm);
                Mensagem("Profissional salvo com sucesso.");
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
