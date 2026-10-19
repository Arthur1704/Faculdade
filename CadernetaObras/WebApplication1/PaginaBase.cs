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
    // Página-mãe de todas as telas internas (todas herdam daqui em vez de System.Web.UI.Page).
    // Aqui ficam as coisas que se repetem: verificar login, mensagens, abrir/fechar modal, formatações.
    public class PaginaBase : Page
    {
        // Telas que só o Administrador pode abrir (ex.: Usuários) sobrescrevem esta propriedade.
        protected virtual bool SomenteAdministrador
        {
            get { return false; }
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            // Quem não fez login volta para a tela de acesso
            if (Session["UsuarioId"] == null)
            {
                Response.Redirect("login.aspx");
                return;
            }
            // Confere no banco se o usuário continua ativo e atualiza o perfil
            // (assim, inativar ou trocar o perfil de alguém vale já na próxima tela que ele abrir)
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
                Registro.Erro(ex);   // banco fora do ar: a própria tela mostra o aviso de erro
            }

            if (SomenteAdministrador && PerfilLogado != "Administrador")
            {
                Response.Redirect("inicio.aspx");
            }
        }

        // ---------- Usuário logado ----------
        protected int UsuarioLogadoId
        {
            get { return (int)Session["UsuarioId"]; }
        }

        protected string PerfilLogado
        {
            get { return Convert.ToString(Session["UsuarioPerfil"]); }
        }

        // O perfil "Visualizador" só consulta, não grava nem exclui
        protected bool PodeEditar
        {
            get { return PerfilLogado != "Visualizador"; }
        }

        // ---------- Mensagens ----------
        // Mensagem no topo da página (feita no Site.Master)
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

        // Mensagem de erro dentro do formulário (modal)
        protected void ErroForm(Label label, string texto)
        {
            label.Text = HttpUtility.HtmlEncode(texto);
            label.Visible = true;
        }

        // Traduz o erro do SQL Server para algo que o usuário entenda
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
            // erro inesperado: o detalhe técnico vai para App_Data/Logs, o usuário vê uma mensagem simples
            Registro.Erro(ex);
            return "Ocorreu um erro inesperado. Tente novamente; se continuar, avise o administrador.";
        }

        // ---------- Modais (Panel com a classe "modal-backdrop") ----------
        protected void AbrirModal(Panel painel)
        {
            painel.CssClass = "modal-backdrop open";
        }

        protected void FecharModal(Panel painel)
        {
            painel.CssClass = "modal-backdrop";
        }

        // ---------- Controles ----------
        protected void PreencherCombo(DropDownList combo, DataTable dados, string campoValor, string campoTexto, string primeiroItem)
        {
            combo.DataSource = dados;
            combo.DataValueField = campoValor;
            combo.DataTextField = campoTexto;
            combo.DataBind();
            if (primeiroItem != null)
                combo.Items.Insert(0, new ListItem(primeiroItem, ""));
        }

        // Seleciona o item de um combo sem dar erro se o valor não existir
        protected void Selecionar(DropDownList combo, object valor)
        {
            combo.ClearSelection();
            if (valor == null) return;
            ListItem item = combo.Items.FindByValue(Convert.ToString(valor));
            if (item != null) item.Selected = true;
        }

        // Mostra os dados no GridView (volta uma página se a atual ficou vazia, ex.: após excluir)
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

        // ---------- Métodos usados dentro dos .aspx (<%# ... %>) ----------
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
