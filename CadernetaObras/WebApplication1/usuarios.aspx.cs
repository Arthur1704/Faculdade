using System;
using System.Data;
using System.Web.UI.WebControls;
using WebApplication1.Dados;
using WebApplication1.Modelos;
using WebApplication1.Utilitarios;

namespace WebApplication1
{
    public partial class usuarios : PaginaBase
    {
        // Só o administrador acessa esta tela
        protected override bool SomenteAdministrador
        {
            get { return true; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            try
            {
                PreencherCombo(ddlPerfil, ListaDAO.Perfis(), "PerfilId", "Nome", "Selecione");
            }
            catch (Exception ex)
            {
                MensagemErro(TextoErroBanco(ex));
            }
            CarregarGrid();
            CarregarSolicitacoes();
        }

        private void CarregarGrid()
        {
            try
            {
                DataTable dados = UsuarioDAO.Listar(txtPesquisa.Text, ddlFiltroStatus.SelectedValue, ddlOrdem.SelectedValue);
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
            if (e.CommandName != "Ver" && e.CommandName != "Editar" && e.CommandName != "Alternar") return;
            int id = Convert.ToInt32(e.CommandArgument);

            try
            {
                if (e.CommandName == "Ver") Visualizar(id);
                else if (e.CommandName == "Editar") Editar(id);
                else AlternarStatus(id);
            }
            catch (Exception ex)
            {
                MensagemErro(TextoErroBanco(ex));
            }
        }

        private void Visualizar(int id)
        {
            Usuario u = UsuarioDAO.Obter(id);
            if (u == null) { MensagemErro("Registro não encontrado."); return; }

            lblTituloView.Text = "Usuário";
            vNome.Text = Texto.Html(u.Nome);
            vUsuario.Text = Texto.Html(u.Login);
            vMatricula.Text = Texto.Html(u.Matricula);
            vCpf.Text = Texto.FormatarDocumento(u.Cpf);
            vEmail.Text = Texto.Html(u.Email);
            vTelefone.Text = Texto.FormatarTelefone(u.Telefone);
            vPerfil.Text = Texto.Html(u.Perfil);
            vStatus.Text = u.Status;
            vAtualizacao.Text = Texto.FormatarData(u.AtualizadoEm);
            AbrirModal(pnlView);
        }

        private void Editar(int id)
        {
            Usuario u = UsuarioDAO.Obter(id);
            if (u == null) { MensagemErro("Registro não encontrado."); return; }

            LimparFormulario();
            hfId.Value = u.Id.ToString();
            lblTituloForm.Text = "Editar usuário";
            lblDicaSenha.Text = "Deixe a senha em branco para manter a senha atual.";
            txtNome.Text = u.Nome;
            txtUsuario.Text = u.Login;
            txtMatricula.Text = u.Matricula;
            txtCpf.Text = Texto.FormatarDocumento(u.Cpf);
            txtEmail.Text = u.Email;
            txtTelefone.Text = Texto.FormatarTelefone(u.Telefone);
            Selecionar(ddlPerfil, u.PerfilId);
            Selecionar(ddlStatus, u.Status);
            AbrirModal(pnlForm);
        }

        private void AlternarStatus(int id)
        {
            if (id == UsuarioLogadoId)
            {
                MensagemErro("Você não pode inativar o seu próprio usuário.");
                return;
            }
            UsuarioDAO.AlternarStatus(id);
            Mensagem("Status do usuário alterado.");
            CarregarGrid();
        }

        protected void btnNovo_Click(object sender, EventArgs e)
        {
            LimparFormulario();
            lblTituloForm.Text = "Novo usuário";
            lblDicaSenha.Text = "A senha deve ter pelo menos 6 caracteres.";
            AbrirModal(pnlForm);
        }

        private void LimparFormulario()
        {
            hfId.Value = "";
            hfSolicitacaoId.Value = "";
            lblErroForm.Visible = false;
            lblDicaSenha.Text = "";
            txtNome.Text = "";
            txtUsuario.Text = "";
            txtMatricula.Text = "";
            txtCpf.Text = "";
            txtEmail.Text = "";
            txtTelefone.Text = "";
            ddlPerfil.SelectedIndex = 0;
            ddlStatus.SelectedIndex = 0;
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            bool novo = (hfId.Value == "");
            string cpf = Texto.SoDigitos(txtCpf.Text);
            string email = txtEmail.Text.Trim();
            string senha = txtSenha.Text;

            if (txtNome.Text.Trim() == "") { ErroForm(lblErroForm, "Informe o nome."); return; }
            if (txtUsuario.Text.Trim() == "") { ErroForm(lblErroForm, "Informe o usuário (login)."); return; }
            if (!Validacao.Cpf(cpf)) { ErroForm(lblErroForm, "CPF inválido."); return; }
            if (email == "") { ErroForm(lblErroForm, "Informe o e-mail do usuário."); return; }
            if (!Validacao.Email(email)) { ErroForm(lblErroForm, "E-mail inválido."); return; }
            string telefone = Texto.SoDigitos(txtTelefone.Text);
            if (telefone != "" && !Validacao.Telefone(telefone)) { ErroForm(lblErroForm, "Telefone inválido. Informe o DDD e o número."); return; }
            if (ddlPerfil.SelectedValue == "") { ErroForm(lblErroForm, "Selecione o perfil."); return; }
            if (novo && senha == "") { ErroForm(lblErroForm, "Informe a senha do novo usuário."); return; }
            if (senha != "" && senha.Length < 6) { ErroForm(lblErroForm, "A senha deve ter pelo menos 6 caracteres."); return; }
            if (senha != txtConfirmaSenha.Text) { ErroForm(lblErroForm, "A confirmação da senha não confere."); return; }

            Usuario u = new Usuario();
            u.Id = novo ? 0 : int.Parse(hfId.Value);
            u.Nome = txtNome.Text.Trim();
            u.Login = txtUsuario.Text.Trim();
            u.Matricula = txtMatricula.Text.Trim();
            u.Cpf = cpf;
            u.Email = email;
            u.Telefone = telefone;
            u.PerfilId = int.Parse(ddlPerfil.SelectedValue);
            u.Status = ddlStatus.SelectedValue;
            u.SenhaHash = senha == "" ? "" : Seguranca.GerarHash(senha);

            if (u.Id == UsuarioLogadoId && u.Status != "Ativo")
            {
                ErroForm(lblErroForm, "Você não pode inativar o seu próprio usuário.");
                return;
            }
            // evita ficar sem nenhum administrador
            if (u.Id == UsuarioLogadoId && ddlPerfil.SelectedItem.Text != "Administrador")
            {
                ErroForm(lblErroForm, "Você não pode retirar o seu próprio perfil de administrador.");
                return;
            }

            try
            {
                UsuarioDAO.Salvar(u);

                // se veio de uma solicitação de cadastro, marca como aprovada
                if (hfSolicitacaoId.Value != "")
                {
                    SolicitacaoCadastroDAO.Analisar(int.Parse(hfSolicitacaoId.Value), "Aprovada", UsuarioLogadoId);
                    hfSolicitacaoId.Value = "";
                }

                FecharModal(pnlForm);
                Mensagem("Usuário salvo com sucesso.");
                CarregarGrid();
                CarregarSolicitacoes();
            }
            catch (Exception ex)
            {
                ErroForm(lblErroForm, TextoErroBanco(ex));
            }
        }

        // ---------- Solicitações de cadastro (feitas na tela de login) ----------
        private void CarregarSolicitacoes()
        {
            try
            {
                DataTable pendentes = SolicitacaoCadastroDAO.ListarPendentes();
                pnlSolicitacoes.Visible = pendentes.Rows.Count > 0;
                gvSolicitacoes.DataSource = pendentes;
                gvSolicitacoes.DataBind();
                AjustarGrid(gvSolicitacoes);
            }
            catch (Exception ex)
            {
                MensagemErro(TextoErroBanco(ex));
            }
        }

        protected void gvSolicitacoes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName != "Criar" && e.CommandName != "Rejeitar") return;
            int id = Convert.ToInt32(e.CommandArgument);

            try
            {
                SolicitacaoCadastro s = SolicitacaoCadastroDAO.Obter(id);
                if (s == null || s.Status != "Pendente")
                {
                    MensagemErro("Solicitação não encontrada ou já analisada.");
                    CarregarSolicitacoes();
                    return;
                }

                if (e.CommandName == "Rejeitar")
                {
                    SolicitacaoCadastroDAO.Analisar(id, "Rejeitada", UsuarioLogadoId);
                    Mensagem("Solicitação rejeitada.");
                    CarregarSolicitacoes();
                    return;
                }

                // "Criar usuário": abre o formulário já preenchido com os dados do pedido
                LimparFormulario();
                hfSolicitacaoId.Value = id.ToString();
                lblTituloForm.Text = "Novo usuário (solicitação)";
                lblDicaSenha.Text = "Defina uma senha inicial (mínimo 6 caracteres) e informe ao usuário.";
                txtNome.Text = s.Nome;
                txtCpf.Text = Texto.FormatarDocumento(s.Cpf);
                txtEmail.Text = s.Email;
                txtTelefone.Text = Texto.FormatarTelefone(s.Telefone);
                AbrirModal(pnlForm);
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
