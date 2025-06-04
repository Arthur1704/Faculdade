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
    
    private String numero_letra (int numero){
        return Integer.toString(numero);
    }
    
    private ArrayList<Integer> numero_ArrayList(int numero){
        ArrayList<Integer> array = new ArrayList<>();
        String numeroString = String.valueOf(numero);
        
        for (char caracter : numeroString.toCharArray()){
            array.add(Character.getNumericValue(caracter));
        }
        
        return array;
    }
    
    private String string_combinada(ArrayList<String> array){
        String frase = String.join(" ", array);
        return frase;
    }
    
    private String num_combinados(ArrayList<Integer> num){
        
        String numS = "";
        for (Integer nume : num){
            numS += nume.toString();
        }
        
        return numS;
    }
   
    
    
    
    public String Metodo_arthur_criptografa(String texto){
        for (int cont = 0; cont < texto.length(); cont++){
            char letra = texto.charAt(cont);
            try{
               //System.out.println(letra_numero(letra));
                numeros_array.add(letra_numero(letra));
            }
            catch(Exception e){
                
            }    
        }
        metodo_utilizado = "ARTHUR";
        String numero = num_combinados(numeros_array);
        return numero;
    }
    
    public String Metodo_arthur_descriptografa(int num){
        ArrayList<Integer> numeros =  numero_ArrayList(num);
        for (Integer numero : numeros){
            frase_array.add(numero_letra(numero));
        }
        String frase = string_combinada(frase_array);
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
