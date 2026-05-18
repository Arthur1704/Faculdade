package com.example.myapplication;

import android.os.Bundle;
import android.widget.TextView;

import androidx.activity.EdgeToEdge;
import androidx.appcompat.app.AppCompatActivity;
import androidx.core.graphics.Insets;
import androidx.core.view.ViewCompat;
import androidx.core.view.WindowInsetsCompat;

import java.util.ArrayList;

public class MainActivity5 extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        EdgeToEdge.enable(this);
        setContentView(R.layout.activity_main5);
        ViewCompat.setOnApplyWindowInsetsListener(findViewById(R.id.main), (v, insets) -> {
            Insets systemBars = insets.getInsets(WindowInsetsCompat.Type.systemBars());
            v.setPadding(systemBars.left, systemBars.top, systemBars.right, systemBars.bottom);
            return insets;
        });

        TextView txt_cidade = findViewById(R.id.txt_cidade);
        TextView txt_estado = findViewById(R.id.txt_estado);
        TextView txt_quatos = findViewById(R.id.txt_quartos);
        TextView txt_banheiros = findViewById(R.id.txt_banheiros);
        TextView txt_garagem = findViewById(R.id.txt_garagem);
        TextView txt_preferencias = findViewById(R.id.txt_preferencias);
        String garagem;
        String preferencias = "";

        MeuApp app = (MeuApp) getApplication();

        if (app.isGaragem()){
            garagem = "Sim";
        }
        else{
            garagem = "Não";
        }

        for (String pref : app.getPreferencias()){
            preferencias += pref + ", ";
        }

        txt_cidade.setText(app.getCidade());
        txt_estado.setText(app.getUf());
        txt_quatos.setText(String.valueOf(app.getQuartos()));
        txt_banheiros.setText(String.valueOf(app.getBanheiros()));
        txt_garagem.setText(garagem);
        txt_preferencias.setText(preferencias);


    }
}