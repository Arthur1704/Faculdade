import pandas as pan
import numpy as nu

dados = pan.read_excel("Dados_alunos.xlsx")

dados['genero'] = dados['genero'].str.upper()
lista_generos = dados['genero'].unique()
quant_genero = len(lista_generos)

lista_numeros_gen = nu.arange(quant_genero)

dicionario_genero = dict(zip(lista_generos, lista_numeros_gen))

dados['genero_num'] = dados['genero'].map(dicionario_genero)

dados['linguagem de programação preferida'] =  dados['linguagem de programação preferida'].str.upper()
lista_linguagens = dados['linguagem de programação preferida'].unique()
quant_linguagens = len(lista_linguagens)

lista_numeros_lin = nu.arange(quant_linguagens)

dicionario_lin = dict(zip(lista_linguagens, lista_numeros_lin))

dados['linguagens_num'] = dados['linguagem de programação preferida'].map(dicionario_lin)

#print(dados.head())

dados['esporte preferido'] = dados['esporte preferido'].str.upper()
lista_esportes = dados['esporte preferido'].unique()
quant_esportes = len(lista_esportes)

lista_numeros_esportes = nu.arange(quant_esportes)

dicionario_espor = dict(zip(lista_esportes, lista_numeros_esportes))

dados['esportes_num'] = dados['esporte preferido'].map(dicionario_espor)

#print(dados.head())

dados['trabalha?'] = dados['trabalha?'].str.upper()
lista_trabalha = dados['trabalha?'].unique()
quant_trabalha = len(lista_trabalha)

lista_num_trabalha = nu.arange(quant_trabalha)
dicionario_trabalha = dict(zip(lista_trabalha, lista_num_trabalha))

dados['trabalha_num'] = dados['trabalha?'].map(dicionario_trabalha)


#print(dados.head())

dados['Gosta filme?'] = dados['Gosta filme?'].str.upper()
lista_filme = dados['Gosta filme?'].unique()
quant_filme = len(lista_filme)

lista_num_filme = nu.arange(quant_filme)
dicionaro_filme = dict(zip(lista_filme, lista_num_filme))

dados['gostaFilme_num'] = dados['Gosta filme?'].map(dicionaro_filme)

#print(dados.head())

dados['Gosta série?'] = dados['Gosta série?'].str.upper()
lista_serie = dados['Gosta série?'].unique()
quant_serie = len(lista_serie)

lista_num_serie = nu.arange(quant_serie)
dicionaro_serie = dict(zip(lista_serie, lista_num_serie))

dados['gostaSerie_num'] = dados['Gosta série?'].map(dicionaro_serie)

#print(dados.head())

dados['estilo musical'] = dados['estilo musical'].str.upper()
lista_Musica = dados['estilo musical'].unique()
quant_musica = len(lista_Musica)

lista_num_musica = nu.arange(quant_musica)
dicionario_musica = dict(zip(lista_Musica, lista_num_musica))

dados['estiloMusica_num'] = dados['estilo musical'].map(dicionario_musica)

#print(dados.head())

dados['Jogos digitais?'] = dados['Jogos digitais?'].str.upper()
lista_jogos = dados['Jogos digitais?'].unique()
quant_jogos = len(lista_jogos)

lista_num_jogos = nu.arange(quant_jogos)
dicionario_jogos = dict(zip(lista_jogos, lista_num_jogos))

dados['jogosDigitais_num'] = dados['Jogos digitais?'].map(dicionario_jogos)

print(dados[['idade',
             'genero_num',
             'linguagens_num',
             'horas de sono',
             'horas de estudo',
             'horas uso celular',
             'esportes_num',
             'trabalha_num',
             'gostaFilme_num',
             'gostaSerie_num',
             'estiloMusica_num',
             'jogosDigitais_num']])


print(dados.groupby('horas de sono')['horas uso celular'].mean())

print(round(dados['linguagem de programação preferida'].value_counts(),2))
print(dados['esporte preferido'].value_counts())
print(dados['estilo musical'].value_counts())
print(f"Media de sono da sala: {round(dados['horas de sono'].mean(),2)} horas")
print(f"Media de horas no selulas da sala: {round(dados['horas uso celular'].mean(),2)} horas")
