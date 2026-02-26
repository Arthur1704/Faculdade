using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Universidade
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            btnProx.Visible = false;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        protected void rblTermos_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (rblTermos.SelectedIndex)
            {
                case 0:
                    btnProx.Visible = true;
                    break;
                default:
                    btnProx.Visible = false;
                    break;
            }
        }
    }
}