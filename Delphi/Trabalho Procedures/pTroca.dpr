program pTroca;

uses
  Vcl.Forms,
  uMenu in 'uMenu.pas' {frmMenu},
  uProcedures in 'uProcedures.pas';

{$R *.res}

begin
  Application.Initialize;
  Application.MainFormOnTaskbar := True;
  Application.CreateForm(TfrmMenu, frmMenu);
  Application.Run;
end.
