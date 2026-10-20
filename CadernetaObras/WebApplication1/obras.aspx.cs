using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Web;
using System.Web.UI.WebControls;
using WebApplication1.Dados;
using WebApplication1.Modelos;
using WebApplication1.Utilitarios;

namespace WebApplication1
{
    public partial class obras : PaginaBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            CarregarCombos(0, 0, 0);
            CarregarGrid();
        }

        private void CarregarCombos(int proprietarioAtual, int tipoAtual, int profissionalAtual)
        {
            try
            {
                PreencherCombo(ddlProprietario, ListaDAO.Proprietarios(true, proprietarioAtual), "ProprietarioId", "NomeRazaoSocial", "Selecione");
                PreencherCombo(ddlProfissional, ListaDAO.ProfissionaisAtivos(profissionalAtual), "ProfissionalId", "Nome", "Selecione");
                PreencherCombo(ddlTipoObra, ListaDAO.TiposObraAtivos(tipoAtual), "TipoObraId", "Descricao", "Selecione");
                PreencherCombo(ddlAtividade, ListaDAO.AtividadesTecnicas(), "AtividadeTecnicaId", "Descricao", "Selecione");
            }
            catch (Exception ex)
            {
                MensagemErro(TextoErroBanco(ex));
            }
        }

        private void CarregarGrid()
        {
            try
            {
                DataTable dados = ObraDAO.Listar(txtPesquisa.Text, ddlFiltroStatus.SelectedValue, ddlOrdem.SelectedValue);
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
            if (e.CommandName != "Ver" && e.CommandName != "Editar" && e.CommandName != "Capa" && e.CommandName != "Excluir") return;
            int id = Convert.ToInt32(e.CommandArgument);

            try
            {
                if (e.CommandName == "Ver") Visualizar(id);
                else if (e.CommandName == "Editar") Editar(id);
                else if (e.CommandName == "Capa") AbrirCapa(id);
                else Excluir(id);
            }
            catch (Exception ex)
            {
                MensagemErro(TextoErroBanco(ex));
            }
        }

        private void Visualizar(int id)
        {
            Obra o = ObraDAO.Obter(id);
            if (o == null) { MensagemErro("Registro não encontrado."); return; }

            lblTituloView.Text = "Obra";
            vNome.Text = Texto.Html(o.Nome);
            vCaderneta.Text = Texto.Html(o.NumeroCaderneta);
            vStatus.Text = o.Status;
            vProprietario.Text = Texto.Html(o.Proprietario);
            vResponsavel.Text = Texto.Html(o.Profissional);
            vRT.Text = Texto.Html(o.NumeroRT);
            vEmpresa.Text = Texto.Html(o.Empresa);
            vTipo.Text = Texto.Html(o.TipoObra);
            vAtividade.Text = Texto.Html(o.AtividadeTecnica);
            vValor.Text = Texto.FormatarMoeda(o.ValorObra);
            vInicio.Text = Texto.FormatarData(o.DataInicio);
            vTermino.Text = Texto.FormatarData(o.PrevisaoTermino);
            vEndereco.Text = Texto.Html(o.EnderecoObra);
            vAreaConstruir.Text = Texto.FormatarArea(o.AreaConstruir ?? 0) + " m²";
            vAreaAmpliar.Text = Texto.FormatarArea(o.AreaAmpliar ?? 0) + " m²";
            vAreaRegularizar.Text = Texto.FormatarArea(o.AreaRegularizar ?? 0) + " m²";
            vAreaReforma.Text = Texto.FormatarArea(o.AreaReforma ?? 0) + " m²";
            vAreaTotal.Text = Texto.FormatarArea(o.AreaTotal) + " m²";
            vAtualizacao.Text = Texto.FormatarData(o.AtualizadoEm);
            vObservacoes.Text = Texto.Html(o.Observacoes);

            rptDocumentosView.DataSource = ObraDAO.ListarDocumentos(id);
            rptDocumentosView.DataBind();
            AbrirModal(pnlView);
        }

        private void AbrirCapa(int id)
        {
            CapaObra c = ObraDAO.ObterCapa(id);
            if (c == null) { MensagemErro("Registro não encontrado."); return; }

            cNumero.Text = Texto.Html(c.NumeroCaderneta);
            cProfissional.Text = Texto.Html(c.ProfissionalNome);
            cTitulo.Text = Texto.Html(c.TituloProfissional);
            cRT.Text = Texto.Html(c.NumeroRT);
            cProprietario.Text = Texto.Html(c.ProprietarioNome);
            cLocal.Text = Texto.Html(c.LocalObra);
            cRegistro.Text = Texto.Html((c.TipoRegistro + " " + c.NumeroRegistro).Trim());
            cCpfProf.Text = Texto.FormatarDocumento(c.ProfissionalCpf);
            cEmpresa.Text = Texto.Html(c.Empresa);
            cDocProp.Text = Texto.FormatarDocumento(c.ProprietarioCpfCnpj);
            cTelefone.Text = Texto.FormatarTelefone(c.ProprietarioTelefone);
            cValor.Text = Texto.FormatarMoeda(c.ValorObra);
            cAreaConstruir.Text = Texto.FormatarArea(c.AreaConstruir) + " m²";
            cAreaAmpliar.Text = Texto.FormatarArea(c.AreaAmpliar) + " m²";
            cAreaRegularizar.Text = Texto.FormatarArea(c.AreaRegularizar) + " m²";
            cAreaReforma.Text = Texto.FormatarArea(c.AreaReforma) + " m²";
            cAreaTotal.Text = Texto.FormatarArea(c.AreaTotal) + " m²";
            cTipo.Text = Texto.Html(c.TipoEdificacao);
            cAtividade.Text = Texto.Html(c.AtividadeTecnica);

            lblAvisoCapa.Visible = !c.ProfissionalId.HasValue;
            if (!c.ProfissionalId.HasValue)
                lblAvisoCapa.Text = "Esta obra ainda não tem responsável técnico. Edite a obra e escolha o profissional para completar a capa e assinar.";

            ucAssinaturas.Carregar("Obra", id, c.ProfissionalNome, c.ProprietarioNome);
            AbrirModal(pnlCapa);
        }

        protected void btnFecharCapa_Click(object sender, EventArgs e)
        {
            FecharModal(pnlCapa);
        }

        private void Editar(int id)
        {
            Obra o = ObraDAO.Obter(id);
            if (o == null) { MensagemErro("Registro não encontrado."); return; }

            CarregarCombos(o.ProprietarioId, o.TipoObraId, o.ProfissionalId ?? 0);
            LimparFormulario();
            hfId.Value = o.Id.ToString();
            lblTituloForm.Text = "Editar obra";
            txtNome.Text = o.Nome;
            txtNumeroCaderneta.Text = o.NumeroCaderneta;
            Selecionar(ddlProprietario, o.ProprietarioId);
            Selecionar(ddlProfissional, o.ProfissionalId);
            Selecionar(ddlTipoObra, o.TipoObraId);
            Selecionar(ddlAtividade, o.AtividadeTecnicaId);
            Selecionar(ddlStatus, o.Status);
            txtNumeroRT.Text = o.NumeroRT;
            txtEmpresa.Text = o.Empresa;
            txtValorObra.Text = o.ValorObra.HasValue ? o.ValorObra.Value.ToString("N2") : "";
            txtDataInicio.Text = Texto.DataParaCampo(o.DataInicio);
            txtPrevisaoTermino.Text = Texto.DataParaCampo(o.PrevisaoTermino);
            txtEnderecoObra.Text = o.EnderecoObra;
            areaConstruir.Text = Texto.FormatarArea(o.AreaConstruir);
            areaAmpliar.Text = Texto.FormatarArea(o.AreaAmpliar);
            areaRegularizar.Text = Texto.FormatarArea(o.AreaRegularizar);
            areaReforma.Text = Texto.FormatarArea(o.AreaReforma);
            areaTotal.Text = Texto.FormatarArea(o.AreaTotal);
            txtObservacoes.Text = o.Observacoes;
            CarregarDocumentosForm(id);
            AbrirModal(pnlForm);
        }

        private void Excluir(int id)
        {
            if (!PodeEditar) { MensagemErro("Seu perfil não tem permissão para excluir."); return; }
            if (AssinaturaDAO.Existe("Obra", id))
            {
                MensagemErro("Esta obra já tem assinatura digital na capa e não pode ser excluída. O administrador pode remover as assinaturas primeiro.");
                return;
            }

            List<ObraDocumento> documentos = ObraDAO.ObterDocumentosDaObra(id);
            ObraDAO.Excluir(id);
            foreach (ObraDocumento d in documentos) Arquivos.Apagar(d.CaminhoArquivo);
            Arquivos.ApagarPasta("~/App_Data/Uploads/obras/" + id);

            Mensagem("Obra excluída com sucesso.");
            CarregarGrid();
        }

        protected void btnNovo_Click(object sender, EventArgs e)
        {
            CarregarCombos(0, 0, 0);
            LimparFormulario();
            lblTituloForm.Text = "Nova obra";
            AbrirModal(pnlForm);
        }

        private void LimparFormulario()
        {
            hfId.Value = "";
            lblErroForm.Visible = false;
            txtNome.Text = "";
            txtNumeroCaderneta.Text = "";
            ddlProprietario.SelectedIndex = 0;
            ddlProfissional.SelectedIndex = 0;
            ddlTipoObra.SelectedIndex = 0;
            ddlAtividade.SelectedIndex = 0;
            ddlStatus.SelectedIndex = 0;
            txtNumeroRT.Text = "";
            txtEmpresa.Text = "";
            txtValorObra.Text = "";
            txtDataInicio.Text = "";
            txtPrevisaoTermino.Text = "";
            txtEnderecoObra.Text = "";
            areaConstruir.Text = "";
            areaAmpliar.Text = "";
            areaRegularizar.Text = "";
            areaReforma.Text = "";
            areaTotal.Text = "";
            txtObservacoes.Text = "";
            ddlTipoDocumento.SelectedIndex = 0;
            txtNomeDocumento.Text = "";
            rptDocumentosForm.DataSource = null;
            rptDocumentosForm.DataBind();
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            if (!PodeEditar) { ErroForm(lblErroForm, "Seu perfil não tem permissão para alterar dados."); return; }

            if (txtNome.Text.Trim() == "") { ErroForm(lblErroForm, "Informe o nome da obra."); return; }
            if (ddlProprietario.SelectedValue == "") { ErroForm(lblErroForm, "Selecione o proprietário."); return; }
            if (ddlProfissional.SelectedValue == "") { ErroForm(lblErroForm, "Selecione o responsável técnico."); return; }
            if (ddlTipoObra.SelectedValue == "") { ErroForm(lblErroForm, "Selecione o tipo de edificação."); return; }
            if (txtEnderecoObra.Text.Trim() == "") { ErroForm(lblErroForm, "Informe o local (endereço) da obra."); return; }

            DateTime? inicio = Texto.ParseData(txtDataInicio.Text);
            DateTime? termino = Texto.ParseData(txtPrevisaoTermino.Text);
            if (!inicio.HasValue) { ErroForm(lblErroForm, "Informe a data de início da obra."); return; }
            if (txtPrevisaoTermino.Text.Trim() != "" && !termino.HasValue) { ErroForm(lblErroForm, "Previsão de término inválida."); return; }
            if (termino.HasValue && termino.Value < inicio.Value)
            {
                ErroForm(lblErroForm, "A previsão de término não pode ser antes da data de início.");
                return;
            }

            decimal? valor = Texto.ParseDecimal(txtValorObra.Text);
            if (txtValorObra.Text.Trim() != "" && (!valor.HasValue || valor.Value < 0)) { ErroForm(lblErroForm, "Valor da obra inválido."); return; }

            decimal? areaC, areaA, areaG, areaR;
            string erroArea = LerArea(areaConstruir.Text, "construir", out areaC);
            if (erroArea == "") erroArea = LerArea(areaAmpliar.Text, "ampliar", out areaA); else areaA = null;
            if (erroArea == "") erroArea = LerArea(areaRegularizar.Text, "regularizar", out areaG); else areaG = null;
            if (erroArea == "") erroArea = LerArea(areaReforma.Text, "reformar", out areaR); else areaR = null;
            if (erroArea != "") { ErroForm(lblErroForm, erroArea); return; }

            List<HttpPostedFile> documentos = Arquivos.Enviados(Request, fuDocumentos.UniqueID);
            string erroArquivo = Arquivos.Validar(documentos);
            if (erroArquivo != "") { ErroForm(lblErroForm, erroArquivo); return; }

            Obra o = new Obra();
            o.Id = hfId.Value == "" ? 0 : int.Parse(hfId.Value);
            o.Nome = txtNome.Text.Trim();
            o.NumeroCaderneta = txtNumeroCaderneta.Text.Trim();
            o.ProprietarioId = int.Parse(ddlProprietario.SelectedValue);
            o.ProfissionalId = Texto.Inteiro(ddlProfissional.SelectedValue);
            o.TipoObraId = int.Parse(ddlTipoObra.SelectedValue);
            o.AtividadeTecnicaId = Texto.Inteiro(ddlAtividade.SelectedValue);
            o.NumeroRT = txtNumeroRT.Text.Trim();
            o.Empresa = txtEmpresa.Text.Trim();
            o.ValorObra = valor;
            o.DataInicio = inicio;
            o.PrevisaoTermino = termino;
            o.EnderecoObra = txtEnderecoObra.Text.Trim();
            o.Status = ddlStatus.SelectedValue;
            o.AreaConstruir = areaC;
            o.AreaAmpliar = areaA;
            o.AreaRegularizar = areaG;
            o.AreaReforma = areaR;
            o.Observacoes = txtObservacoes.Text.Trim();

            try
            {
                int obraId = ObraDAO.Salvar(o);
                hfId.Value = obraId.ToString();

                SalvarDocumentos(obraId, documentos);
                FecharModal(pnlForm);
                Mensagem("Obra salva com sucesso.");
                CarregarGrid();
            }
            catch (Exception ex)
            {
                ErroForm(lblErroForm, TextoErroBanco(ex));
            }
        }

        private string LerArea(string texto, string nome, out decimal? valor)
        {
            valor = null;
            if (texto.Trim() == "") return "";
            valor = Texto.ParseDecimal(texto);
            if (!valor.HasValue) return "Área a " + nome + " inválida.";
            if (valor.Value < 0) return "A área a " + nome + " não pode ser negativa.";
            return "";
        }

        private void SalvarDocumentos(int obraId, List<HttpPostedFile> arquivos)
        {
            foreach (HttpPostedFile arquivo in arquivos)
            {
                string nomeOriginal = Path.GetFileName(arquivo.FileName);
                ObraDocumento d = new ObraDocumento();
                d.ObraId = obraId;
                d.TipoDocumento = ddlTipoDocumento.SelectedValue;
                d.NomeDocumento = txtNomeDocumento.Text.Trim() != "" ? txtNomeDocumento.Text.Trim() : Path.GetFileNameWithoutExtension(nomeOriginal);
                d.NomeOriginal = nomeOriginal;
                d.CaminhoArquivo = Arquivos.Salvar(arquivo, "~/App_Data/Uploads/obras/" + obraId);
                d.ContentType = arquivo.ContentType;
                d.TamanhoBytes = arquivo.ContentLength;
                try
                {
                    ObraDAO.InserirDocumento(d);
                }
                catch
                {
                    Arquivos.Apagar(d.CaminhoArquivo);
                    throw;
                }
            }
        }

        private void CarregarDocumentosForm(int obraId)
        {
            rptDocumentosForm.DataSource = ObraDAO.ListarDocumentos(obraId);
            rptDocumentosForm.DataBind();
        }

        protected void rptDocumentos_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int documentoId = Convert.ToInt32(e.CommandArgument);
            try
            {
                ObraDocumento d = ObraDAO.ObterDocumento(documentoId);
                if (d == null) { MensagemErro("Documento não encontrado."); return; }

                if (e.CommandName == "Baixar")
                {
                    if (!Arquivos.Baixar(d.CaminhoArquivo, d.NomeOriginal, d.ContentType))
                        MensagemErro("O arquivo não foi encontrado no servidor.");
                }
                else if (e.CommandName == "Remover")
                {
                    if (!PodeEditar) { ErroForm(lblErroForm, "Seu perfil não tem permissão para alterar dados."); return; }
                    ObraDAO.ExcluirDocumento(documentoId);
                    Arquivos.Apagar(d.CaminhoArquivo);
                    CarregarDocumentosForm(d.ObraId);
                }
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
