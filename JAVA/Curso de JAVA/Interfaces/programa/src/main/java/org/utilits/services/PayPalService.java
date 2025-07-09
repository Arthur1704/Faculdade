package org.utilits.services;

public class PayPalService implements OnlinePaymentService{


    @Override
    public Double paymentFee(Double amont) {
        return amont * 0.02;
    }

    @Override
    public Double interest(Double amont, Integer months) {
        return amont * 0.01 * months;
    }
}
