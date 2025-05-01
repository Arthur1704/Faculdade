#include <iostream>
#define MAX 3
using namespace std;

struct Pilha{
	int topo;
	int dado[MAX];
};

void inic (Pilha *pilha){
	pilha->topo = 0;
}

bool estaCheia (Pilha pilha){
	if (pilha.topo == MAX){
		return true;
	}
	return false;
}

bool estaVazia (Pilha pilha){
	if (pilha.topo == 0){
		return true;
	}
	return false;
}

int retonaTopo(Pilha pilha){
	
	if (!estaVazia(pilha)){
		return pilha.dado[pilha.topo];
	}
	else{
		cout << "Pilha esta Vazia!!";
		return 0;
	}
}

void empilha (Pilha *pilha, int valor){
	
	if (!estaCheia(*pilha)){
		pilha->dado[pilha->topo] = valor;
		pilha->topo++;
	}
	else{
		cout << "Pilha está cheia!!";
	}
}

int desempilha(Pilha *pilha){
	
	if (!estaVazia(*pilha)){
		pilha->topo--;
		return pilha->dado[pilha->topo];
	}
	else{
		return -1;
	}
	
}

int main(int argc, char** argv) {
	
	Pilha pilha;
	
	inic(&pilha);
	
	empilha(&pilha, 23);
	empilha(&pilha, 45);
	empilha(&pilha, 99);
	
	cout << desempilha(&pilha) << endl;
	cout << desempilha(&pilha) << endl;
	cout << desempilha(&pilha);
	
	return 0;
}
