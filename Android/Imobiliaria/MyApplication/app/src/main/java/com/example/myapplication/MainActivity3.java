package com.example.myapplication;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.RadioButton;
import android.widget.RadioGroup;

import androidx.activity.EdgeToEdge;
import androidx.appcompat.app.AppCompatActivity;
import androidx.core.graphics.Insets;
import androidx.core.view.ViewCompat;
import androidx.core.view.WindowInsetsCompat;

public class MainActivity3 extends AppCompatActivity {

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

        Button btn_enviar = findViewById(R.id.btn_submit_3);

        RadioGroup rg_quartos = findViewById(R.id.rgQuartos);
        RadioGroup rg_banheiros = findViewById(R.id.rgBanheiros);
        RadioGroup rg_garagem = findViewById(R.id.rgGaragem);



        btn_enviar.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                int id_quarto = rg_quartos.getCheckedRadioButtonId();
                int id_ban = rg_banheiros.getCheckedRadioButtonId();
                int id_garagem = rg_garagem.getCheckedRadioButtonId();

                RadioButton rb_quartos = findViewById(id_quarto);
                RadioButton rb_ban = findViewById(id_ban);
                RadioButton rb_garagem = findViewById(id_garagem);

                int quartos = Integer.parseInt(rb_quartos.getText().toString());
                int banheiros = Integer.parseInt(rb_ban.getText().toString());

                String garagem_string = rb_garagem.getText().toString().toLowerCase();
                Boolean garagem;
                if (garagem_string.equals("sim")){
                    garagem = true;
                }
                else{
                    garagem = false;
                }

                MeuApp app = (MeuApp) getApplication();

                app.setQuartos(quartos);
                app.setBanheiros(banheiros);
                app.setGaragem(garagem);

                Intent i = new Intent(MainActivity3.this, MainActivity4.class);

                startActivity(i);
            }
        });
    }
}