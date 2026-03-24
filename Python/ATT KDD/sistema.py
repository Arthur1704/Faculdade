import pandas as pan 
import os

dados_csv = pan.read_csv("dataset_atividade_kdd.csv")
#Remove Linhas vazias
dados_csv = dados_csv.dropna()
#Remove duplicados
dados_csv = dados_csv.drop_duplicates()

dados_csv.columns = dados_csv.columns.str.strip().str.lower()

#Convertendo para numeros
dados_csv['idade'] = pan.to_numeric(dados_csv['idade'], errors='coerce')
dados_csv['salario'] = pan.to_numeric(dados_csv['salario'], errors='coerce')
dados_csv['renda_extra'] = pan.to_numeric(dados_csv['renda_extra'], errors='coerce')
dados_csv['tempo_emprego'] = pan.to_numeric(dados_csv['tempo_emprego'], errors='coerce')


#soma dos setores
soma = dados_csv['setor'].value_counts()
print(soma)

#Media pagamentos por setor
media = dados_csv.groupby('setor')['salario'].mean()
print(media)

print(dados_csv.describe())

print()
print(dados_csv.corr(numeric_only=True))

