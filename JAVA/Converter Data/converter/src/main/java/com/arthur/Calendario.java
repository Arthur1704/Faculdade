package com.arthur;

public class Calendario {
    private String S_mes;
    public String converterMes_string(int mes){
        
        if(mes < 10){
            switch(mes){
                case 1:
                    S_mes = "Janeiro";
                    break;
                case 2:
                    S_mes = "Fevereiro";
                    break;
                case 3:
                    S_mes = "Março";
                    break;
                case 4:
                    S_mes = "Abril";
                    break;
                case 5:
                    S_mes = "Maio";    
                    break;
                case 6:
                    S_mes = "Junho";
                    break;
                case 7:
                    S_mes = "Julho";
                    break;
                case 8:
                    S_mes = "Agosto";
                    break;
                case 9:
                    S_mes = "Setembro";
                    break;
            }
        }
        else if(mes >= 10){
            switch (mes) {
                case 10:
                    S_mes = "Outubro";
                    break;
                case 11:
                    S_mes = "Novembro";
                    break;
                case 12:
                    S_mes = "Dezembro";
                    break;
            }
        }
        else{
            S_mes = "Mês Invalido";
        }
        return S_mes;
    }
}
