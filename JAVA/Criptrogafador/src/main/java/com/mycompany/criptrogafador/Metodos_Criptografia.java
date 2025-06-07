/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package com.mycompany.criptrogafador;
import java.util.ArrayList;

/**
 *
 * @author unifai
 */
public class Metodos_Criptografia {
    
    ArrayList<Integer> numeros_array = new ArrayList<>();
    
    ArrayList<String> frase_array = new ArrayList<>();
    public String metodo_utilizado;    
    private int letra_numero(char letra){
        return (int) letra;
    }
    
    private String numero_letra (String numeros[]){
       int[]   numeros_int = new int[numeros.length];
       char [] letras = new char[numeros.length];
       String frase = "";
       for(int cont = 0; cont < numeros.length; cont++){
          numeros_int[cont] = Integer.parseInt(numeros[cont]);
          letras[cont] = (char) numeros_int[cont];
          frase += letras[cont];
       }
       return frase;
    }
    
    private String[] separa_numero(String numero){                 
        
        String[] partes = numero.split("-");

        
        return partes;
    }
    
    private String num_combinados(ArrayList<Integer> num){
        
        String numS = "";
        for (Integer nume : num){
            numS += nume.toString();
            numS += "-";
        }
        
        return numS;
    }
   
    
    
    
    public String Metodo_arthur_criptografa(String texto){
        numeros_array.clear();
        for (int cont = 0; cont < texto.length(); cont++){
            char letra = texto.charAt(cont);
            try{               
                numeros_array.add(letra_numero(letra));
            }
            catch(Exception e){
                
            }    
        }
        this.metodo_utilizado = "ARTHUR";
        String numero = num_combinados(numeros_array);
        return numero;
    }
    
    public String Metodo_arthur_descriptografa(String num){
        String[] numeros = separa_numero(num);
        String frase = numero_letra(numeros);
        return frase;    
    }
    
    public String criptografarTextoCesar(String textoOriginal) {
        
        StringBuilder criptografado = new StringBuilder();
        for (char c : textoOriginal.toCharArray()) {
            criptografado.append((char) (c + 3));
        }
        metodo_utilizado = "CESAR";
        return criptografado.toString();
    }
    
    public String descriptografarTextoCesar(String textoCriptografado) {
        
        StringBuilder decriptografado = new StringBuilder();
        for (char c : textoCriptografado.toCharArray()) {
            decriptografado.append((char) (c - 3));
        }
       return decriptografado.toString();
    }
    
    
    
    
    
}
