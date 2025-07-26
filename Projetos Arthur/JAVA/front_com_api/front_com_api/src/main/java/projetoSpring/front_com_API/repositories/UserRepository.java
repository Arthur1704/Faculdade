package projetoSpring.front_com_API.repositories;

import org.springframework.data.jpa.repository.JpaRepository;

import projetoSpring.front_com_API.entities.User;

public interface UserRepository extends JpaRepository<User, Long>{

}
