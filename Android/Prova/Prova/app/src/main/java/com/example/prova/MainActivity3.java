package com.example.prova;

import android.content.Intent;
import android.content.SharedPreferences;
import android.os.Bundle;
import android.view.View;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ListView;

import androidx.activity.EdgeToEdge;
import androidx.appcompat.app.AppCompatActivity;
import androidx.core.graphics.Insets;
import androidx.core.view.ViewCompat;
import androidx.core.view.WindowInsetsCompat;

import com.google.gson.Gson;
import com.google.gson.reflect.TypeToken;

import java.lang.reflect.Type;
import java.util.ArrayList;

public class MainActivity3 extends AppCompatActivity {

    ListView list_view_aulas;

    ArrayList<Aula> aulas;
    Button btn_retonar;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        EdgeToEdge.enable(this);
        setContentView(R.layout.activity_main3);
        ViewCompat.setOnApplyWindowInsetsListener(findViewById(R.id.main), (v, insets) -> {
            Insets systemBars = insets.getInsets(WindowInsetsCompat.Type.systemBars());
            v.setPadding(systemBars.left, systemBars.top, systemBars.right, systemBars.bottom);
            return insets;
        });

        list_view_aulas = findViewById(R.id.list_view_aulas);
        btn_retonar = findViewById(R.id.btn_retornar);

        carregar_aulas();

        btn_retonar.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent i = new Intent(MainActivity3.this, MainActivity2.class);

                startActivity(i);
            }
        });
    }

    public void carregar_aulas(){
        SharedPreferences pref = getSharedPreferences("aulas", MODE_PRIVATE);

        Gson gson = new Gson();

        String json = pref.getString("lista_aulas", "");

        Type type = new TypeToken<ArrayList<Aula>>(){}.getType();

        aulas = gson.fromJson(json, type);

        if (aulas == null){
            aulas = new ArrayList<>();
        }

        ArrayList<String> titulos = new ArrayList<>();

        for (Aula aula : aulas){
            titulos.add(
                aula.getTitulo()
                + " - "
                + aula.getTipo()
                + " - "
                + aula.getDificuldade()
                + " - "
                + aula.getData()
                + " - "
                + aula.getConteudo()
                );
        }

        ArrayAdapter adapter = new ArrayAdapter(
            this,
            R.layout.item_lista,
            titulos
        );

        list_view_aulas.setAdapter(adapter);

        list_view_aulas.setOnItemClickListener((parent, view, position, id) -> {
            Aula aula = aulas.get(position);

            Intent i = new Intent(MainActivity3.this, MainActivity2.class);
            i.putExtra("id", aula.getId());
            startActivity(i);
        });
    }
}