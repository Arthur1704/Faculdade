object fCadProf: TfCadProf
  Left = 0
  Top = 0
  Caption = 'Cadastrar Profissional'
  ClientHeight = 338
  ClientWidth = 584
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
    Width = 584
    Height = 338
    Align = alClient
    TabOrder = 0
    ExplicitLeft = 8
    ExplicitTop = -8
    object Label1: TLabel
      Left = 24
      Top = 99
      Width = 131
      Height = 21
      Caption = 'Nome Profissional:'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -16
      Font.Name = 'Segoe UI'
      Font.Style = []
      ParentFont = False
    end
    object Label2: TLabel
      Left = 24
      Top = 148
      Width = 30
      Height = 21
      Caption = 'CPF:'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -16
      Font.Name = 'Segoe UI'
      Font.Style = []
      ParentFont = False
    end
    object Label3: TLabel
      Left = 112
      Top = 24
      Width = 356
      Height = 50
      Caption = 'Cadastrar Profissional'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -37
      Font.Name = 'Segoe UI'
      Font.Style = []
      ParentFont = False
    end
    object Label4: TLabel
      Left = 24
      Top = 195
      Width = 67
      Height = 21
      Caption = 'Endere'#231'o:'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -16
      Font.Name = 'Segoe UI'
      Font.Style = []
      ParentFont = False
    end
    object eNome: TEdit
      Left = 178
      Top = 101
      Width = 137
      Height = 29
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -16
      Font.Name = 'Segoe UI'
      Font.Style = []
      ParentFont = False
      TabOrder = 0
    end
    object Button1: TButton
      Left = 240
      Top = 272
      Width = 121
      Height = 41
      Caption = 'Cadastrar'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -16
      Font.Name = 'Segoe UI'
      Font.Style = []
      ParentFont = False
      TabOrder = 1
      OnClick = Button1Click
    end
    object eCPF: TEdit
      Left = 178
      Top = 197
      Width = 137
      Height = 29
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -16
      Font.Name = 'Segoe UI'
      Font.Style = []
      ParentFont = False
      TabOrder = 2
    end
    object RadioGroup1: TRadioGroup
      Left = 376
      Top = 101
      Width = 185
      Height = 105
      Caption = 'Sexo:'
      DefaultHeaderFont = False
      HeaderFont.Charset = DEFAULT_CHARSET
      HeaderFont.Color = clWindowText
      HeaderFont.Height = -16
      HeaderFont.Name = 'Segoe UI'
      HeaderFont.Style = []
      Items.Strings = (
        'Masculino'
        'Feminino')
      TabOrder = 3
    end
    object MaskEdit1: TMaskEdit
      Left = 178
      Top = 150
      Width = 137
      Height = 29
      EditMask = '999.999.999-99'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -16
      Font.Name = 'Segoe UI'
      Font.Style = []
      MaxLength = 14
      ParentFont = False
      TabOrder = 4
      Text = '   .   .   -  '
    end
  end
end
