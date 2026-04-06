unit uMenu;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, ExtCtrls, StdCtrls;

type
  TfrmMenu = class(TForm)
    Panel1: TPanel;
    Label1: TLabel;
    Label2: TLabel;
    Label3: TLabel;
    edtUsuario: TEdit;
    edtSenha: TEdit;
    btnLogar: TButton;
    procedure FormCreate(Sender: TObject);
    procedure btnLogarClick(Sender: TObject);
  private
    usuario : String;
    senha: String;
    function logar(user: String; pass: String): Boolean;
  public
    { Public declarations }
  end;

var
  frmMenu: TfrmMenu;

implementation

uses uSistema;

function TfrmMenu.logar (user : String; pass : String): Boolean;
 begin
    if (user = Self.usuario) and (pass = Self.senha) then
      result := true
    else
      result := false;
 end;

{$R *.dfm}

procedure TfrmMenu.FormCreate(Sender: TObject);
begin
  usuario := 'admin';
  senha := 'admin';
end;

procedure TfrmMenu.btnLogarClick(Sender: TObject);
begin
  if logar(edtUsuario.Text, edtSenha.Text) then
    begin
      frmSistema := TfrmSistema.Create(Self);
      frmSistema.ShowModal;
      FreeAndNil(frmSistema);
    end
  else
   MessageDlg('Dados invalidos',mtInformation,[mbOk],0);

end;

end.
