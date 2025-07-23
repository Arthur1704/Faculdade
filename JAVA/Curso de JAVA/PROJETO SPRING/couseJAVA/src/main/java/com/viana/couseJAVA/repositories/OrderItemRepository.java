package com.viana.couseJAVA.repositories;

import org.springframework.data.jpa.repository.JpaRepository;

import com.viana.couseJAVA.entities.OrderItem;
import com.viana.couseJAVA.entities.pk.OrderItemPK;

public interface OrderItemRepository extends JpaRepository<OrderItem, OrderItemPK>{

}
