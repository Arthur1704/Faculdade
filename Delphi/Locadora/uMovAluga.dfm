object fAluga: TfAluga
  Left = 0
  Top = 0
  Caption = 'Alugar Carro'
  ClientHeight = 320
  ClientWidth = 497
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -12
  Font.Name = 'Segoe UI'
  Font.Style = []
  TextHeight = 15
  object Panel1: TPanel
    Left = 0
    Top = 0
    Width = 497
    Height = 320
    Align = alClient
    TabOrder = 0
    object Label1: TLabel
      Left = 269
      Top = 102
      Width = 38
      Height = 15
      Caption = 'Alugar:'
    end
    object Label2: TLabel
      Left = 24
      Top = 102
      Width = 44
      Height = 15
      Caption = 'Modelo:'
    end
    object Label3: TLabel
      Left = 152
      Top = 24
      Width = 208
      Height = 50
      Caption = 'Alugar Carro'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -37
      Font.Name = 'Segoe UI'
      Font.Style = []
      ParentFont = False
    end
    object Edit1: TEdit
      Left = 319
      Top = 99
      Width = 121
      Height = 23
      TabOrder = 0
    end
    object Button1: TButton
      Left = 224
      Top = 280
      Width = 75
      Height = 25
      Caption = 'Alugar'
      TabOrder = 1
      OnClick = Button1Click
    end
    object Edit2: TEdit
      Left = 74
      Top = 99
      Width = 121
      Height = 23
      TabOrder = 2
    end
    object StringGrid1: TStringGrid
      Left = 101
      Top = 146
      Width = 332
      Height = 111
      RowCount = 4
      TabOrder = 3
    end
  end
end
