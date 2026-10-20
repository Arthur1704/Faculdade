using System;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.Dados;
using WebApplication1.Modelos;
using WebApplication1.Utilitarios;

namespace WebApplication1
{
    public class PaginaBase : Page
    {
        protected virtual bool SomenteAdministrador
        {
            get { return false; }
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            if (Session["UsuarioId"] == null)
            {
                Response.Redirect("login.aspx");
                return;
            }
            try
            {
                Usuario atual = UsuarioDAO.Obter(UsuarioLogadoId);
                if (atual == null || atual.Status != "Ativo")
                {
                    Session.Clear();
                    Session.Abandon();
                    Response.Redirect("login.aspx?motivo=encerrada");
                    return;
                }
                Session["UsuarioPerfil"] = atual.Perfil;
                Session["UsuarioNome"] = atual.Nome;
            }
            catch (SqlException ex)
            {
                Registro.Erro(ex);
            }

            if (SomenteAdministrador && PerfilLogado != "Administrador")
            {
                Response.Redirect("inicio.aspx");
            }
        }

        protected int UsuarioLogadoId
        {
            get { return (int)Session["UsuarioId"]; }
        }

        protected string PerfilLogado
        {
            get { return Convert.ToString(Session["UsuarioPerfil"]); }
        }

        protected bool PodeEditar
        {
            get { return PerfilLogado != "Visualizador"; }
        }

        protected void Mensagem(string texto)
        {
            SiteMaster m = Master as SiteMaster;
            if (m != null) m.MostrarMensagem(texto, false);
        }

        protected void MensagemErro(string texto)
        {
            SiteMaster m = Master as SiteMaster;
            if (m != null) m.MostrarMensagem(texto, true);
        }

        protected void ErroForm(Label label, string texto)
        {
            label.Text = HttpUtility.HtmlEncode(texto);
            label.Visible = true;
        }

        protected string TextoErroBanco(Exception ex)
        {
            SqlException sql = ex as SqlException;
            if (sql != null)
            {
                if (sql.Number == 547)
                    return "Não foi possível concluir: este registro está vinculado a outros dados (ou um dado informado não existe). Se for o caso, altere o status para Inativo.";
                if (sql.Number == 2601 || sql.Number == 2627)
                    return "Já existe um registro com o mesmo dado único (CPF/CNPJ, usuário, matrícula, referência, descrição ou registro profissional).";
                if (sql.Number == 53 || sql.Number == -1 || sql.Number == 4060 || sql.Number == 18456)
                    return "Não foi possível conectar ao banco de dados. Verifique a string de conexão no Web.config.";
            }
            Registro.Erro(ex);
            return "Ocorreu um erro inesperado. Tente novamente; se continuar, avise o administrador.";
        }

        protected void AbrirModal(Panel painel)
        {
            painel.CssClass = "modal-backdrop open";
        }

        protected void FecharModal(Panel painel)
        {
            painel.CssClass = "modal-backdrop";
        }

        protected void PreencherCombo(DropDownList combo, DataTable dados, string campoValor, string campoTexto, string primeiroItem)
        {
            combo.DataSource = dados;
            combo.DataValueField = campoValor;
            combo.DataTextField = campoTexto;
            combo.DataBind();
            if (primeiroItem != null)
                combo.Items.Insert(0, new ListItem(primeiroItem, ""));
        }

        protected void Selecionar(DropDownList combo, object valor)
        {
            combo.ClearSelection();
            if (valor == null) return;
            ListItem item = combo.Items.FindByValue(Convert.ToString(valor));
            if (item != null) item.Selected = true;
        }

        protected void Vincular(GridView grid, DataTable dados)
        {
            if (grid.PageIndex > 0 && dados.Rows.Count <= grid.PageIndex * grid.PageSize)
                grid.PageIndex = 0;
            grid.DataSource = dados;
            grid.DataBind();
            AjustarGrid(grid);
        }

        protected void AjustarGrid(GridView grid)
        {
            grid.UseAccessibleHeader = true;
            if (grid.HeaderRow != null)
                grid.HeaderRow.TableSection = TableRowSection.TableHeader;
        }

        protected string ClasseStatus(object status)
        {
            switch (Convert.ToString(status))
            {
                case "Ativo":
                case "Em andamento":
                case "Emitido":
                case "Concluído":
                case "Concluída":
                case "Aprovada":
                    return "ok";
                case "Pendente":
                case "Planejada":
                case "Aguardando":
                case "Rascunho":
                case "Pronto para assinatura":
                    return "warn";
                default:
                    return "off";
            }
        }

        protected string FormatarDocumento(object valor) { return Texto.FormatarDocumento(Texto.Valor(valor)); }
        protected string FormatarData(object valor) { return Texto.FormatarData(valor); }
        protected string FormatarMoeda(object valor) { return Texto.FormatarMoeda(valor); }

        protected string Resumo(object texto)
        {
            return HttpUtility.HtmlEncode(Texto.Resumo(Texto.Valor(texto), 60));
        }

        protected string Tamanho(object bytes)
        {
            if (bytes == null || bytes == DBNull.Value) return "";
            double kb = Convert.ToDouble(bytes) / 1024;
            return kb >= 1024 ? (kb / 1024).ToString("0.0") + " MB" : kb.ToString("0") + " KB";
        }
    }
}
