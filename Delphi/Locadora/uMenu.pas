unit uMenu;

interface

uses
  Winapi.Windows, Winapi.Messages, System.SysUtils, System.Variants, System.Classes, Vcl.Graphics,
  Vcl.Controls, Vcl.Forms, Vcl.Dialogs, Vcl.Menus, Vcl.StdCtrls, Vcl.ExtCtrls;

type
  TfMenu = class(TForm)
    Panel1: TPanel;
    Label1: TLabel;
    MainMenu1: TMainMenu;
    Cadastro1: TMenuItem;
    Movimento1: TMenuItem;
    Carro1: TMenuItem;
    Carro2: TMenuItem;
    Alugarcarro1: TMenuItem;
    procedure Carro1Click(Sender: TObject);
    procedure Carro2Click(Sender: TObject);
    procedure Alugarcarro1Click(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  fMenu: TfMenu;

implementation

{$R *.dfm}

uses uCadCarro, uCadProf, uMovAluga;

procedure TfMenu.Alugarcarro1Click(Sender: TObject);
begin
  if (fAluga = Nil) then
  begin
    fAluga := TfAluga.Create(self);
    fAluga.ShowModal;
    FreeAndNil(fCadCarro);
  end;
end;

procedure TfMenu.Carro1Click(Sender: TObject);
begin
  if (fCadCarro = Nil) then
  begin
    fCadCarro := TfCadCarro.Create(self);
    fCadCarro.ShowModal;
    FreeAndNil(fCadCarro);
  end;
end;

procedure TfMenu.Carro2Click(Sender: TObject);
begin
  if (fCadProf = Nil) then
  begin
    fCadProf := TfCadProf.Create(self);
    fCadProf.ShowModal;
    FreeAndNil(fCadProf);
  end;
end;

end.
