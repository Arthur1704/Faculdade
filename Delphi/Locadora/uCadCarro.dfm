object fCadCarro: TfCadCarro
  Left = 0
  Top = 0
  Caption = 'Cadastrar Carro'
  ClientHeight = 339
  ClientWidth = 553
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
    Width = 553
    Height = 339
    Align = alClient
    TabOrder = 0
    ExplicitLeft = 8
    object Label1: TLabel
      Left = 32
      Top = 136
      Width = 44
      Height = 15
      Caption = 'Modelo:'
    end
    object Label2: TLabel
      Left = 32
      Top = 192
      Width = 31
      Height = 15
      Caption = 'Placa:'
    end
    object Label3: TLabel
      Left = 128
      Top = 16
      Width = 298
      Height = 50
      Caption = 'Cadastro de Carro'
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -37
      Font.Name = 'Segoe UI'
      Font.Style = []
      ParentFont = False
    end
    object Label4: TLabel
      Left = 32
      Top = 237
      Width = 48
      Height = 15
      Caption = 'Situa'#231#227'o:'
    end
    object eCarro: TEdit
      Left = 96
      Top = 133
      Width = 145
      Height = 23
      TabOrder = 0
    end
    object ePlaca: TEdit
      Left = 96
      Top = 184
      Width = 145
      Height = 23
      TabOrder = 1
    end
    object Button1: TButton
      Left = 232
      Top = 288
      Width = 105
      Height = 33
      Caption = 'Cadastrar'
      TabOrder = 2
      OnClick = Button1Click
    end
    object ComboBox1: TComboBox
      Left = 96
      Top = 229
      Width = 145
      Height = 23
      TabOrder = 3
      Text = 'Situa'#231#227'o do Carro'
      Items.Strings = (
        'Alugado'
        'Disponivel'
        'Manuten'#231#227'o')
    end
    object RadioGroup1: TRadioGroup
      Left = 320
      Top = 117
      Width = 185
      Height = 105
      Caption = 'Marcas: '
      Items.Strings = (
        'Porsche'
        'Chevrolet'
        'Volkswagen'
        'Fiat')
      TabOrder = 4
    end
  end
end
