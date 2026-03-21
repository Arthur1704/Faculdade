object frmMenu: TfrmMenu
  Left = 0
  Top = 0
  Caption = 'Menu'
  ClientHeight = 441
  ClientWidth = 624
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -12
  Font.Name = 'Segoe UI'
  Font.Style = []
  TextHeight = 15
  object Panel1: TPanel
    Left = -1
    Top = -8
    Width = 626
    Height = 449
    Color = clGradientInactiveCaption
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -16
    Font.Name = 'Segoe UI'
    Font.Style = []
    ParentBackground = False
    ParentFont = False
    TabOrder = 0
    object Label1: TLabel
      Left = 64
      Top = 72
      Width = 74
      Height = 21
      Caption = 'Numero 1:'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -16
      Font.Name = 'Segoe UI'
      Font.Style = []
      ParentFont = False
    end
    object Label2: TLabel
      Left = 64
      Top = 120
      Width = 74
      Height = 21
      Caption = 'Numero 2:'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -16
      Font.Name = 'Segoe UI'
      Font.Style = []
      ParentFont = False
    end
    object Label3: TLabel
      Left = 80
      Top = 272
      Width = 74
      Height = 21
      Caption = 'Numero 1:'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -16
      Font.Name = 'Segoe UI'
      Font.Style = []
      ParentFont = False
    end
    object Label4: TLabel
      Left = 80
      Top = 312
      Width = 74
      Height = 21
      Caption = 'Numero 2:'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -16
      Font.Name = 'Segoe UI'
      Font.Style = []
      ParentFont = False
    end
    object Label5: TLabel
      Left = 80
      Top = 240
      Width = 131
      Height = 21
      Caption = 'Numeros Trocados'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -16
      Font.Name = 'Segoe UI'
      Font.Style = []
      ParentFont = False
    end
    object lblNum1: TLabel
      Left = 192
      Top = 272
      Width = 4
      Height = 21
    end
    object lblNum2: TLabel
      Left = 192
      Top = 312
      Width = 4
      Height = 21
    end
    object Label6: TLabel
      Left = 368
      Top = 72
      Width = 74
      Height = 21
      Caption = 'Numero 3:'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -16
      Font.Name = 'Segoe UI'
      Font.Style = []
      ParentFont = False
    end
    object Label7: TLabel
      Left = 368
      Top = 240
      Width = 146
      Height = 21
      Caption = 'Numeros Ordenados'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -16
      Font.Name = 'Segoe UI'
      Font.Style = []
      ParentFont = False
    end
    object Label8: TLabel
      Left = 312
      Top = 288
      Width = 74
      Height = 21
      Caption = 'Numero 1:'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -16
      Font.Name = 'Segoe UI'
      Font.Style = []
      ParentFont = False
    end
    object Label10: TLabel
      Left = 312
      Top = 322
      Width = 74
      Height = 21
      Caption = 'Numero 2:'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -16
      Font.Name = 'Segoe UI'
      Font.Style = []
      ParentFont = False
    end
    object Label11: TLabel
      Left = 312
      Top = 359
      Width = 74
      Height = 21
      Caption = 'Numero 3:'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -16
      Font.Name = 'Segoe UI'
      Font.Style = []
      ParentFont = False
    end
    object lblOrdenar1: TLabel
      Left = 403
      Top = 288
      Width = 4
      Height = 21
    end
    object lblOrdenar2: TLabel
      Left = 403
      Top = 322
      Width = 4
      Height = 21
    end
    object lblOrdenar3: TLabel
      Left = 403
      Top = 359
      Width = 4
      Height = 21
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -16
      Font.Name = 'Segoe UI'
      Font.Style = []
      ParentFont = False
    end
    object edtNum1: TEdit
      Left = 192
      Top = 69
      Width = 121
      Height = 29
      TabOrder = 0
    end
    object edtNum2: TEdit
      Left = 192
      Top = 117
      Width = 121
      Height = 29
      TabOrder = 1
    end
    object btnTrocar: TButton
      Left = 153
      Top = 392
      Width = 75
      Height = 25
      Caption = 'Trocar'
      TabOrder = 2
      OnClick = btnTrocarClick
    end
    object btnOrdenar: TButton
      Left = 403
      Top = 392
      Width = 75
      Height = 25
      Caption = 'Ordenar'
      TabOrder = 3
      OnClick = btnOrdenarClick
    end
    object edtNum3: TEdit
      Left = 456
      Top = 69
      Width = 121
      Height = 29
      TabOrder = 4
    end
  end
end
