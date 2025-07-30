/* package projetoSpring.front_com_API.confg;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.CommandLineRunner;
import org.springframework.context.annotation.Configuration;
import org.springframework.context.annotation.Profile;

import projetoSpring.front_com_API.entities.User;
import projetoSpring.front_com_API.repositories.UserRepository;

@Configuration
@Profile("test")
public class RunTest implements CommandLineRunner{

    @Autowired
    private UserRepository userRepository;

    @Override
    public void run(String... args) throws Exception {
        User user = new User(null, "Arthur Viana", "arthur@gmail.com", "18996984710", "19");

        userRepository.save(user);
    }   
}
 */