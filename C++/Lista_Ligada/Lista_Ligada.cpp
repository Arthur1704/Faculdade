#include <iostream>
using namespace std;

struct No{
	int valor;
	No *dir, *esq;
};

void insere(No **raiz, int valor){
	No *novo;
	novo = new No;
	novo->valor = valor;
	novo->dir = NULL;
	novo->esq = NULL;
	
	if (*raiz == NULL){
		*raiz = novo;
	}
	else{
		if(valor == (*raiz)->valor){
			cout << "Já existe";
			return;
		}
		if(valor > (*raiz)->valor){
			if((*raiz)->dir == NULL){
				(*raiz)->dir = novo;
			}
			else{
				insere(&(*raiz)->dir,valor);
			}
		}else{
			if((*raiz)->esq == NULL){
				(*raiz)->esq = novo;
			}
			else{
				insere(&(*raiz)->esq, valor);
			}
		}
	}
}
// RED
void imprime1(No **raiz) {
	if (*raiz == NULL){
		return;	
	}
	cout << (*raiz)->valor << endl;
	
	imprime1(&(*raiz)->esq);
	
	imprime1(&(*raiz)->dir);
}

// ERD
void imprime2(No **raiz) {
	if (*raiz == NULL){
		return;
	}	
	imprime2(&(*raiz)->esq);
	
	cout << (*raiz)->valor << endl;
	
	imprime2(&(*raiz)->dir);
}

// EDR
void imprime3(No **raiz) { 
	if (*raiz == NULL){
		return;
	}
	imprime3(&(*raiz)->esq);
	
	imprime3(&(*raiz)->dir);
	
	cout << (*raiz)->valor << endl;
}

int soma (No *raiz){
	if (raiz == NULL){
		return 0;
	}
	return raiz->valor + soma(raiz->esq) + soma(raiz->dir);
}

int maior_valor (No *raiz){
	
	s
}

int main(int argc, char** argv) {
	
	No *raiz = NULL;

	int valor = 0 ;

	do{
		cout << "\ninforme valor (0 para encerrar): ";
		cin >> valor ;
	
		if (valor > 0){
			insere(&raiz,valor);
		}
	} while(valor!=0);

	cout << "\nImprime pre-ordem = \n";

	imprime1(&raiz);

	cout << "\nImprime central = \n";

	imprime2(&raiz);

	cout << "\nImprime pos-fixado = \n";

	imprime3(&raiz);
	
	
	int soma_valores = soma(raiz);
	cout << "\n A soma dos valores é: " << soma_valores;
	
	
	return 0;
	}
