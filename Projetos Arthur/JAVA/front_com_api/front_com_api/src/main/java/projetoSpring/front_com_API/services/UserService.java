package projetoSpring.front_com_API.services;

import java.util.ArrayList;
import java.util.List;
import java.util.Optional;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import projetoSpring.front_com_API.dto.UserRequestDTO;
import projetoSpring.front_com_API.dto.UserResponseDTO;
import projetoSpring.front_com_API.entities.User;
import projetoSpring.front_com_API.repositories.UserRepository;

@Service
public class UserService {

    @Autowired
    private UserRepository userRepository;

    public UserResponseDTO findById(Long id){
        Optional<User> user = userRepository.findById(id);

        return usertoDTO(user.get());
    }

    public List<UserResponseDTO> findAll(){
        List<User> list = userRepository.findAll();
        List<UserResponseDTO> listDTO = new ArrayList<>();

        for (User user : list){
            listDTO.add(usertoDTO(user));
        }
        return listDTO;
    }

    
    public UserResponseDTO insert(UserRequestDTO userDTO){
        User user = new User();
        user.setName(userDTO.getName());
        user.setEmail(userDTO.getEmail());
        user.setPhone(userDTO.getPhone());
        user.setAge(userDTO.getAge());
        
        User salved = userRepository.save(user);
        return usertoDTO(salved);
    }

    public void delete(Long id){
        userRepository.deleteById(id);
    }

    public UserResponseDTO update(Long id, UserRequestDTO userDTO){
        User user = userRepository.getReferenceById(id);
        updateUser(user, userDTO);
        User update = userRepository.save(user);
        return usertoDTO(update);
    }

    private void updateUser(User prin,  UserRequestDTO user2){
        prin.setName(user2.getName());
        prin.setEmail(user2.getEmail());
        prin.setAge(user2.getAge());
        prin.setPhone(user2.getPhone());
    }

    private UserResponseDTO usertoDTO(User user){
        return new UserResponseDTO(user.getId(), user.getName(), user.getEmail(), user.getPhone(), user.getAge());
    }

}
