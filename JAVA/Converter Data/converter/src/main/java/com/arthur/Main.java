package com.arthur;

import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        Calendario calendario = new Calendario();
        Scanner scanner = new Scanner(System.in);

        System.out.print("Digite um número de mês (1-12): ");
        int mes = scanner.nextInt();
        String nomeMes = calendario.converterMes_string(mes);
        System.out.println("Mês: " + nomeMes);

        System.out.print("Digite o dia: ");
        int dia = scanner.nextInt();
        System.out.print("Digite o mês: ");
        mes = scanner.nextInt();
        System.out.print("Digite o ano: ");
        int ano = scanner.nextInt();

        String dataTexto = calendario.converteDataParaTexto(dia, mes, ano);
        System.out.println("Data por extenso: " + dataTexto);

        scanner.close();
    }
}