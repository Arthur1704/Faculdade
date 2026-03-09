object frmMenu: TfrmMenu
  Left = 0
  Top = 0
  Caption = 'Locadora de Veiculos'
  ClientHeight = 441
  ClientWidth = 624
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -12
  Font.Name = 'Segoe UI'
  Font.Style = []
  Menu = MainMenu1
  TextHeight = 15
  object MainMenu1: TMainMenu
    Left = 576
    Top = 8
    object Cadastro1: TMenuItem
      Caption = 'Cadastro'
      object Veiculo1: TMenuItem
        Caption = 'Veiculo'
        OnClick = Veiculo1Click
      end
      object Cliente1: TMenuItem
        Caption = 'Cliente'
        OnClick = Cliente1Click
      end
    end
    object Movimento1: TMenuItem
      Caption = 'Movimento'
      object Locao1: TMenuItem
        Caption = 'Loca'#231#227'o'
        OnClick = Locao1Click
      end
      object Devoluo1: TMenuItem
        Caption = 'Devolu'#231#227'o'
        OnClick = Devoluo1Click
      end
    end
    object Relatorio1: TMenuItem
      Caption = 'Relatorio'
      object Locados1: TMenuItem
        Caption = 'Locados'
        OnClick = Locados1Click
      end
      object Veiculos1: TMenuItem
        Caption = 'Veiculos'
        OnClick = Veiculos1Click
      end
    end
  end
end
