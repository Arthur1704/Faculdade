package com.testeapi;
import java.io.BufferedReader;
import java.io.InputStreamReader;
import java.net.HttpURLConnection;
import java.net.URL;
import java.net.URI;
import org.json.JSONObject;

public class Euro{

    public double valorEuroAgora(){
        try{    

            String api = "https://economia.awesomeapi.com.br/json/last/EUR-BRL";
            URI uri = new URI(api);
            URL url = uri.toURL(); 

            HttpURLConnection conexao = (HttpURLConnection) url.openConnection();
            conexao.setRequestMethod("GET");

            BufferedReader reader = new BufferedReader(new InputStreamReader(conexao.getInputStream()));
            StringBuilder resposta = new StringBuilder();
            String linha;

            while((linha = reader.readLine()) != null){
                resposta.append(linha);
            }
            reader.close();

            JSONObject respostajson = new JSONObject(resposta.toString());
            JSONObject eurbrl = respostajson.getJSONObject("EURBRL");
            String valorEuroS = eurbrl.getString("bid");
            double valorEuro = Double.parseDouble(valorEuroS);

            return valorEuro;

        }
        catch(Exception e){
            return -1;
        }
    }


}
