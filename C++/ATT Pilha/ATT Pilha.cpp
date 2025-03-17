#include <iostream>
#include <string>
#include <utility>
#include <cctype>
#define MAX 50
using namespace std;


    struct Ttarefa{
       int topo; 
	   string descricao[MAX];
	   int prioridade[MAX];
    };
    
	
	bool EstaVazia(Ttarefa p)
    {
       if (p.topo == 0)    return true;
       else            return false;
    }

	string RetornaTopo (Ttarefa p)
    {
       if (EstaVazia(p))        
          { cout << "Pilha vazia " << endl;
            return "";
         }
         else    
         {    return p.descricao[p.topo-1];
         }
    }
    bool EstaCheia(Ttarefa p)
    {
       if (p.topo == MAX)
          return true;
       else                
          return false;
    }
    void inic(Ttarefa *p)
    {       p->topo = 0;
    }


	void Empilha(Ttarefa *p, string descri, int pri){  
		if (!EstaCheia(*p)){ 
			p->descricao[p->topo] = descri;
			p->prioridade[p->topo] = pri;
			p->topo = p->topo + 1;
	   	}
	   else
	      cout << "Pilha Cheia! VALOR NAO INSERIDO ";
}

pair<int, string> Desempilha(Ttarefa *p){
   if (!EstaVazia(*p))
   {
      p->topo = p->topo - 1;
      return make_pair(p->prioridade[p->topo], p->descricao[p->topo]);
   }
   else
   {   cout << "Pilha Vazia!";
        return make_pair(0, "");
	}
}

int ler_pri(){
	system("cls");
	int num;
	cout << "Entre com a prioridade da sua tarefa de 1 a 3: ";
	cin >> num;
	if(num >= 1 && num <= 3){
	return num;
	}
	else{
		cout << "Entre com um numero valido";
		system("pause");
		system("cls");
		return ler_pri();
	}
}

string ler_descri(){
	string descri;
	cout << "Entre com a descrição de sua tarefa: ";
	getline(cin, descri);
	return descri;
}

int main(int argc, char** argv) {
	setlocale(LC_ALL, "Portuguese");
	
	Ttarefa tarefas;
	Ttarefa pilha1;
	Ttarefa pilha2;
	Ttarefa pilha3;
	inic(&tarefas);
    inic(&pilha1);
    inic(&pilha2);
    inic(&pilha3);
	char S_N;
	string descricao;
	int prioridade, quant=0, p1 = 0, p2 = 0, p3 = 0;
	
	do{
		prioridade = ler_pri();
		cin.ignore();
		descricao = ler_descri();
		cout << "\nDeseja entrar com mais uma tarefa (S ou N): ";
		cin >> S_N;
		Empilha (&tarefas, descricao, prioridade);
		quant++;
		S_N = toupper(S_N);
	}while(S_N != 'N');
	
	for (int cont = 0; cont < quant; cont++){
		pair<int, string> retorno = Desempilha(&tarefas); 
		prioridade = retorno.first;
		descricao = retorno.second;
		switch(prioridade){
			case 1:{
				p1++;
				Empilha(&pilha1, descricao, prioridade);
				break;
			}
			case 2:{
				p2++;
				Empilha(&pilha2, descricao, prioridade);
				break;
			}
			case 3:{				
				p3++;
				Empilha(&pilha3, descricao, prioridade);
				break;
			}
		}
	}
	
	system("cls");
	
	for (int cont = 0; cont < p1; cont++){
		pair<int, string> retorno = Desempilha(&pilha1); 
		prioridade = retorno.first;
		descricao = retorno.second;
		cout << "\nPrioridade: " << retorno.first << ", Descrição: " << retorno.second << endl;
	}
	
	cout << endl;
	
	for (int cont = 0; cont < p2; cont++){
		pair<int, string> retorno = Desempilha(&pilha2); 
		prioridade = retorno.first;
		descricao = retorno.second;
		cout << "\nPrioridade: " << retorno.first << ", Descrição: " << retorno.second << endl;
	}
	
	cout << endl;
	

	for (int cont = 0; cont < p3; cont++){
		pair<int, string> retorno = Desempilha(&pilha3); 
		prioridade = retorno.first;
		descricao = retorno.second;
		cout << "\nPrioridade: " << retorno.first << ", Descrição: " << retorno.second << endl;
	}	
	return 0;
}



