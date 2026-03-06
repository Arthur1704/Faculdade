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

        
    }
}