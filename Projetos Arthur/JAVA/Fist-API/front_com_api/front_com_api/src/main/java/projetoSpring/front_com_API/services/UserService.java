package projetoSpring.front_com_API.services;

import java.util.ArrayList;
import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.dao.DataIntegrityViolationException;
import org.springframework.dao.EmptyResultDataAccessException;
import org.springframework.stereotype.Service;

import jakarta.persistence.EntityNotFoundException;
import projetoSpring.front_com_API.dto.UserRequestDTO;
import projetoSpring.front_com_API.dto.UserResponseDTO;
import projetoSpring.front_com_API.entities.User;
import projetoSpring.front_com_API.repositories.UserRepository;
import projetoSpring.front_com_API.services.exception.DataBaseException;
import projetoSpring.front_com_API.services.exception.ResourceNotFoundException;

@Service
public class UserService {

    @Autowired
    private UserRepository userRepository;

    public UserResponseDTO findById(Long id){
        User user = userRepository.findById(id).orElseThrow(() -> new ResourceNotFoundException(id));

        return usertoDTO(user);
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
        try{
            userRepository.findById(id).orElseThrow(() -> new EmptyResultDataAccessException(1));
            userRepository.deleteById(id);
        }
        catch (EmptyResultDataAccessException e){
            throw new ResourceNotFoundException(id);
        }
        catch(DataIntegrityViolationException e){
            throw new DataBaseException(e.getMessage());
        }

    }

    public UserResponseDTO update(Long id, UserRequestDTO userDTO){
        try{
            User user = userRepository.getReferenceById(id);
            updateUser(user, userDTO);
            User update = userRepository.save(user);
            return usertoDTO(update);
        }
        catch (EntityNotFoundException e){
            throw new ResourceNotFoundException(id);
        }    
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
