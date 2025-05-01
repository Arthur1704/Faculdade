#include <iostream>
#define MAX 3
using namespace std;

struct Fila{
	int inicio, fim;
	int dado[MAX];
};

void inic (Fila *fila){
	fila->fim = 0;
	fila->inicio = 0;
}

bool estaCheia(Fila fila){
	if (fila.fim == MAX){
		return true;
	}
	return false;
}

bool estaVazia(Fila fila){
	if (fila.inicio == fila.fim){
		return true;
	}
	return false;
}

int retornaInicio(Fila fila){
	if (!estaVazia(fila)){
		return fila.dado[fila.inicio];
	}
	else{
		return -1;
	}
}

void emfileira(Fila *fila, int valor){
	
	if (!estaCheia(*fila)){
		fila->dado[fila->fim] = valor;
		fila->fim++;
	}
	else{
		cout << "Está fila está cheia !!";
	}	
}

int desemfileira(Fila *fila){
	
	if (!estaVazia(*fila)){
		fila->inicio++;
		return fila->dado[fila->inicio-1];
	}
	else{
		return 0;
	}
}

int main(int argc, char** argv) {
	
	Fila fila;
	
	inic (&fila);
	emfileira(&fila, 23);
	emfileira(&fila, 88);
	cout << desemfileira(&fila) << endl;
	cout << desemfileira(&fila);
	
	return 0;
}
