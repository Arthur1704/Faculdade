program pLocadora;

uses
  Vcl.Forms,
  uMenu in 'uMenu.pas' {fMenu},
  uMovAluga in 'uMovAluga.pas' {fAluga},
  uCadCarro in 'uCadCarro.pas' {fCadCarro},
  uCadProf in 'uCadProf.pas' {fCadProf},
  uCompCarro in 'uCompCarro.pas' {fCompCarro};

{$R *.res}

begin
  Application.Initialize;
  Application.MainFormOnTaskbar := True;
  Application.CreateForm(TfMenu, fMenu);
  Application.CreateForm(TfCompCarro, fCompCarro);
  Application.Run;
end.
