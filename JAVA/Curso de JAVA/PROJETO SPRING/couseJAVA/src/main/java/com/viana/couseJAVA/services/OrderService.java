package com.viana.couseJAVA.services;

import java.util.List;
import java.util.Optional;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import com.viana.couseJAVA.entities.Order;
import com.viana.couseJAVA.repositories.OrderRepository;

@Service
public class OrderService{

    @Autowired
    private OrderRepository orderRepository;

    public List<Order> findAll(){
        List<Order> list = orderRepository.findAll();
        return list;
    }

    public Order findById(Long id){
        Optional<Order> order = orderRepository.findById(id);
        return order.get();
    }

}
