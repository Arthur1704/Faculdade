package org.sistema;


import org.utilits.Contract;
import org.utilits.Installment;
import org.utilits.services.ContractService;
import org.utilits.services.PayPalService;

import java.time.LocalDate;
import java.time.format.DateTimeFormatter;
import java.util.Scanner;

public class Main {
    public static void main(String[] args) {

        Scanner guardar = new Scanner(System.in);
        DateTimeFormatter format = DateTimeFormatter.ofPattern("dd/MM/yyyy");
        System.out.println("Entre com os dados do contrato: ");
        System.out.print("Numero: ");
        int num = guardar.nextInt();
        System.out.print("Data (DD/MM/YYYY): ");
        LocalDate date =  LocalDate.parse(guardar.next(), format);
        System.out.print("Valor do contrato: ");
        double value = guardar.nextDouble();
        System.out.print("Numero de parcelas: ");
        int parcelas = guardar.nextInt();

        Contract contract = new Contract(num, date, value);

        ContractService contractService = new ContractService(new PayPalService());
        contractService.processContract(contract, parcelas);

        for (Installment installment : contract.getInstallments()){
            System.out.println(installment);
        }
    }
}