unit uMovAluga;

interface

uses
  Winapi.Windows, Winapi.Messages, System.SysUtils, System.Variants, System.Classes, Vcl.Graphics,
  Vcl.Controls, Vcl.Forms, Vcl.Dialogs, Vcl.StdCtrls, Vcl.ExtCtrls, Vcl.Grids;

type
  TfAluga = class(TForm)
    Panel1: TPanel;
    Edit1: TEdit;
    Label1: TLabel;
    Button1: TButton;
    Label2: TLabel;
    Edit2: TEdit;
    Label3: TLabel;
    StringGrid1: TStringGrid;
    procedure Button1Click(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  fAluga: TfAluga;

implementation

{$R *.dfm}

procedure TfAluga.Button1Click(Sender: TObject);
begin
  ShowMessage('Carro alugado: ' + Edit1.Text);
end;

end.
