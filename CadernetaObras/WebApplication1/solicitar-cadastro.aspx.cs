using System;
using System.Web.UI;
using WebApplication1.Dados;
using WebApplication1.Modelos;
using WebApplication1.Utilitarios;

namespace WebApplication1
{
    public partial class solicitar_cadastro : System.Web.UI.Page
    {
        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            lblErro.Visible = false;
            lblOk.Visible = false;

            string nome = txtNome.Text.Trim();
            string email = txtEmail.Text.Trim();
            string cpf = Texto.SoDigitos(txtCpf.Text);
            string telefone = Texto.SoDigitos(txtTelefone.Text);

            if (nome == "") { Erro("Informe o seu nome."); return; }
            if (email == "" || !Validacao.Email(email)) { Erro("Informe um e-mail válido."); return; }
            if (cpf != "" && !Validacao.Cpf(cpf)) { Erro("CPF inválido."); return; }
            if (telefone != "" && !Validacao.Telefone(telefone)) { Erro("Telefone inválido. Informe o DDD e o número."); return; }

            try
            {
                if (SolicitacaoCadastroDAO.ExistePendente(email))
                {
                    Erro("Já existe uma solicitação pendente para este e-mail. Aguarde o contato do administrador.");
                    return;
                }

                SolicitacaoCadastro s = new SolicitacaoCadastro();
                s.Nome = nome;
                s.Email = email;
                s.Cpf = cpf;
                s.Telefone = telefone;
                s.Mensagem = txtMensagem.Text.Trim();
                SolicitacaoCadastroDAO.Inserir(s);

                pnlFormulario.Visible = false;
                lblOk.Text = "Solicitação enviada! O administrador vai analisar o pedido e entrar em contato.";
                lblOk.Visible = true;
            }
            catch (Exception ex)
            {
                Registro.Erro(ex);
                Erro("Não foi possível enviar a solicitação agora. Tente novamente mais tarde.");
            }
        }

        private void Erro(string texto)
        {
            lblErro.Text = Server.HtmlEncode(texto);
            lblErro.Visible = true;
        }
    }
}
