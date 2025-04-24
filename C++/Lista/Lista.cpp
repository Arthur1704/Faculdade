#include <iostream>
#define MAX 3
using namespace std;

struct Lista{
	int dados[MAX];
	int fim;
};

void inic (Lista *lista){
	lista->fim = 0;
}

int retonaFim(Lista lista){
	return lista.fim;
}

int retornaUltimo(Lista lista){
	if (lista.fim != 0){
		return lista.dados[lista.fim-1];
	}
	return -1;
}

int verificaLista(Lista lista){
	if (retonaFim(lista) == MAX){
		return 0;
	}
	else if(retonaFim(lista) == 0){
		return 1;
	}
	return 2;
}

void incluirInicio(Lista *lista, int valor){
	if (verificaLista(*lista) != 0){
		for (int cont = lista->fim; cont > 0; cont--){
			lista->dados[cont] = lista->dados[cont-1];
		}
		lista->dados[0] = valor;
		lista->fim++;
		cout << "Inserido com sucesso!!";
	}
	cout << "A Lista esta cheia!!";
}

void incluirFinal(Lista *lista, int valor){
	if(verificaLista(*lista) != 0){
		lista->dados[lista->fim] = valor;
		lista->fim++;
		cout << "Inserido com sucesso!!";
	}
	else{
		cout << "Lista está cheia!!";
	}
}




int main(int argc, char** argv) {
	return 0;
}
