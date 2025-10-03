package com.arthurviana.workshopspring.Model.Services;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import com.arthurviana.workshopspring.Model.Entities.User;
import com.arthurviana.workshopspring.Model.Repositories.UserRepository;

@Service
public class UserService {

    @Autowired
    private UserRepository userRepository;

    public List<User> findAll(){
        return userRepository.findAll();    
    }
    
    public void insert(User user){
        userRepository.save(user);
    }

}
