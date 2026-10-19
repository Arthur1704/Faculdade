using System;
using System.Data;
using System.Web.UI.WebControls;
using WebApplication1.Dados;
using WebApplication1.Modelos;
using WebApplication1.Utilitarios;

namespace WebApplication1
{
    public partial class proprietarios : PaginaBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) CarregarGrid();
        }

        private void CarregarGrid()
        {
            try
            {
                DataTable dados = ProprietarioDAO.Listar(txtPesquisa.Text, ddlFiltroStatus.SelectedValue, ddlOrdem.SelectedValue);
                lblTotal.Text = dados.Rows.Count + " registro(s)";
                Vincular(gvDados, dados);
            }
            catch (Exception ex)
            {
                MensagemErro(TextoErroBanco(ex));
            }
        }

        // ---------- Filtros e paginação ----------
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

        // ---------- Botões da tabela (Ver / Editar / Excluir) ----------
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
            Proprietario p = ProprietarioDAO.Obter(id);
            if (p == null) { MensagemErro("Registro não encontrado."); return; }

            lblTituloView.Text = "Proprietário";
            vNome.Text = Texto.Html(p.NomeRazaoSocial);
            vDoc.Text = Texto.FormatarDocumento(p.CpfCnpj);
            vEmail.Text = Texto.Html(p.Email);
            vTelefone.Text = Texto.FormatarTelefone(p.Telefone);
            vCelular.Text = Texto.FormatarTelefone(p.Celular);

            string endereco = p.Endereco;
            if (p.Numero != "") endereco += ", " + p.Numero;
            if (p.Complemento != "") endereco += " - " + p.Complemento;
            if (p.Bairro != "") endereco += " - " + p.Bairro;
            if (p.Cep != "") endereco += " (CEP " + Texto.FormatarCep(p.Cep) + ")";
            vEndereco.Text = Texto.Html(endereco);
            vCidade.Text = Texto.Html(p.Cidade + (p.Estado != "" ? " / " + p.Estado : ""));
            vStatus.Text = p.Status;
            vAtualizacao.Text = Texto.FormatarData(p.AtualizadoEm);
            AbrirModal(pnlView);
        }

        private void Editar(int id)
        {
            Proprietario p = ProprietarioDAO.Obter(id);
            if (p == null) { MensagemErro("Registro não encontrado."); return; }

            LimparFormulario();
            hfId.Value = p.Id.ToString();
            lblTituloForm.Text = "Editar proprietário";
            txtNome.Text = p.NomeRazaoSocial;
            txtCpfCnpj.Text = Texto.FormatarDocumento(p.CpfCnpj);
            txtEmail.Text = p.Email;
            txtTelefone.Text = Texto.FormatarTelefone(p.Telefone);
            txtCelular.Text = Texto.FormatarTelefone(p.Celular);
            txtCep.Text = Texto.FormatarCep(p.Cep);
            txtEndereco.Text = p.Endereco;
            txtNumero.Text = p.Numero;
            txtComplemento.Text = p.Complemento;
            txtBairro.Text = p.Bairro;
            txtCidade.Text = p.Cidade;
            Selecionar(ddlEstado, p.Estado);
            Selecionar(ddlStatus, p.Status);
            AbrirModal(pnlForm);
        }

        private void Excluir(int id)
        {
            if (!PodeEditar) { MensagemErro("Seu perfil não tem permissão para excluir."); return; }
            ProprietarioDAO.Excluir(id);
            Mensagem("Proprietário excluído com sucesso.");
            CarregarGrid();
        }

        // ---------- Formulário ----------
        protected void btnNovo_Click(object sender, EventArgs e)
        {
            LimparFormulario();
            lblTituloForm.Text = "Novo proprietário";
            AbrirModal(pnlForm);
        }

        private void LimparFormulario()
        {
            hfId.Value = "";
            lblErroForm.Visible = false;
            txtNome.Text = "";
            txtCpfCnpj.Text = "";
            txtEmail.Text = "";
            txtTelefone.Text = "";
            txtCelular.Text = "";
            txtCep.Text = "";
            txtEndereco.Text = "";
            txtNumero.Text = "";
            txtComplemento.Text = "";
            txtBairro.Text = "";
            txtCidade.Text = "";
            ddlEstado.SelectedIndex = 0;
            ddlStatus.SelectedIndex = 0;
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            if (!PodeEditar) { ErroForm(lblErroForm, "Seu perfil não tem permissão para alterar dados."); return; }

            string documento = Texto.SoDigitos(txtCpfCnpj.Text);
            string email = txtEmail.Text.Trim();

            if (txtNome.Text.Trim() == "") { ErroForm(lblErroForm, "Informe o nome ou a razão social."); return; }
            if (documento == "") { ErroForm(lblErroForm, "Informe o CPF ou CNPJ do proprietário."); return; }
            if (!Validacao.CpfOuCnpj(documento)) { ErroForm(lblErroForm, "CPF/CNPJ inválido."); return; }
            if (email != "" && !Validacao.Email(email)) { ErroForm(lblErroForm, "E-mail inválido."); return; }

            string telefone = Texto.SoDigitos(txtTelefone.Text);
            string celular = Texto.SoDigitos(txtCelular.Text);
            string cep = Texto.SoDigitos(txtCep.Text);
            if (telefone != "" && !Validacao.Telefone(telefone)) { ErroForm(lblErroForm, "Telefone inválido. Informe o DDD e o número."); return; }
            if (celular != "" && !Validacao.Telefone(celular)) { ErroForm(lblErroForm, "Celular inválido. Informe o DDD e o número."); return; }
            if (cep != "" && !Validacao.Cep(cep)) { ErroForm(lblErroForm, "CEP inválido (8 números)."); return; }

            Proprietario p = new Proprietario();
            p.Id = hfId.Value == "" ? 0 : int.Parse(hfId.Value);
            p.NomeRazaoSocial = txtNome.Text.Trim();
            p.CpfCnpj = documento;
            p.Email = email;
            p.Telefone = telefone;
            p.Celular = celular;
            p.Cep = cep;
            p.Endereco = txtEndereco.Text.Trim();
            p.Numero = txtNumero.Text.Trim();
            p.Complemento = txtComplemento.Text.Trim();
            p.Bairro = txtBairro.Text.Trim();
            p.Cidade = txtCidade.Text.Trim();
            p.Estado = ddlEstado.SelectedValue;
            p.Status = ddlStatus.SelectedValue;

            try
            {
                ProprietarioDAO.Salvar(p);
                FecharModal(pnlForm);
                Mensagem("Proprietário salvo com sucesso.");
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
