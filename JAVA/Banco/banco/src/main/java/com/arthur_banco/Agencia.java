package com.arthur_banco;
import java.util.Scanner;


public class Agencia extends Banco{
    public static Scanner guardar = new Scanner(System.in);
    String num_Agencia;


    protected Agencia(){

    }

    protected Agencia(String nome, String sede, String telefone, String numA){

        this.nome_banco = nome;
        this.telefone = telefone;
        this.sede = sede;
        this.num_Agencia = numA;

    }

    
}
