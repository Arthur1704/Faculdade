package com.arthur;

public class Main {

    public static void analisarPalavra(String palavra) {
        palavra = palavra.toLowerCase();

        String[] prefixos = { "des", "in", "re" };
        String[] sufixos = { "mente", "idade", "eiro", "ista", "oso", "aria", "dade" };
        String[] desinencias = { "amos", "ei", "ia", "ndo", "mos", "ram", "ria" };

        String prefixo = "";
        String sufixo = "";
        String desinencia = "";

        for (String p : prefixos) {
            if (palavra.startsWith(p)) {
                prefixo = p;
                break;
            }
        }

        String semPrefixo = palavra;
        if (!prefixo.equals("")) {
            semPrefixo = palavra.substring(prefixo.length());
        }

        for (String s : sufixos) {
            if (semPrefixo.endsWith(s)) {
                sufixo = s;
                break;
            }
        }

        String semSufixo = semPrefixo;
        if (!sufixo.equals("")) {
            semSufixo = semPrefixo.substring(0, semPrefixo.length() - sufixo.length());
        }

        for (String d : desinencias) {
            if (semSufixo.endsWith(d)) {
                desinencia = d;
                break;
            }
        }

        String radical = semSufixo;
        if (!desinencia.equals("")) {
            radical = semSufixo.substring(0, semSufixo.length() - desinencia.length());
        }

        String vogal = "";
        if (radical.length() > 0) {
            char ultima = radical.charAt(radical.length() - 1);
            if (ultima == 'a' || ultima == 'e' || ultima == 'i') {
                vogal = String.valueOf(ultima);
                radical = radical.substring(0, radical.length() - 1);
            }
        }

        System.out.println(palavra + ":");
        System.out.println("  RADICAL: '" + radical + "'");
        System.out.println("  VOGAL: '" + vogal + "'");
        System.out.println("  PREFIXO: " + prefixo);
        System.out.println("  SUFIXO: " + sufixo);
        System.out.println("  DESINENCIA: " + desinencia);
        System.out.println();
    }

    public static void main(String[] args) {

        String[] palavras = {
                "Verdadeiro", "Veracidade", "Falsidade", "Refiz", "Refazendo"
        };

        for (String p : palavras) {
            analisarPalavra(p);
        }
    }
}