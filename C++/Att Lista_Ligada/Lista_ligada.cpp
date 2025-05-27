#include <iostream>
using namespace std;

struct No{
	int valor;
	No *prox;
};

void insere(No **inicio, int valor){
	No *novo;
	novo = new(No);
	novo->valor = valor;
	novo->prox = NULL;
	
	if (*inicio == NULL){
		*inicio = novo;
	}
	else{
		novo->prox = *inicio;
		*inicio = novo;
	}
}

void insere_fim (No **inicio, int valor){
	No *novo;
	novo = new No();
	novo->valor = valor;
	novo->prox = NULL;
	
	if (*inicio == NULL){
		*inicio = novo;
	}
	else{
		No *aux = *inicio;
		while(aux->prox != NULL){
			aux = aux->prox;
		}
		aux->prox = novo;
	}
	
}

void imprime_lista(No *inicio){
	if (inicio != NULL){
		cout << inicio->valor << endl;
		imprime_lista(inicio->prox);
	}
	return;
}

void par_impar (No **inicio){
	int par = 0, impar = 0;
	if (inicio ==  NULL){
		cout << "Sua lista está vazia !!";
	}
	else{
		No *aux = *inicio;
		while(aux != NULL){
			int resto = aux->valor % 2;
			if (resto == 1){
				impar++;
				aux = aux->prox;
			}
			else{
				par++;
				aux = aux->prox;
			}
		}
		cout << "\nExistem " << par << " pares na Lista";
		cout << "\nExistem " << impar << " impares na lista";
	}
}

void primeiro_ultimo (No **inicio){
	
	int primeiro = 0, ultimo = 0;
	if (inicio ==  NULL){
		cout << "Sua lista está vazia !!";
		return;
	}
	primeiro = (*inicio)->valor;
	No *aux = *inicio;
	while (aux != NULL){
		if (aux->prox == NULL){
			ultimo = aux->valor;
			break;
		}
		aux = aux->prox;
	}
	cout << "\nO primeiro valor da lista é: " << primeiro;
	cout << "\nO ultimo valor da lista é: " << ultimo;
}

void insere_apos (No **inicio, int valor, int valor_incluir){
	No *novo;
	novo = new No();
	novo->valor = valor_incluir;
	No *aux = *inicio;
	bool encontrou = false;

	while (aux != NULL){
		if (aux->valor == valor){
			No *aux2 = aux->prox;
			aux->prox = novo;
			novo->prox = aux2;
			encontrou = true;
			break;
		}
		aux = aux->prox;
	}
	
	if (!encontrou){
		cout << "Numero não existente na fila!!";
		return;
	}
}


int main(int argc, char** argv) {
	
	No *inicio = NULL;
	
	insere(&inicio,10);
	insere(&inicio,21);
	insere_fim(&inicio, 30);
	imprime_lista(inicio);
	par_impar(&inicio);
	primeiro_ultimo(&inicio);
	cout << "\n\nApós inserir no meio da lista!!\n";
	insere_apos(&inicio, 10, 99);
	imprime_lista(inicio);

	return 0;
}
