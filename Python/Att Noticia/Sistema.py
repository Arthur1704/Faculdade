from sklearn.feature_extraction.text import TfidfVectorizer
from wordcloud import WordCloud

import nltk
from nltk.corpus import stopwords
from nltk.tokenize import word_tokenize
import matplotlib.pyplot as plt

nltk.download('punkt')
nltk.download('punkt_tab')
nltk.download('stopwords')

noticia = [ 
    "Brasil registra crescimento na energia solar em 2026",
    "Dados apontam aumento significativo na geração de energia limpa em todo o país, impulsionado por investimentos privados e incentivos do governo.",
    "Especialistas afirmam que o setor deve continuar crescendo nos próximos anos devido à demanda por fontes sustentáveis.",
    
    "Tecnologia 5G avança no interior de São Paulo",
    "Novas cidades passam a contar com cobertura completa, melhorando a qualidade da internet e favorecendo empresas e usuários.",
    "A expectativa é que o 5G impulsione ainda mais a economia digital na região.",
    
    "Estudo destaca importância da atividade física",
    "Pesquisas mostram que exercícios regulares ajudam a reduzir ansiedade e melhorar a qualidade de vida.",
    "Profissionais recomendam a prática de atividades pelo menos três vezes por semana."
    ]

noticia_unico = " ".join(noticia)
tokens = word_tokenize(noticia_unico)
tokens_filtrados = [palavra for palavra in tokens if palavra.lower() not in stopwords.words('portuguese')]

vectorizer = TfidfVectorizer()
noticia_processado = " ".join(tokens_filtrados)
X = vectorizer.fit_transform([noticia_processado])

print("\nMatriz TF-IDF:")
print(X.toarray())

palavras = vectorizer.get_feature_names_out()
scores = X.sum(axis=0).A1 
palavras_scores = dict(zip(palavras, scores))

wordcloud = WordCloud(width=800, height=400, max_words=10, background_color='white').generate_from_frequencies(palavras_scores)
plt.figure(figsize=(10, 5))
plt.imshow(wordcloud, interpolation='bilinear')
plt.axis('off') 

plt.show()