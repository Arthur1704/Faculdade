import pandas as pd
import os
data_df = pd.read_csv("Exercícios/Análise de Dados/dataset_atividade_kdd.csv")

print(data_df.head())

# Remove empty lines
data_df = data_df.dropna()
# print(data_df)
op = input()
os.system('cls')

# Remove datas dupplied
data_df = data_df.drop_duplicates()

# Set all columns to string lower
data_df.columns = data_df.columns.str.strip().str.lower()

# Convert to num
data_df['idade'] = pd.to_numeric(data_df['idade'], errors="coerce")

data_df['salario'] = pd.to_numeric(data_df['salario'], errors="coerce")

data_df['renda_extra'] = pd.to_numeric(
    data_df['renda_extra'], errors="coerce")

data_df['tempo_emprego'] = pd.to_numeric(
    data_df['tempo_emprego'], errors="coerce")

os.system('cls')
print(data_df)
op = input()

os.system('cls')

# Total sum on setor
sum_payout = data_df['setor'].value_counts()
print(sum_payout)

# Avg payouts on setor
avg_payout = data_df.groupby('setor')['salario'].mean()
print(avg_payout)

op = input()
os.system('cls')

print(data_df.describe())
op = input()
os.system('cls')

print(data_df.corr(numeric_only=True))
