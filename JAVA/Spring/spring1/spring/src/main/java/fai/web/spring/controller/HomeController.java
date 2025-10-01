package fai.web.spring.controller;
import java.sql.SQLException;

import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.ResponseBody;
import org.springframework.web.servlet.ModelAndView;

import fai.web.spring.Model.Conexao;
import fai.web.spring.Model.Email;


@Controller
public class HomeController {
@GetMapping("/")
public ModelAndView rotaBase(){
    ModelAndView mv = new ModelAndView("index");
    return mv;
}

@GetMapping("/hello/{name}/{age}")
@ResponseBody
public void RotaHello(@PathVariable("name") String name,@PathVariable("age") int age) {
    System.out.println(name);
    System.out.println(age);
    }



    @GetMapping("/contato")
    public ModelAndView RotaFormularioContato(){
        ModelAndView mv = new ModelAndView("contato");
        return mv;
    }

@PostMapping("/contact")
public ModelAndView RotaEnviaContato(
        @RequestParam String name,
        @RequestParam String email,
        @RequestParam(required = false) String phone,
        @RequestParam String subject,
        @RequestParam String message
) throws SQLException {

    Conexao conn = new Conexao();

    System.out.println("Contato recebido de: " + name + " <" + email + ">");
    System.out.println("Telefone: " + phone);
    System.out.println("Assunto: " + subject);
    System.out.println("Mensagem: " + message);

    Email contato = new Email(name, email, phone, subject, message);
    contato.persistirEmail(conn);

    ModelAndView mv = new ModelAndView("sucessoemailenviado");
    // Passando dados para a view
    mv.addObject("name", name);
    mv.addObject("email", email);
    mv.addObject("phone", phone);
    mv.addObject("subject", subject);
    mv.addObject("message", message);

    return mv;

    
}
}


/*
 * 
 * 
 * CREATE DATABASE contatosdb;

USE contatosdb;

CREATE TABLE contatos (
    id INT AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(100) NOT NULL,
    email VARCHAR(150) NOT NULL,
    phone VARCHAR(20),
    subject VARCHAR(150) NOT NULL,
    message TEXT NOT NULL,
    consent VARCHAR(10),
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);



 */