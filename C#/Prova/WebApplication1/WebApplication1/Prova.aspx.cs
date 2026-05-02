using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Prova : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnEnviar.Enabled = false;
            }
            else { btnEnviar.Enabled = true; }
        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            //TextBox
            if (string.IsNullOrWhiteSpace(txt1.Text) && txt1.Text.Any(char.IsDigit)) {                
                LabelTxt.Text = "Texto Invalido!";
            }
            else
            {
                LabelTxt.Text = txt1.Text;
            }
            
            //DropDownList
            if (ddl1.SelectedIndex != -1)
            {
                Labelddl.Text = ddl1.SelectedItem.Text;
            }
            else
            {
                Labelddl.Text = "Selecione um!";
            }

            //CheckBox
            bool achou = false;
            foreach (ListItem item in cxl1.Items)
            {
                if (item.Selected)
                {
                    LabelCheck.Text = item.Text;
                    achou = true;
                }
            }

            if (!achou)
            {
                LabelCheck.Text = "Selecione um Item";
            }

            //RadioButtonList
            achou = false;
            for (int cont = 0; cont < rbl1.Items.Count; cont++)
            {
                if (rbl1.Items[cont].Selected)
                {
                    Labelrbl.Text = rbl1.Items[cont].Text;
                    achou = true;
                }
            }

            if (!achou)
            {
                LabelCheck.Text = "Selecione um Item";
            }

            Response.Redirect("Default.aspx");
            //pelo html é PostBackUrl = "~/Default.aspx"

        }
    }
}