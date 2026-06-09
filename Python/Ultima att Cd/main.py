#pip install pandas
#pip install matplotlib
#pip install seaborn
#pip install scikit-learn

import pandas as pd
import numpy as np
import matplotlib.pyplot as plt
import seaborn as sns

from sklearn.model_selection import train_test_split
from sklearn.naive_bayes import GaussianNB
from sklearn.ensemble import RandomForestClassifier
from sklearn.metrics import accuracy_score

df = pd.read_csv('dataset_delivery_ml.csv')
# read_csv() -> lê um arquivo CSV

print(df.shape)
# shape -> retorna (linhas, colunas)

print(df.head())
# head() -> mostra as primeiras linhas

print(df.info())
# info() -> mostra tipos de dados e valores nulos

# ============================
# ANÁLISE DE NULOS
# ============================

print(df.isnull().sum())
# isnull() -> verifica valores nulos
# sum() -> soma a quantidade encontrada

# ============================
# DUPLICATAS
# ============================

print(df.duplicated().sum())
# duplicated() -> identifica registros repetidos

df = df.drop_duplicates()
# drop_duplicates() -> remove registros duplicados

# ============================
# PADRONIZAÇÃO DE TEXTO
# ============================

# forma_pagamento
df['forma_pagamento'] = df['forma_pagamento'].astype(str)
# astype(str) -> converte para string

df['forma_pagamento'] = df['forma_pagamento'].str.upper()
# upper() -> converte para MAIÚSCULO

df['forma_pagamento'] = df['forma_pagamento'].str.strip()
# strip() -> remove espaços extras


# regiao_entrega
df['regiao_entrega'] = df['regiao_entrega'].astype(str)
df['regiao_entrega'] = df['regiao_entrega'].str.upper()
df['regiao_entrega'] = df['regiao_entrega'].str.strip()


# status_pedido
df['status_pedido'] = df['status_pedido'].astype(str)
df['status_pedido'] = df['status_pedido'].str.upper()
df['status_pedido'] = df['status_pedido'].str.strip()


# complexidade_preparo
df['complexidade_preparo'] = df['complexidade_preparo'].astype(str)
df['complexidade_preparo'] = df['complexidade_preparo'].str.upper()
df['complexidade_preparo'] = df['complexidade_preparo'].str.strip()


# horario_pico
df['horario_pico'] = df['horario_pico'].astype(str)
df['horario_pico'] = df['horario_pico'].str.upper()
df['horario_pico'] = df['horario_pico'].str.strip()


# categoria_loja
df['categoria_loja'] = df['categoria_loja'].astype(str)
df['categoria_loja'] = df['categoria_loja'].str.upper()
df['categoria_loja'] = df['categoria_loja'].str.strip()


# cliente_gostou
df['cliente_gostou'] = df['cliente_gostou'].astype(str)
df['cliente_gostou'] = df['cliente_gostou'].str.upper()
df['cliente_gostou'] = df['cliente_gostou'].str.strip()

# ============================
# CONVERSÃO PARA NUMÉRICO
# ============================

df['tempo_entrega_min'] = pd.to_numeric(
    df['tempo_entrega_min'],
    errors='coerce'
)
# to_numeric() -> converte para número
# errors='coerce' -> valores inválidos viram NaN

df['distancia_km'] = pd.to_numeric(
    df['distancia_km'],
    errors='coerce'
)

df['valor_total'] = pd.to_numeric(
    df['valor_total'],
    errors='coerce'
)

df['valor_final'] = pd.to_numeric(
    df['valor_final'],
    errors='coerce'
)

df['taxa_entrega'] = pd.to_numeric(
    df['taxa_entrega'],
    errors='coerce'
)

df['desconto'] = pd.to_numeric(
    df['desconto'],
    errors='coerce'
)

# ============================
# TRATAMENTO DE NULOS
# ============================

df['tempo_entrega_min'] = df['tempo_entrega_min'].fillna(
    df['tempo_entrega_min'].mean()
)
# fillna() -> preenche valores nulos
# mean() -> calcula a média

df['forma_pagamento'] = df['forma_pagamento'].fillna(
    'DESCONHECIDO'
)

df['regiao_entrega'] = df['regiao_entrega'].fillna(
    'DESCONHECIDA'
)

# ============================
# CONVERSÃO DE TIPOS
# ============================

df['tempo_preparo_min'] = df['tempo_preparo_min'].astype(int)
# astype(int) -> converte para inteiro

df['tempo_entrega_min'] = df['tempo_entrega_min'].astype(float)
# astype(float) -> converte para decimal

df['distancia_km'] = df['distancia_km'].astype(float)

df['valor_total'] = df['valor_total'].astype(float)

# ============================
# TARGET (VARIÁVEL ALVO)
# ============================

objetivo = df['cliente_gostou']
# cliente_gostou -> variável que o modelo tentará prever

# ============================
# REMOÇÃO DE COLUNAS
# ============================

df_modelo = df.drop(
    columns=[
        'id_pedido',
        'data',
        'hora',
        'dia_semana',
        'loja',
        'produto'
    ]
)

# id_pedido -> identificador
# data -> data do pedido
# hora -> horário do pedido
# dia_semana -> dia da semana
# loja -> nome da loja
# produto -> nome do produto
#
# Essas colunas foram removidas por não agregarem valor
# ao treinamento do modelo.

# ============================
# DISCRETIZAÇÃO
# ============================

df_modelo['Faixa_Entrega'] = pd.cut(
    df_modelo['tempo_entrega_min'],
    bins=[0, 30, 60, 90, 200],
    labels=['Rápido', 'Normal', 'Lento', 'Muito Lento']
)

# pd.cut() -> divide valores contínuos em faixas
# bins -> limites das faixas
# labels -> nomes das categorias

print(df_modelo['Faixa_Entrega'].value_counts())
# value_counts() -> conta quantos registros existem em cada faixa

# ============================
# ENCODING ORDINAL
# ============================

df_modelo['Faixa_Entrega'] = df_modelo['Faixa_Entrega'].map({
    'Rápido': 0,
    'Normal': 1,
    'Lento': 2,
    'Muito Lento': 3
})

# map() -> substitui texto por números

df_modelo['complexidade_preparo'] = df_modelo['complexidade_preparo'].map({
    'BAIXA': 0,
    'MÉDIA': 1,
    'ALTA': 2
})

# BAIXA < MÉDIA < ALTA

# ============================
# ENCODING BINÁRIO
# ============================

df_modelo['horario_pico'] = df_modelo['horario_pico'].map({
    'NÃO': 0,
    'SIM': 1
})

df_modelo['cliente_gostou'] = df_modelo['cliente_gostou'].map({
    'NÃO': 0,
    'SIM': 1
})

# NÃO = 0
# SIM = 1

# ============================
# ONE HOT ENCODING
# ============================

df_modelo = pd.get_dummies(
    df_modelo,
    columns=[
        'categoria_loja',
        'forma_pagamento',
        'status_pedido',
        'regiao_entrega'
    ],
    drop_first=True
)

# get_dummies() -> cria colunas binárias
# drop_first=True -> remove a primeira categoria

print(df_modelo.head())

# ============================
# HISTOGRAMA
# ============================

plt.figure(figsize=(8,5))

plt.hist(
    df['tempo_entrega_min'],
    bins=10
)

# hist() -> distribuição dos tempos de entrega

plt.title('Distribuição do Tempo de Entrega')

plt.xlabel('Tempo de Entrega (min)')

plt.ylabel('Quantidade de Pedidos')

plt.show()

# ============================
# BOXPLOT
# ============================

plt.figure(figsize=(8,5))

sns.boxplot(
    x=df['distancia_km']
)

# boxplot() -> identifica dispersão e outliers

plt.title('Boxplot da Distância de Entrega')

plt.xlabel('Distância (km)')

plt.show()

# ============================
# SCATTERPLOT
# ============================

plt.figure(figsize=(8,5))

sns.scatterplot(
    x=df['distancia_km'],
    y=df['tempo_entrega_min'],
    hue=df['cliente_gostou']
)

# scatterplot() -> relação entre duas variáveis
# hue -> colore conforme satisfação do cliente

plt.title('Distância x Tempo de Entrega')

plt.xlabel('Distância (km)')

plt.ylabel('Tempo de Entrega (min)')

plt.show()

# ============================
# CORRELAÇÃO
# ============================

correlacao = df_modelo.corr(
    numeric_only=True
)

# corr() -> calcula correlação
# numeric_only=True -> apenas colunas numéricas

print(correlacao)

plt.figure(figsize=(16,12))

sns.heatmap(
    correlacao,
    annot=False,
    cmap='coolwarm',
    linewidths=0.3
)

# heatmap() -> mapa de calor das correlações

plt.title('Correlação entre Variáveis')

plt.show()

# ============================
# REMOÇÃO DE NULOS
# ============================

df_modelo = df_modelo.dropna()

# dropna() -> remove registros com valores nulos

# ============================
# SEPARAÇÃO DOS DADOS
# ============================

dados = df_modelo.drop(
    'cliente_gostou',
    axis=1
)

# dados -> variáveis de entrada

objetivo = df_modelo['cliente_gostou']

# objetivo -> variável alvo

# ============================
# TREINO E TESTE
# ============================

X_treino, X_teste, y_treino, y_teste = train_test_split(
    dados,
    objetivo,
    test_size=0.3,
    random_state=42
)

# test_size=0.3 -> 30% teste
# random_state=42 -> reproduzibilidade

print("Treino:", X_treino.shape)
print("Teste:", X_teste.shape)

# ============================
# MODELO NAIVE BAYES
# ============================

modelo_nb = GaussianNB()

# GaussianNB() -> cria modelo Naive Bayes

modelo_nb.fit(
    X_treino,
    y_treino
)

# fit() -> treinamento

previsoes_nb = modelo_nb.predict(
    X_teste
)

# predict() -> previsão

accuracy_nb = accuracy_score(
    y_teste,
    previsoes_nb
)

# accuracy_score() -> taxa de acerto

print(
    f"Acurácia Naive Bayes: {accuracy_nb*100:.2f}%"
)

# ============================
# RESULTADOS NAIVE BAYES
# ============================

resultado_nb = X_teste.copy()

resultado_nb['Classe_Real'] = y_teste.values

resultado_nb['Previsao_NB'] = previsoes_nb

resultado_nb['Acertou'] = (
    resultado_nb['Classe_Real']
    ==
    resultado_nb['Previsao_NB']
)

print(
    resultado_nb[
        ['Classe_Real', 'Previsao_NB', 'Acertou']
    ]
)

# ============================
# MODELO RANDOM FOREST
# ============================

modelo_rf = RandomForestClassifier(
    n_estimators=100,
    random_state=42
)

# n_estimators=100 -> quantidade de árvores

modelo_rf.fit(
    X_treino,
    y_treino
)

previsoes_rf = modelo_rf.predict(
    X_teste
)

accuracy_rf = accuracy_score(
    y_teste,
    previsoes_rf
)

print(
    f"Acurácia Random Forest: {accuracy_rf*100:.2f}%"
)

# ============================
# RESULTADOS RANDOM FOREST
# ============================

resultado_rf = X_teste.copy()

resultado_rf['Classe_Real'] = y_teste.values

resultado_rf['Previsao_RF'] = previsoes_rf

resultado_rf['Acertou'] = (
    resultado_rf['Classe_Real']
    ==
    resultado_rf['Previsao_RF']
)

print(
    resultado_rf[
        ['Classe_Real', 'Previsao_RF', 'Acertou']
    ]
)

# ============================
# COMPARAÇÃO DOS MODELOS
# ============================

comparacao = pd.DataFrame({
    'Modelo': [
        'Naive Bayes',
        'Random Forest'
    ],
    'Acuracia': [
        accuracy_nb,
        accuracy_rf
    ]
})

# DataFrame() -> cria tabela

print(comparacao)