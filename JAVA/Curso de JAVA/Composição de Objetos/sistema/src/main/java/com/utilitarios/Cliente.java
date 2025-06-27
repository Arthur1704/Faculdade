package com.utilitarios;

import java.text.SimpleDateFormat;
import java.util.Date;

public class Cliente {

    private static SimpleDateFormat format = new SimpleDateFormat("dd/MM/yyyy");
    private String nome;
    private String email;
    private Date data_aniversario;

    public Cliente(String nome, String email, Date data){
        this.nome = nome;
        this.email = email;
        this.data_aniversario = data;
    }

    public void setNome(String nome){
        this.nome = nome;
    }

    public String getNome(){
        return nome;
    }

    public void setEmail(String email){
        this.email = email;
    }

    public String getEmail(){
        return email;
    }

    public void setData(Date data){
        this.data_aniversario = data;
    }

    public Date getData(){
        return data_aniversario;
    }

    public String toString(){
        return nome + " (" +format.format(data_aniversario) + ") - " + email;
    }
}
