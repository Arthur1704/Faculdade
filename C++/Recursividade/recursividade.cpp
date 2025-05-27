#include <iostream>
using namespace std;

void numeros (int num){
	if (num == 0){
		return;
	}
	cout << num << endl;
	numeros(num-1);
}

int main(int argc, char** argv) {
	
	numeros(10);
	return 0;
}
