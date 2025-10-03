package com.arthurviana.workshopspring.Controller;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import com.arthurviana.workshopspring.Model.User;

import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.GetMapping;




@RestController
@RequestMapping("/users")
public class UserController {
    
    @GetMapping()
    public ResponseEntity<List<User>> findAll(){
        User maria = new User(1, "Maria Eduarda", "maria@gmail.com");
        User jessica = new User(2, "Jessica Viana", "jessica@gmail.com");

        List<User> list = new ArrayList<>();
        list.addAll(Arrays.asList(maria, jessica));
        return ResponseEntity.ok().body(list);
    }
}
