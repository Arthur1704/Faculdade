package projetoSpring.front_com_API.services;

import java.util.List;
import java.util.Optional;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import projetoSpring.front_com_API.entities.User;
import projetoSpring.front_com_API.repositories.UserRepository;

@Service
public class UserService {

    @Autowired
    private UserRepository userRepository;

    public User findById(Long id){
        Optional<User> user = userRepository.findById(id);
        return user.get();
    }

    public List<User> findAll(){
        List<User> list = userRepository.findAll();
        return list;
    }

    //retornar void ao final dos testes
    public User insert(User user){
        return userRepository.save(user);
    }

    public void delete(Long id){
        userRepository.deleteById(id);
    }

    public User update(Long id, User user){
        User user2 = userRepository.getReferenceById(id);
        updateUser(user2, user);
        return userRepository.save(user);
    }

    private void updateUser(User prin,  User user2){
        prin.setName(user2.getName());
        prin.setEmail(user2.getEmail());
        prin.setAge(user2.getAge());
        prin.setPhone(user2.getPhone());
    }
}
