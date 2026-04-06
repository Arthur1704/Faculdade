object frmSistema: TfrmSistema
  Left = 192
  Top = 125
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
  PixelsPerInch = 96
  TextHeight = 13
  object Panel1: TPanel
    Left = 0
    Top = 0
    Width = 1289
    Height = 697
    TabOrder = 0
    object Label1: TLabel
      Left = 64
      Top = 136
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
      Top = 40
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
      Left = 64
      Top = 384
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
      Left = 480
      Top = 176
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
      Left = 480
      Top = 264
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
      Left = 64
      Top = 176
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
      Left = 64
      Top = 240
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
      Left = 64
      Top = 416
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
      Left = 480
      Top = 216
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
      Left = 480
      Top = 296
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
      Left = 392
      Top = 560
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
    end
  end
end
