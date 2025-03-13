#include <iostream>
#include <string>
#include <cctype>
using namespace std;

struct TAluno {
    string RA;
    string nome;
    string curso;
};

string lerRA() {
	system("cls");
    string RA;
    cout << "RA: ";
    cin >> RA;
    return RA;
}

TAluno lerDados() {
    TAluno aluno;
    system("cls");
    aluno.RA = lerRA();
    cout << "\nNome: ";
    cin >> aluno.nome;
    cout << "\nCurso: ";
    cin >> aluno.curso;
    return aluno;
}

void alteraDados(TAluno *Aluno) {
	system("cls");
    Aluno->RA = lerRA();
    cout << "\nNome: ";
    cin >> Aluno->nome;
    cout << "\nCurso: ";
    cin >> Aluno->curso;
    system("pause");
}

void mostrar_dados(TAluno Aluno) {
	system("cls");
    cout << "RA: " << Aluno.RA;
    cout << "\nNOME: " << Aluno.nome;
    cout << "\nCURSO: " << Aluno.curso << endl;
    system("pause");
}

void excluir_dados(TAluno Alunos[], string RA, int quant) {
	system("cls");
    for (int cont = 0; cont < quant; cont++) {
        if (Alunos[cont].RA == RA) {
            Alunos[cont].RA = "";
            Alunos[cont].nome = "";
            Alunos[cont].curso = "";
            cout << "Aluno com RA " << RA << " excluído" << endl;
            return; 
        }
        else{
    		cout << "RA invalido" << endl;
    	}
    }
    system("pause");
}

int main() {
    setlocale(LC_ALL, "Portuguese");

    const int quant = 2; 
    TAluno Alunos[quant];
    int opcao;

    do {
    	system("cls");
        cout << "--------------------";
        cout << "\n| 1 - Inserir dados|\n| 2 - Trocar dados |\n| 3 - Pesquisar RA |\n| 4 - Excluir Aluno|\n| 0 - Sair    |"; 
        cout << "\n--------------------";
        
        cout << "\n\nEntre com a opção desejada: ";
        cin >> opcao;

        switch(opcao) {
            case 1: {
                for (int cont = 0; cont < quant; cont++) {
                    if (Alunos[cont].RA == "") {
                        Alunos[cont] = lerDados();
                    } else {
                        cout << "Vetor já está cheio!!" << endl;
                        system("pause");
                    }
                }
                break;
            }
            case 2: {
                string RA = lerRA();
                for (int cont = 0; cont < quant; cont++) {
                    if (Alunos[cont].RA == RA) {
                        alteraDados(&Alunos[cont]);
                        break;
                    }
                }
                break;
            }
            case 3: {
                string RA = lerRA();
                for (int cont = 0; cont < quant; cont++) {
                    if (Alunos[cont].RA == RA) {
                        mostrar_dados(Alunos[cont]);
                        break;
                    }
                }
                break;
            }
            case 4: {
                string RA = lerRA();
                excluir_dados(Alunos, RA, quant);
                break;
            }
            default: {
                cout << "Saindo do programa..." << endl;
                break;
            }
        }

        cout << endl; 
    } while (opcao != 5);

    return 0;
}
