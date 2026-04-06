object frmSistema: TfrmSistema
  Left = 183
  Top = 122
  Width = 857
  Height = 749
  Caption = 'Sistema'
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
  object Panel1: TPanel
    Left = 0
    Top = 0
    Width = 841
    Height = 710
    Align = alClient
    TabOrder = 0
    object Label1: TLabel
      Left = 88
      Top = 80
      Width = 63
      Height = 24
      Caption = 'Servi'#231'o'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -19
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentFont = False
    end
    object Label2: TLabel
      Left = 264
      Top = 24
      Width = 312
      Height = 46
      Caption = 'Auto Torno Viana'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -40
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentFont = False
    end
    object Label3: TLabel
      Left = 504
      Top = 264
      Width = 72
      Height = 24
      Caption = 'Situa'#231'ao'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -19
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentFont = False
    end
    object Label4: TLabel
      Left = 504
      Top = 88
      Width = 115
      Height = 24
      Caption = 'Nome Cliente'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -19
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentFont = False
    end
    object Label5: TLabel
      Left = 504
      Top = 176
      Width = 28
      Height = 24
      Caption = 'Cpf'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -19
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentFont = False
    end
    object edtServico: TEdit
      Left = 88
      Top = 120
      Width = 169
      Height = 28
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -16
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentFont = False
      TabOrder = 0
    end
    object rgUrgencia: TRadioGroup
      Left = 88
      Top = 184
      Width = 185
      Height = 105
      Caption = 'Urgencia'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -16
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      Items.Strings = (
        'Alta'
        'Media'
        'Baixa')
      ParentFont = False
      TabOrder = 1
    end
    object lbSituacao: TListBox
      Left = 504
      Top = 296
      Width = 169
      Height = 105
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -16
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ItemHeight = 20
      Items.Strings = (
        'Pendente'
        'Em andamento'
        'Em espera'
        'Concluido')
      ParentFont = False
      TabOrder = 2
    end
    object edtNomeCliente: TEdit
      Left = 504
      Top = 128
      Width = 161
      Height = 28
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -16
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentFont = False
      TabOrder = 3
    end
    object medtCpf: TMaskEdit
      Left = 504
      Top = 208
      Width = 161
      Height = 28
      EditMask = '999.999.999-99;1;_'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -16
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      MaxLength = 14
      ParentFont = False
      TabOrder = 4
      Text = '   .   .   -  '
    end
    object btnSalvar: TButton
      Left = 384
      Top = 416
      Width = 75
      Height = 25
      Caption = 'Salvar'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -16
      Font.Name = 'MS Sans Serif'
      Font.Style = []
      ParentFont = False
      TabOrder = 5
      OnClick = btnSalvarClick
    end
    object sgDados: TStringGrid
      Left = 200
      Top = 464
      Width = 457
      Height = 201
      ColCount = 6
      RowCount = 1
      FixedRows = 0
      TabOrder = 6
    end
  end
end
