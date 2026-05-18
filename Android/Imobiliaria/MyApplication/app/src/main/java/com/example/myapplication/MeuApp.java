package com.example.myapplication;
import android.app.Application;

import java.util.ArrayList;

public class MeuApp extends Application{
    private String cidade;
    private String uf;
    private int quartos;
    private int banheiros;
    private boolean garagem;
    private ArrayList<String> preferencias = new ArrayList<>();

    public String getCidade() {
        return cidade;
    }

    public void setCidade(String cidade) {
        this.cidade = cidade;
    }

    public String getUf() {
        return uf;
    }

    public void setUf(String uf) {
        this.uf = uf;
    }

    public int getQuartos() {
        return quartos;
    }

    public void setQuartos(int quartos) {
        this.quartos = quartos;
    }

    public int getBanheiros() {
        return banheiros;
    }

    public void setBanheiros(int banheiros) {
        this.banheiros = banheiros;
    }

    public boolean isGaragem() {
        return garagem;
    }

    public void setGaragem(boolean garagem) {
        this.garagem = garagem;
    }

    public ArrayList<String> getPreferencias() {
        return preferencias;
    }

    public void addPreferencias (String preferencia){
        this.preferencias.add(preferencia);
    }
}
