/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package com.mycompany.criptrogafador;

public class Login{
    
    private String nome;
    private String sobrenome;
    private String login = "root";
    private String senha = "root";
    private Metodos_Criptografia metodos = new Metodos_Criptografia();
    
    public int verifica(String login_C, String senha_C){
        
        System.out.println(senha_C);
        if(metodos.Metodo_arthur_descriptografa(login_C).equals(this.login)){
            if(metodos.Metodo_arthur_descriptografa(senha_C).equals(this.senha)){
             return 1;
            }
        }
        return 0;
    }    
}
