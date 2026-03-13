using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Universidade
{
    public partial class fCadCursos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnProx_Click(object sender, EventArgs e)
        {
            bool selecionado = false;

            for (int i = 0; i < CheckBoxList1.Items.Count; i++)
            {

                if (CheckBoxList1.Items[i].Selected)
                {
                    selecionado = true;
                    break; //interrompe o loop ao encontrar uma seleção
                }
            }
            if (!selecionado)
            {
                LabelAviso1.Text = "Nenhuma opção selecionada.";
            }
            else
            {
                LabelAviso1.Text = "";
                Response.Redirect("fFinal.aspx");
            }

            bool selecionadoRadio = false;

            for (int i = 0; i < RadioButtonList1.Items.Count; i++)
            {

                if (RadioButtonList1.Items[i].Selected)
                {
                    selecionadoRadio = true;
                    break; //interrompe o loop ao encontrar uma seleção
                }
            }
            if (!selecionadoRadio)
            {
                LabelAviso2.Text = "Nenhuma opção selecionada.";
            }
            else
            {
                LabelAviso2.Text = "";
                Response.Redirect("fFinal.aspx");
            }
        }
    }
}