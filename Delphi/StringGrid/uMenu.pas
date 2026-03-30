unit uMenu;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, Grids, ExtCtrls;

type
  TForm1 = class(TForm)
    Panel1: TPanel;
    Label1: TLabel;
    edtNome: TEdit;
    edtEndereco: TEdit;
    Label2: TLabel;
    grid1: TStringGrid;
    btnNovo: TButton;
    btnAtualizar: TButton;
    btnDeletar: TButton;
    btnCancelar: TButton;
    btnSalvar: TButton;
    procedure FormCreate(Sender: TObject);
    procedure btnNovoClick(Sender: TObject);
    procedure grid1Click(Sender: TObject);
    procedure btnSalvarClick(Sender: TObject);
    procedure btnAtualizarClick(Sender: TObject);
  private
    procedure estadoLiberado;
    procedure estadoBloqueado;
    procedure salvar;
    procedure atualizar;
  public

  end;

var
  Form1: TForm1;
  cont : Integer;

implementation

{$R *.dfm}

procedure TForm1.salvar;
begin
  grid1.Cells[1,grid1.RowCount] := edtNome.Text;
  grid1.Cells[2,grid1.RowCount] := edtEndereco.Text;
  cont := cont + 1;
  grid1.RowCount := grid1.RowCount + 1;
  grid1.FixedRows := 1;
  grid1.Cells[0,grid1.RowCount] := intToStr(cont);
end;

procedure TForm1.atualizar;
begin
   grid1.Cells[1,grid1.Row] := edtNome.Text;
  grid1.Cells[2,grid1.Row] := edtEndereco.Text;
end;

procedure Tform1.estadoLiberado;
begin
  edtNome.Enabled := True;
  edtEndereco.Enabled := True;
  btnAtualizar.Enabled := True;
  btnDeletar.Enabled := True;
  btnSalvar.Enabled := True;
end;

procedure Tform1.estadoBloqueado;
begin
  edtNome.Enabled := False;
  edtEndereco.Enabled := False;
  btnAtualizar.Enabled := False;
  btnDeletar.Enabled := False;
  btnSalvar.Enabled := False;
end;



procedure TForm1.FormCreate(Sender: TObject);
begin
  grid1.Cells[1,0] := 'Nome';
  grid1.Cells[2,0] := 'Endereço';
  grid1.Cells[0,0] := 'Id';
  edtNome.Enabled := False;
  edtEndereco.Enabled := False;
  btnAtualizar.Enabled := False;
  btnDeletar.Enabled := False;
  btnSalvar.Enabled := False;
  cont := 1;
  grid1.Cells[0,1] := intToStr(cont);
end;

procedure TForm1.btnNovoClick(Sender: TObject);
begin
  edtNome.Enabled := True;
  edtEndereco.Enabled := True;
  btnSalvar.Enabled := True;
end;


procedure TForm1.grid1Click(Sender: TObject);
begin
  if (grid1.RowCount > 1) then
  begin
   //showMessage(intToStr(grid1.Row));
   btnAtualizar.Enabled := True;
   btnDeletar.Enabled := True;
   btnSalvar.Enabled := True;
  end;
end;

procedure TForm1.btnSalvarClick(Sender: TObject);
begin
  if (edtNome.Text <> '') and (edtEndereco.Text <> '') then
    salvar()
  else
    ShowMessage('Não é possivel inserir com valor em branco');
end;

procedure TForm1.btnAtualizarClick(Sender: TObject);
begin
  if (edtNome.Text <> '') and (edtEndereco.Text <> '') then
    atualizar()
  else
    ShowMessage('Não é possivel atualizar com valor em branco');
end;

end.
