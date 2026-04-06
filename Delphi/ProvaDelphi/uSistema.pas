unit uSistema;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, ExtCtrls, StdCtrls, Mask;

type
  TfrmSistema = class(TForm)
    Panel1: TPanel;
    Label1: TLabel;
    Label2: TLabel;
    edtServico: TEdit;
    rgUrgencia: TRadioGroup;
    lbSituacao: TListBox;
    Label3: TLabel;
    Label4: TLabel;
    Label5: TLabel;
    edtNomeCliente: TEdit;
    medtCpf: TMaskEdit;
    btnSalvar: TButton;
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  frmSistema: TfrmSistema;

implementation

procedure TfrmSistema.salvar(servico : String)

{$R *.dfm}

end.
