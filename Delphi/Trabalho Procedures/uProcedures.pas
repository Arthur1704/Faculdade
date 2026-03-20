unit uProcedures;

interface

procedure trocar (var num1 : Integer;var num2 : Integer);

implementation

procedure trocar (var num1 : Integer;var num2 : Integer);
var  aux : Integer;
begin
  aux := num1;
  num1 := num2;
  num2 := aux;
end;

end.
