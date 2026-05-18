package com.example.myapplication;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.CheckBox;

import androidx.activity.EdgeToEdge;
import androidx.appcompat.app.AppCompatActivity;
import androidx.core.graphics.Insets;
import androidx.core.view.ViewCompat;
import androidx.core.view.WindowInsetsCompat;

import java.util.ArrayList;
import java.util.List;

public class MainActivity4 extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        EdgeToEdge.enable(this);
        setContentView(R.layout.activity_main4);
        ViewCompat.setOnApplyWindowInsetsListener(findViewById(R.id.main), (v, insets) -> {
            Insets systemBars = insets.getInsets(WindowInsetsCompat.Type.systemBars());
            v.setPadding(systemBars.left, systemBars.top, systemBars.right, systemBars.bottom);
            return insets;
        });

        Button btn_enviar = findViewById(R.id.btn_submit_4);
        ArrayList<CheckBox> checks = new ArrayList<>();

        checks.add(findViewById(R.id.cbx_piscina));
        checks.add(findViewById(R.id.cbx_lavanderia));
        checks.add(findViewById(R.id.cbx_area));

        btn_enviar.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                MeuApp app = (MeuApp) getApplication();
                for (CheckBox check : checks){
                    if (check.isChecked()){
                        app.addPreferencias(check.getText().toString());
                    }
                }

                Intent i = new Intent(MainActivity4.this, MainActivity5.class);

                startActivity(i);
            }
        });
    }
}