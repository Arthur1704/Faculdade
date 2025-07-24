package com.viana.couseJAVA.services;

import java.util.List;
import java.util.Optional;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import com.viana.couseJAVA.entities.User;
import com.viana.couseJAVA.repositories.UserRepository;

@Service
public class UserService {

    @Autowired
    private UserRepository userRepository;

    public List<User> findAll(){
        return userRepository.findAll();
    }

    public User findById(Long id){
        Optional<User> optional = userRepository.findById(id);
        return optional.get();
    }

    public User insert(User user){
        return userRepository.save(user);
    }

    public void delete(Long id){
        userRepository.deleteById(id);
    }

    public User update(Long id, User user){
        User obj = userRepository.getReferenceById(id);
        updateData(obj, user);
        return userRepository.save(obj);
    }

    public void updateData(User user1, User user2){
        user1.setName(user2.getName());
        user1.setEmail(user2.getEmail());
        user1.setPhone(user2.getPhone());
    }
}
