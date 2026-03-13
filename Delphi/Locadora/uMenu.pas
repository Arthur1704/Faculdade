unit uMenu;

interface

uses
  Winapi.Windows, Winapi.Messages, System.SysUtils, System.Variants, System.Classes, Vcl.Graphics,
  Vcl.Controls, Vcl.Forms, Vcl.Dialogs, Vcl.Menus,
  uCliente, uVeiculo, uRelaVeiculos, uLocados, uDevolucao, uLocacao;

type
  TfrmMenu = class(TForm)
    MainMenu1: TMainMenu;
    Cadastro1: TMenuItem;
    Movimento1: TMenuItem;
    Relatorio1: TMenuItem;
    Locao1: TMenuItem;
    Devoluo1: TMenuItem;
    Locados1: TMenuItem;
    Veiculos1: TMenuItem;
    Veiculo1: TMenuItem;
    Cliente1: TMenuItem;
    procedure Cliente1Click(Sender: TObject);
    procedure Veiculo1Click(Sender: TObject);
    procedure Locao1Click(Sender: TObject);
    procedure Devoluo1Click(Sender: TObject);
    procedure Locados1Click(Sender: TObject);
    procedure Veiculos1Click(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  frmMenu: TfrmMenu;

implementation

{$R *.dfm}

procedure TfrmMenu.Cliente1Click(Sender: TObject);
begin
    if (frmCliente = Nil) then
    begin
        frmCliente := TfrmCliente.Create(self);
        frmCliente.showModal;
        FreeAndNil(frmCliente);
    end;
end;

procedure TfrmMenu.Devoluo1Click(Sender: TObject);
begin
    if (frmDevolucao = Nil) then
    begin
        frmDevolucao := TfrmDevolucao.Create(self);
        frmDevolucao.showModal;
        FreeAndNil(frmDevolucao);
    end;
end;

procedure TfrmMenu.Locados1Click(Sender: TObject);
begin
    if (frmLocados = Nil) then
    begin
        frmLocados := TfrmLocados.Create(self);
        frmLocados.showModal;
        FreeAndNil(frmLocados);
    end;
end;

procedure TfrmMenu.Locao1Click(Sender: TObject);
begin
     if (frmLocacao = Nil) then
    begin
        frmLocacao := TfrmLocacao.Create(self);
        frmLocacao.showModal;
        FreeAndNil(frmLocacao);
    end;
end;

procedure TfrmMenu.Veiculo1Click(Sender: TObject);
begin
    if (frmVeiculo = Nil) then
    begin
        frmVeiculo := TfrmVeiculo.Create(self);
        frmVeiculo.showModal;
        FreeAndNil(frmVeiculo);
    end;
end;

procedure TfrmMenu.Veiculos1Click(Sender: TObject);
begin
    if (frmRelaVeiculo = Nil) then
    begin
        frmRelaVeiculo := TfrmRelaVeiculo.Create(self);
        frmRelaVeiculo.showModal;
        FreeAndNil(frmRelaVeiculo);
    end;
end;

end.
