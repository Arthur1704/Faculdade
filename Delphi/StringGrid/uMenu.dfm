object Form1: TForm1
  Left = 192
  Top = 117
  Width = 1305
  Height = 675
  Caption = 'Form1'
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'MS Sans Serif'
  Font.Style = []
  OldCreateOrder = False
  OnCreate = FormCreate
  PixelsPerInch = 96
  TextHeight = 13
  object Label1: TLabel
    Left = 192
    Top = 16
    Width = 34
    Height = 13
    Caption = 'Nome: '
  end
  object Label2: TLabel
    Left = 192
    Top = 72
    Width = 52
    Height = 13
    Caption = 'Endere'#231'o: '
  end
  object grid1: TStringGrid
    Left = 136
    Top = 144
    Width = 681
    Height = 361
    ColCount = 3
    RowCount = 1
    FixedRows = 0
    TabOrder = 0
    OnClick = grid1Click
    ColWidths = (
      64
      64
      141)
  end
  object Edit1: TEdit
    Left = 192
    Top = 40
    Width = 169
    Height = 21
    TabOrder = 1
    Text = 'Edit1'
  end
  object Edit2: TEdit
    Left = 192
    Top = 96
    Width = 169
    Height = 21
    TabOrder = 2
    Text = 'Edit2'
  end
  object btnNovo: TButton
    Left = 1000
    Top = 40
    Width = 107
    Height = 49
    Caption = 'Novo'
    TabOrder = 3
    OnClick = btnNovoClick
  end
end
