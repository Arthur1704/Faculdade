program pProva;

uses
  Forms,
  uMenu in 'uMenu.pas' {frmMenu},
  uSistema in 'uSistema.pas' {frmSistema};

{$R *.res}

begin
  Application.Initialize;
  Application.CreateForm(TfrmMenu, frmMenu);
  Application.CreateForm(TfrmSistema, frmSistema);
  Application.Run;
end.
