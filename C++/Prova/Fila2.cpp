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

bool estaCheia(Pilha pilha){
	if(pilha.topo == MAX){
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

void empilha(Pilha *pilha, int valor){
	if(!estaCheia(*pilha)){
		pilha->dado[pilha->topo] = valor;
		pilha->topo++;
	}
	else{
		cout << "Está pilha esta cheia!!";
	}
}

int desempilha(Pilha *pilha){
	if (!estaVazia(*pilha)){
		pilha->topo--;
		return pilha->dado[pilha->topo];
	}
	cout << "Está pilha está vazia!!";
	return 0;
}

int retornaTopo(Pilha pilha){
	if (!estaVazia(pilha)){
	return pilha.dado[pilha.topo];	
	}
	cout << "Esta pilha esta vazia!!";
	return -1;
}

int main(int argc, char** argv) {
	Pilha pilha;
	
	inic(&pilha);
	
	empilha(&pilha, 55);
	empilha(&pilha, 88);
	cout << "O primeiro numero a sair é o: " << desempilha(&pilha);
	cout << "\nO segundo numero a sair é o: " << desempilha(&pilha);

	return 0;
}
