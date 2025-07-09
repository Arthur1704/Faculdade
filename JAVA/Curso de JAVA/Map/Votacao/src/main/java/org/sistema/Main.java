package org.sistema;

import java.io.BufferedReader;
import java.io.FileReader;
import java.io.IOException;
import java.util.HashMap;
import java.util.Map;
import java.util.Scanner;


public class Main {
    public static void main(String[] args) {
        //TIP Press <shortcut actionId="ShowIntentionActions"/> with your caret at the highlighted text
        // to see how IntelliJ IDEA suggests fixing it.
        Scanner guardar = new Scanner(System.in);

        System.out.print("Entre com o caminho do arquivo: ");
        String caminho = guardar.nextLine();

        try (BufferedReader br = new BufferedReader(new FileReader(caminho))){
            String line = br.readLine();
            Map<String, Integer> candidatos = new HashMap<>();
            while(line != null) {
                String[] fields = line.split(",");
                String nome = fields[0];
                int votos = Integer.parseInt(fields[1]);

                if (candidatos.containsKey(fields[0])) {
                    candidatos.put(nome, candidatos.get(nome) + votos);
                } else{
                    candidatos.put(nome, votos);
                }
                line = br.readLine();
            }
            for(String key : candidatos.keySet()){
                System.out.println(key + ": " + candidatos.get(key));
            }

        } catch (IOException e) {
            System.out.println(e.getMessage());
        }
    }
}