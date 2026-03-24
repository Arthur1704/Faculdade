def analisar_palavra(palavra):
    palavra = palavra.lower()

    prefixos_lista = ['des', 'in', 're']
    sufixos_lista = ['mente', 'idade', 'eiro', 'ista', 'oso', 'aria', 'dade']
    desinencias_lista = ['amos', 'ei', 'ia', 'ndo', 'mos', 'ram', 'ria']

    prefixo = ''
    sufixo = ''
    desinencia = ''

    # prefixo
    for p in sorted(prefixos_lista, key=len, reverse=True):
        if palavra.startswith(p):
            prefixo = p
            break

    sem_prefixo = palavra[len(prefixo):] if prefixo else palavra

    # sufixo
    for s in sorted(sufixos_lista, key=len, reverse=True):
        if sem_prefixo.endswith(s):
            sufixo = s
            break

    sem_sufixo = sem_prefixo[:-len(sufixo)] if sufixo else sem_prefixo

    # desinencia
    for d in sorted(desinencias_lista, key=len, reverse=True):
        if sem_sufixo.endswith(d):
            desinencia = d
            break

    radical = sem_sufixo[:-len(desinencia)] if desinencia else sem_sufixo

    # vogal
    vogal = ''
    if len(radical) > 0 and radical[-1] in 'aei':
        vogal = radical[-1]
        radical = radical[:-1]

    return {
        'palavra': palavra,
        'radical': radical,
        'vogal_tematica': vogal,
        'prefixo': prefixo,
        'sufixo': sufixo,
        'desinencia': desinencia
    }


palavras = [
    "Verdadeiro", "Veracidade", "Falsidade", "Refiz", "Refazendo",
    "Refaria", "Correria", "Descorrer", "Ocorrer", "Esperança",
    "Desesperado", "Esperançoso", "Livraria", "Livreiro", "Livramento",
    "Aquático", "Aguado", "Aguaceiro", "Floral", "Florido",
    "Florista", "Cantávamos", "Cantarei", "Cantando", "Vendemos",
    "Venderia", "Vendido", "Partíamos", "Partirão", "Partindo",
    "Infeliz", "Felicidade", "Felizmente", "Lealdade", "Desleal",
    "Certamente", "Certeza", "Pedreiro", "Pedraria", "Pedregoso",
    "Menininha", "Meninão", "Meninice"
]


for palavra in palavras:
    analise = analisar_palavra(palavra)
    print(f"{palavra}:")
    print(f"  RADICAL: '{analise['radical']}'")
    print(f"  VOGAL: '{analise['vogal_tematica']}'")
    print(f"  PREFIXO: {analise['prefixo']}")
    print(f"  SUFIXO: {analise['sufixo']}")
    print(f"  DESINENCIA: {analise['desinencia']}")
    print()
