package com.arthurviana.workshopspring.Model.Repositories;

import com.arthurviana.workshopspring.Model.Entities.User;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;


@Repository
public interface UserRepository extends JpaRepository<User, Integer>{

}
