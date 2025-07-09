package org.utilits.services;

public interface OnlinePaymentService {

    Double paymentFee(Double amont);
    Double interest(Double amont, Integer months);
}
