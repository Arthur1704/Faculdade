package org.utilits.services;

import org.utilits.Contract;
import org.utilits.Installment;

import java.time.LocalDate;

public class ContractService {

    private OnlinePaymentService onlinePaymentService;

    public ContractService(OnlinePaymentService onlinePaymentService) {
        this.onlinePaymentService = onlinePaymentService;
    }


    public void processContract(Contract obj, Integer months){

        Double basicQuota = obj.getTotalValue() / months;

        for (int cont = 0; cont < months; cont++){

            LocalDate date = obj.getDate().plusMonths((cont+1));
            Double interest = onlinePaymentService.interest(basicQuota, (cont+1));
            Double fee = onlinePaymentService.paymentFee(basicQuota + interest);

            Double quota = basicQuota + interest + fee;

            obj.getInstallments().add(new Installment(date, quota));
        }
    }
}
