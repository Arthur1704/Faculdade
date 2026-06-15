package com.example.prova;

import android.content.Intent;
import android.content.SharedPreferences;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Spinner;
import android.widget.Toast;

import androidx.activity.EdgeToEdge;
import androidx.appcompat.app.AppCompatActivity;
import androidx.core.graphics.Insets;
import androidx.core.view.ViewCompat;
import androidx.core.view.WindowInsetsCompat;

import com.google.gson.Gson;
import com.google.gson.reflect.TypeToken;

import java.lang.reflect.Type;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Collections;
import java.util.Date;
import java.util.Locale;
import java.util.UUID;


public class MainActivity2 extends AppCompatActivity {


    EditText edt_titulo, edt_conteudo, edt_data;
    Spinner spn_tipo, spn_dificuldade;

    Button btn_ver_aulas, btn_salvar, btn_excluir;

    ArrayList <Aula> aulas = new ArrayList<>();
    ArrayList <String> tipos = new ArrayList<>();
    ArrayList <String> dificuldades = new ArrayList<>();

    Gson gson = new Gson();

    String id_edicao = null;

    int posicao_edicao = -1;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        EdgeToEdge.enable(this);
        setContentView(R.layout.activity_main2);
        ViewCompat.setOnApplyWindowInsetsListener(findViewById(R.id.main), (v, insets) -> {
            Insets systemBars = insets.getInsets(WindowInsetsCompat.Type.systemBars());
            v.setPadding(systemBars.left, systemBars.top, systemBars.right, systemBars.bottom);
            return insets;
        });

        edt_data = findViewById(R.id.edt_data);
        edt_titulo = findViewById(R.id.edt_titulo);
        edt_conteudo = findViewById(R.id.edt_conteudo);
        spn_tipo = findViewById(R.id.spn_tipo);
        spn_dificuldade = findViewById(R.id.spn_dificuldade);

        btn_salvar = findViewById(R.id.btn_salvar);
        btn_ver_aulas = findViewById(R.id.btn_ver_aulas);
        btn_excluir = findViewById(R.id.btn_excluir);

        Collections.addAll(tipos, "Desenvolvimento", "Hardware", "Banco de Dados", "Informatica Basica");
        Collections.addAll(dificuldades, "Facil", "Medio", "Dificil");
        edt_data.setText(new SimpleDateFormat(
                "dd/MM/yyyy",
                Locale.getDefault()
        ).format(new Date()));
        edt_data.setEnabled(false);

        carregarAulas();
        receber_dados_edicao();

        btn_salvar.setOnClickListener(v->cadastrar_aula());
        btn_excluir.setOnClickListener(v->excluir_pessoa());
        btn_ver_aulas.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent i = new Intent(MainActivity2.this, MainActivity3.class);
                startActivity(i);
            }
        });

    }

    private void carregarAulas() {
        SharedPreferences prefs = getSharedPreferences("aulas", MODE_PRIVATE);

        String json = prefs.getString("lista_aulas", "");

        Type type = new TypeToken<ArrayList<Aula>>(){}.getType();

        aulas = gson.fromJson(json, type);

        if(aulas == null){
            aulas = new ArrayList<>();
        }
    }
    private void cadastrar_aula(){
        String titulo = edt_titulo.getText().toString();
        String conteudo = edt_conteudo.getText().toString();
        String tipo = spn_tipo.getSelectedItem().toString();
        String dificuldade = spn_dificuldade.getSelectedItem().toString();
        String data = new SimpleDateFormat(
                "dd/MM/yyyy",
                Locale.getDefault()
        ).format(new Date());

        if (titulo.isEmpty() || conteudo.isEmpty() || tipo.isEmpty() || dificuldade.isEmpty()){
            Toast.makeText(this,
                    "Preencha todos os campos",
                    Toast.LENGTH_SHORT).show();
            return;
        }

        if (id_edicao == null){
            Aula aula = new Aula(
                    UUID.randomUUID().toString(),
                    titulo,
                    tipo,
                    dificuldade,
                    data,
                    conteudo
            );
        aulas.add(aula);
        }
        else{
            Aula aula_atualizada = new Aula(id_edicao, titulo, tipo, dificuldade, data, conteudo);
            aulas.set(posicao_edicao, aula_atualizada);
        }

        salvar_aula();

        Toast.makeText(this,
                "Salvo com sucesso",
                Toast.LENGTH_SHORT).show();

        limparCampos();
    }

    private void salvar_aula(){
        SharedPreferences prefs = getSharedPreferences("aulas", MODE_PRIVATE);

        String json = gson.toJson(aulas);

        prefs.edit()
                .putString("lista_aulas", json)
                .apply();
    }


    public void limparCampos(){
        edt_conteudo.setText("");
        edt_titulo.setText("");
        id_edicao = null;
        posicao_edicao = -1;
    }

    public void receber_dados_edicao(){
        String id_recebido = getIntent().getStringExtra("id");

        if (id_recebido == null){
            return;
        }

        for (int cont = 0; cont < aulas.size(); cont++){
            Aula aula = aulas.get(cont);

            if (aula.getId().equals(id_recebido)){
                edt_titulo.setText(aula.getTitulo());
                spn_tipo.setSelection(posicao_spinner(tipos, aula.getTipo()));
                spn_dificuldade.setSelection(posicao_spinner(dificuldades, aula.getDificuldade()));
                edt_data.setText(aula.getData());
                edt_conteudo.setText(aula.getConteudo());
                id_edicao = aula.getId();
                posicao_edicao = cont;
                break;
            }
        }
    }

    public void excluir_pessoa(){
        if (posicao_edicao == -1){
            Toast.makeText(this,
                    "Nenhum cadastro selecionado",
                    Toast.LENGTH_SHORT).show();

            return;
        }

        aulas.remove(posicao_edicao);
        salvar_aula();

        Toast.makeText(this,
                "Excluído com sucesso",
                Toast.LENGTH_SHORT).show();

        limparCampos();
    }

    public int posicao_spinner(ArrayList<String> lista, String valor){
        for(int cont = 0; cont < lista.size(); cont++){
            if(lista.get(cont).equals(valor)){
                return cont;
            }
        }
        return -1;
    }

}