package com.arthur;

public class Calendario {
    private String[] meses = {
        "Janeiro", "Fevereiro", "Março", "Abril", "Maio", "Junho",
        "Julho", "Agosto", "Setembro", "Outubro", "Novembro", "Dezembro"
    };
    private String[] unidades = {
        "um", "dois", "tres", "quatro", "cinco", "seis", "sete", 
        "oito", "nove"
    };
    private String[] apos10 = {
        "dez", "onze", "doze", "treze", "quatorze", "quinze", "dezesseis",
        "dezessete", "dezoito", "dezenove"
    };

    public String converterMes_string(int mes) {
        if (mes > 0 && mes <= 12) {
            return meses[mes - 1];
        }
        return "Mês Inválido";
    }

    public int converterMes_num(String Smes) {
        for (int cont = 0; cont < 12; cont++) {
            String mesM = meses[cont].toUpperCase();
            Smes = Smes.toUpperCase();
            if (mesM.equals(Smes)) {
                return cont + 1;
            }
        }
        return -1;
    }

    private String converterDia_String(int dia) {
        int dezena = dia / 10;
        int unidade = dia % 10;
        String retorno;
        switch (dezena) {
            case 0:
                retorno = unidades[dia - 1];
                break;
            case 1:
                retorno = apos10[unidade];
                break;
            case 2:
                retorno = unidade != 0 ? "Vinte e " + unidades[unidade - 1] : "Vinte";
                break;
            case 3:
                switch (unidade) {
                    case 0:
                        retorno = "Trinta";
                        break;
                    case 1:
                        retorno = "Trinta e " + unidades[unidade - 1];
                        break;
                    default:
                        retorno = "Dia inválido!!";
                        break;
                }
                break;
            default:
                retorno = "Dia inválido!!";
                break;
        }
        return retorno;
    }

    public int converterDia_num(String dia) {
        String dezena, unidade;
        int retorno = 0;

        if (dia.contains(" ")) {
            String[] partes = dia.split(" ");
            if (partes.length > 1) {
                dezena = partes[0].toLowerCase();
                unidade = partes[1].toLowerCase();

                switch (dezena) {
                    case "vinte":
                        for (int cont = 0; cont < 9; cont++) {
                            if (unidade.equals(unidades[cont])) {
                                retorno = cont + 21;
                                break;
                            }
                        }
                        break;
                    default:
                        retorno = 31;
                        break;
                }
            } else {
                for (int cont = 0; cont < 9; cont++) {
                    if (dia.equals(unidades[cont])) {
                        retorno = cont + 1;
                        break;
                    }
                }
                for (int cont = 0; cont < 10; cont++) {
                    if (dia.equals(apos10[cont])) {
                        retorno = cont + 10;
                    }
                }
            }
        }
        return retorno;
    }

    private String converterAno(int ano) {
        String milhar, centena, dezena, unidade;
        int primeiroDigito = ano / 1000;
        int segundoDigito = (ano / 100) % 10; 
        int terceiroDigito = (ano / 10) % 10; 
        int quartoDigito = ano % 10;

        String[] mils = {
            "", "Mil ", "Dois mil "
        };

        String[] centenas = {
            "", "cento ", "duzentos ", "trezentos ", "quatrocentos ", "quinhentos ",
            "seicentos ", "setecentos ", "oitocentos ", "novecentos " 
        };

        String[] dezenas = {
            "", "dez ", "vinte ", "trinta ", "quarenta ", "cinquenta ", "secenta ",
            "setenta ", "oitenta ", "noventa "
        };

        String[] unidades = {
            "", "um", "dois", "tres", "quatro", "cinco", "seis", "sete", 
            "oito", "nove"
        };

        milhar = mils[primeiroDigito];
        centena = centenas[segundoDigito];
        dezena = dezenas[terceiroDigito];
        unidade = unidades[quartoDigito];

        return milhar + centena + dezena + (unidade.isEmpty() ? "" : "e " + unidade); 
    }

    public String converteDataParaTexto(int dia, int mes, int ano) {
        String diaS = converterDia_String(dia);
        String mesS = converterMes_string(mes);
        String anoS = converterAno(ano);

        return diaS + " de " + mesS + " de " + anoS;
    }    
}
