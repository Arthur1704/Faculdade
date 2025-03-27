#include <iostream>
#include <windows.h>
#include <stdlib.h>
#include <unistd.h>
#define MAX 3
using namespace std;

struct Fila
{
    int dado[MAX];
    int inicio, fim;
};

void gotoxy(int x, int y){
    SetConsoleCursorPosition(GetStdHandle(STD_OUTPUT_HANDLE),(COORD){x-1,y-1});
}

void inicFila(Fila *fila){
    fila->inicio = 0;
    fila->fim = 0;
}

bool EstaCheia(Fila f){
   if (f.fim == MAX)
      	return true;
   else                
		return false;
}

void Enfileira(Fila *fila, int x){  
	if (!EstaCheia(*fila)){  
	    fila->dado[fila->fim] = x;
        fila->fim = fila->fim + 1;
    }
    else
    	cout << "Fila Cheia!";
    }
     
bool EstaVazia (Fila f){
    return (f.inicio == f.fim);
}

int Desenfileira(Fila *fila){ 
	if (!EstaVazia(*fila)){   
	   	fila->inicio = fila->inicio + 1;
    	return fila->dado[fila->inicio - 1];
    }
        cout << "fila está vazia - erro";
    	return 0;
}

void Escolha_caixa(Fila *c1, Fila *c2){
	int caixa, dado;
	char S_N = 'N';
	
	do{
		gotoxy(36,24);
		cout << "Escolha o caixa que deseja enfileirar (1 ou 2): " << endl;
		gotoxy(84,24);
		cin >> caixa;
		
		gotoxy(36,25);
		cout << "Insira um numero: ";
		cin >> dado;
		
		if (caixa == 1){
			Enfileira(c1, dado);	
		} 
		else{
			Enfileira(c2, dado);
		}
		
		gotoxy(36,26);
		cout << "Deseja enfileirar mais (S - Sim ou N - Não): ";
		cin >> S_N;
		S_N = toupper(S_N);
//		system("cls");
		
	}while(S_N != 'N');
}

void set_Prioritario(Fila *c3){
	int dado;
	char S_N = 'N';	
	do{	
		cout << "Insira um numero: ";
		cin >> dado;
		
		Enfileira(c3, dado);	
		
		cout << "Deseja enfileirar mais (S - Sim ou N - Não): ";
		cin >> S_N;
		S_N = toupper(S_N);
		system("cls");
		
	}while(S_N != 'N');
}

void Escolha_caixa_desenfileira(Fila *c1, Fila *c2, Fila *c3){
	int caixa, dado;
	char S_N = 'N';
		
	cout << "Escolha o caixa que deseja desenfileirar (1 ,2 ou 3): ";
	cin >> caixa;
	
	if (caixa == 1){
		Desenfileira(c1);	
	} 
	else if(caixa == 2){
		Desenfileira(c2);
	}else{
		Desenfileira(c3);
	}
	
	//Animação * indo para o caixa		
}

int main(){
	setlocale(LC_ALL,"portuguese");
    Fila caixa1;
    Fila caixa2;
    Fila caixaP;
    
    inicFila(&caixa1);
    inicFila(&caixa2);
    inicFila(&caixaP);
    
    int op;
    
	gotoxy(31,7);
    cout << "FILA NORMAL: " << endl;
    gotoxy(51,7);
    cout << "FILA PRIORITÁRIA: " << endl;
    
    int i = 0;
    gotoxy(31,10);
    cout<<  "+-------------+";
    gotoxy(31,11);
    cout<<  "|             |";
    gotoxy(31,12);
    cout<<  "|   CAIXA 1   |";
    gotoxy(31,13);
    cout<<  "|             |";
    gotoxy(31,14);
    cout<<  "+-------------+";
 	
	gotoxy(51,10);    
    cout<<  "+-------------+";
    gotoxy(51,11);
    cout<<  "|             |";
    gotoxy(51,12);
    cout<<  "|   CAIXA 2   |";
    gotoxy(51,13);
    cout<<  "|             |";
    gotoxy(51,14);
    cout<<  "+-------------+";
    
    gotoxy(71,10);
    cout<<  "+-------------+";
    gotoxy(71,11);
    cout<<  "|             |";
    gotoxy(71,12);
    cout<<  "|   CAIXA 3   |";
    gotoxy(71,13);
    cout<<  "|             |";
    gotoxy(71,14);
    cout<<  "+-------------+" << endl;
    
   
    
//    do{
    	gotoxy(42,16);
    	cout << " -----------------------------" << endl;
    	gotoxy(42,17);
    	cout << "|             MENU            |"<< endl;
    	gotoxy(42,18);
    	cout << "|  1 - ENFILEIRA NORMAL       |"<< endl;
    	gotoxy(42,19);
    	cout << "|  2 - ENFILERIRA PRIORITARIO |"<< endl;
    	gotoxy(42,20);
    	cout << "|  3 - DESENFILEIRA           |"<< endl;
    	gotoxy(42,21);
    	cout << "|  0 - SAIR                   |"<< endl;
    	gotoxy(42,22);
    	cout << " -----------------------------"<< endl;
    	gotoxy(42,23);
    	cout << "Entre com uma opção desejada: ";
//    	gotoxy(42,24);
    	cin >> op;
    	
    	switch(op){
    		case 1:{
    			Escolha_caixa(&caixa1, &caixa2);
				break;
			}
			case 2:{
				set_Prioritario(&caixaP);
				break;
			}
			case 3:{
				Escolha_caixa_desenfileira(&caixa1, &caixa2, &caixaP);
				break;
			}
		}

			
//	}while(op != 0);
     for (i = 0; i < 10; i++)
    {
        gotoxy(30+i,20);
        cout << " *";
         sleep(1);
    }
    
   return 0; 
}

