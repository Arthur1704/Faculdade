#include <iostream>
#define MAX 4
using namespace std;

struct Pilha{
	int topo;
	int dado[MAX];
};

void inic (Pilha *pilha){
	pilha->topo = 0;
}

bool estaCheia(Pilha pilha){
	if (pilha.topo == MAX){
		return true;
	}
	return false;
}

bool estaVazia(Pilha pilha){	
	if (pilha.topo == 0){
		return true;
	}
	return false;
}

int retornaTopo(Pilha pilha){
	
	if (!estaVazia(pilha)){
		return pilha.dado[pilha.topo];
	}
	return 0;
}

void empilha(Pilha *pilha, int valor){
	
	if (!estaCheia(*pilha)){
		pilha->dado[pilha->topo] = valor;
		pilha->topo++;	
	}
	else{
		cout << "Está pilha está cheia!!";
	}
}

int desempilha (Pilha *pilha){
	
	if (!estaVazia(*pilha)){
		pilha->topo--;
		return pilha->dado[pilha->topo];
	}
	return 0;
}

int main(int argc, char** argv) {
	
	Pilha pilha;
	
	inic(&pilha);
	empilha(&pilha, 3);
	empilha(&pilha, 2);
	empilha(&pilha, 4);
	empilha(&pilha, 1);
	
	
	int somaP = 0, somaI = 0;
	int topo = retornaTopo(pilha);
	
	while (!estaVazia(pilha)){
		int valor = desempilha(&pilha);
		if (valor % 2 == 0){
			somaP = somaP + valor;
		}
		else{
			somaI = somaI + valor;
		}
	}
	
	cout << "A soma dos numeros pares são: " << somaP << endl;
	cout << "A soma dos numeros impares são: " << somaI << endl;	
		
	return 0;
}
