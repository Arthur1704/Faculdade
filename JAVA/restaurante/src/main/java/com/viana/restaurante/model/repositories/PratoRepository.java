package com.viana.restaurante.model.repositories;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import com.viana.restaurante.model.entities.Prato;

@Repository
public interface PratoRepository extends JpaRepository<Prato, Long> {

}
