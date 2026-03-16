program pCalculadora;

uses
  Vcl.Forms,
  uMenu in 'uMenu.pas' {frmMenu},
  uRotina in 'uRotina.pas',
  uRotinaN in 'uRotinaN.pas';

{$R *.res}

begin
  Application.Initialize;
  Application.MainFormOnTaskbar := True;
  Application.CreateForm(TfrmMenu, frmMenu);
  Application.Run;
end.
