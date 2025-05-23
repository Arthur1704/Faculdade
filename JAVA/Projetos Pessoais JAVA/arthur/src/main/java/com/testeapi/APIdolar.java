package com.testeapi;
import java.io.BufferedReader;
import java.io.InputStreamReader;
import java.net.HttpURLConnection;
import java.net.URL;
import java.net.URI;
import org.json.JSONObject;

public class APIdolar {
    public double valorDolarAgora(){
        try {
            
            String api = "https://economia.awesomeapi.com.br/json/last/USD-BRL";
            URI uri = new URI(api); 
            URL url = uri.toURL(); 
            HttpURLConnection conexao = (HttpURLConnection) url.openConnection();
            conexao.setRequestMethod("GET");

            BufferedReader reader = new BufferedReader(new InputStreamReader(conexao.getInputStream()));
            StringBuilder resposta = new StringBuilder();
            String linha;
            while ((linha = reader.readLine()) != null) {
                resposta.append(linha);
            }
            reader.close();

            JSONObject jsonresposta = new JSONObject(resposta.toString());
            JSONObject usdbrl = jsonresposta.getJSONObject("USDBRL");
            String valorDolarS = usdbrl.getString("bid");
            double valorDolar = Double.parseDouble(valorDolarS);

            return valorDolar;
            

        } catch (Exception e) {
            return -1;
        }
    }
}


