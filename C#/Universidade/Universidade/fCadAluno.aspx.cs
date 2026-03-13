using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Universidade
{
    public partial class fCadAluno : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                TextBoxRA.Enabled = false;
                btnProx.Enabled = false;
            }
            else
            {
                if (TextBoxNome.Text != "")
                    TextBoxRA.Enabled = true;

                if (TextBoxNome.Text != "" && TextBoxRA.Text != "")
                    btnProx.Enabled = true;
            }
        }

        protected void TextBoxNome_TextChanged(object sender, EventArgs e)
        {
            if (TextBoxNome.Text != "")
            {
                TextBoxRA.Enabled = true;
            }
        }

        protected void TextBoxRA_TextChanged(object sender, EventArgs e)
        {
            if (TextBoxNome.Text != "" && TextBoxRA.Text != "")
            {
                btnProx.Enabled = true;
            }
        }

        protected void btnProx_Click(object sender, EventArgs e)
        {
            string nome = TextBoxNome.Text;

            if (string.IsNullOrWhiteSpace(nome))
            {
                //se o campo estiver vazio
                Label1.Text = "O campo não pode estar vazio.";
            }
            else if (char.IsDigit(nome[0]))
            {
                //se o texto começar com um número
                Label1.Text = "O campo não pode iniciar com um número.";
            }
            else
            {
                //caso contrário, limpar a mensagem
                Label1.Text = "";
                Response.Redirect("/fCadCursos.aspx");
            }

            if (!int.TryParse(TextBoxRA.Text, out _))
            {
                Label2.Text = "Campo exclusivamente numérico (tipo inteiro).";
            }
            else
            {
                Label2.Text = "";
            }

            if (ddlEstado.SelectedIndex <= 0)
            {
                Label3.Text = "Nenhuma opção selecionada.";
            }
            else
            {
                Label3.Text = "";
                Response.Redirect("/fCadCursos.aspx");
            }

        }


    }
}