package com.viana.couseJAVA.repositories;

import org.springframework.data.jpa.repository.JpaRepository;

import com.viana.couseJAVA.entities.User;

public interface UserRepository extends JpaRepository<User, Long>{

}
