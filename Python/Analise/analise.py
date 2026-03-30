import pandas as pan
import numpy as nu
dados = pan.read_excel("Dados_alunos.xlsx")

lista_generos = dados['genero'].unique()
quant_genero = len(lista_generos)

lista_numeros_gen = nu.arange(quant_genero)

dicionario_genero = dict(zip(lista_generos, lista_numeros_gen))

dados['genero_num'] = dados['genero'].map(dicionario_genero)


lista_linguagens = dados['linguagem de programação preferida'].unique()
quant_linguagens = len(lista_linguagens)

lista_numeros_lin = nu.arange(quant_linguagens)

dicionario_lin = dict(zip(lista_linguagens, lista_numeros_lin))

dados['linguagens_num'] = dados['linguagem de programação preferida'].map(dicionario_lin)

print(dados.head())




