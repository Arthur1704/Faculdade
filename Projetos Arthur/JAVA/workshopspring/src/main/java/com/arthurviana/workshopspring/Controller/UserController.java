package com.arthurviana.workshopspring.Controller;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import com.arthurviana.workshopspring.Model.Entities.User;
import com.arthurviana.workshopspring.Model.Services.UserService;




@RestController
@RequestMapping("/users")
public class UserController {

    @Autowired
    private UserService service;
    
    @GetMapping()
    public ResponseEntity<List<User>> findAll(){
        List<User> list = service.findAll();
        return ResponseEntity.ok().body(list);
    }

    @GetMapping("/insert")
    public ResponseEntity<Void> insertUsers() {
        service.insert(new User("Arthur Viana", "arthur@gmail.com"));
        service.insert(new User("Jessica Viana", "je@gmail.com"));
        return ResponseEntity.ok().build();
    }
}
