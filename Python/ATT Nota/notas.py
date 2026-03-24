import statistics

turma = {
"Ana": [8.5, 7.0, 9.0],
"Carlos": [6.0, 5.5, 7.0],
"Mariana": [9.5, 8.0, 10.0]
};


medias = {};
lista_medias = [];
aprovados = 0;
reprovados = 0;

for nomes, notas in turma.items():

    media = statistics.mean(notas);
    lista_medias.append(media);

    if media >= 7:
        situacao = "Aprovado";
        aprovados += 1;
    else:
        situacao = "Reprovado";
        reprovados += 1; 

    medias[nomes] = {
        "media" : media,
        "situacao" : situacao
    }

maior = max(lista_medias);
menor = min(lista_medias);

media_geral = statistics.mean(lista_medias);

print("Relação Alunos")

for nome, dados in medias.items():
    print(f"{nome} finalizou com média {dados['media']:.1f} e está {dados['situacao']}");

print("\nA maior média foi", round(maior,1));
print("A menor média foi", round(menor,1));
print("A média da sala foi", round(media_geral,1));
print("Aprovados:", aprovados);
print("Reprovados:", reprovados);


    






