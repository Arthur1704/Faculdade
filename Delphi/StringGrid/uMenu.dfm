object Form1: TForm1
  Left = 192
  Top = 117
  Width = 1045
  Height = 550
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
  object Panel1: TPanel
    Left = 0
    Top = 0
    Width = 1029
    Height = 511
    Align = alClient
    TabOrder = 0
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
    object edtNome: TEdit
      Left = 192
      Top = 32
      Width = 241
      Height = 21
      TabOrder = 0
    end
    object edtEndereco: TEdit
      Left = 192
      Top = 96
      Width = 241
      Height = 21
      TabOrder = 1
    end
    object grid1: TStringGrid
      Left = 136
      Top = 144
      Width = 377
      Height = 281
      ColCount = 3
      RowCount = 1
      FixedRows = 0
      TabOrder = 2
      OnClick = grid1Click
      ColWidths = (
        64
        64
        141)
    end
    object btnNovo: TButton
      Left = 712
      Top = 56
      Width = 107
      Height = 49
      Caption = 'Novo'
      TabOrder = 3
      OnClick = btnNovoClick
    end
    object btnAtualizar: TButton
      Left = 712
      Top = 152
      Width = 107
      Height = 49
      Caption = 'Atualizar'
      TabOrder = 4
      OnClick = btnAtualizarClick
    end
    object btnDeletar: TButton
      Left = 712
      Top = 240
      Width = 107
      Height = 49
      Caption = 'Deletar'
      TabOrder = 5
      OnClick = btnDeletarClick
    end
    object btnCancelar: TButton
      Left = 608
      Top = 368
      Width = 153
      Height = 97
      Caption = 'Cancelar'
      TabOrder = 6
      OnClick = btnCancelarClick
    end
    object btnSalvar: TButton
      Left = 816
      Top = 368
      Width = 153
      Height = 97
      Caption = 'Salvar'
      TabOrder = 7
      OnClick = btnSalvarClick
    end
  end
end
