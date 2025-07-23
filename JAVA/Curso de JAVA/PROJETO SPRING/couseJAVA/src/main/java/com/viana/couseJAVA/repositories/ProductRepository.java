package com.viana.couseJAVA.repositories;

import org.springframework.data.jpa.repository.JpaRepository;

import com.viana.couseJAVA.entities.Product;

public interface ProductRepository extends JpaRepository<Product, Long>{

}
