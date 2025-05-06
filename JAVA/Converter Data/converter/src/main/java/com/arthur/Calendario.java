package com.arthur;

public class Calendario {
    private String[] meses = {
        "Janeiro", "Fevereiro", "Março", "Abril", "Maio", "Junho",
        "Julho", "Agosto", "Setembro", "Outubro", "Novembro", "Dezembro"
    };


    public String converterMes_string(int mes){
        if (mes > 0 && mes < 12){
            return meses[mes-1];
        }
        return "Mês Invalido";
    }

    public int ConverterMes_num(String Smes){
        for (int cont = 0; cont < 12; cont++){
            String mesM = meses[cont].toUpperCase();
            Smes = Smes.toUpperCase();
            if (mesM.equals(Smes)){
                return cont+1;
            }
        }
        return -1;
    }
}
