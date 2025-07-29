package com.viana.couseJAVA.services;

import java.util.List;
import java.util.Optional;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.dao.DataIntegrityViolationException;
import org.springframework.dao.EmptyResultDataAccessException;
import org.springframework.stereotype.Service;

import com.viana.couseJAVA.entities.User;
import com.viana.couseJAVA.repositories.UserRepository;
import com.viana.couseJAVA.services.exception.DataBaseException;
import com.viana.couseJAVA.services.exception.ResourceNotFoundException;
import jakarta.persistence.EntityNotFoundException;

@Service
public class UserService {

    @Autowired
    private UserRepository userRepository;

    public List<User> findAll(){
        return userRepository.findAll();
    }

    public User findById(Long id){
        Optional<User> optional = userRepository.findById(id);
        return optional.orElseThrow(() -> new ResourceNotFoundException(id));
    }

    public User insert(User user){
        return userRepository.save(user);
    }

    public void delete(Long id) {
        try {
            // Força erro caso não exista, por conta da versão do Spring nao esta como no curso;
            userRepository.findById(id).orElseThrow(() -> new EmptyResultDataAccessException(1));
            // Se existe, deleta normalmente
            userRepository.deleteById(id);
        } 
        catch (EmptyResultDataAccessException e) {
            throw new ResourceNotFoundException(id);
        }
        catch(DataIntegrityViolationException e){
            throw new DataBaseException(e.getMessage());
        }

    }

    public User update(Long id, User user){
        try{
            User obj = userRepository.getReferenceById(id);
            updateData(obj, user);
            return userRepository.save(obj);
        }
        catch(EntityNotFoundException e){
            throw new ResourceNotFoundException(id);
        }
    }

    public void updateData(User user1, User user2){
        user1.setName(user2.getName());
        user1.setEmail(user2.getEmail());
        user1.setPhone(user2.getPhone());
    }
}
