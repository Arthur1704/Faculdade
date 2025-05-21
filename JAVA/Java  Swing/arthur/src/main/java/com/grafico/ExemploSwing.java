package com.grafico;

import javax.swing.JButton;
import javax.swing.JFrame;
import javax.swing.JOptionPane;
import javax.swing.JPanel;
import java.awt.event.ActionListener;
import java.awt.event.ActionEvent;

public class ExemploSwing implements ActionListener {

     public void actionPerformed(ActionEvent e){
        JOptionPane.showMessageDialog(null, "Você clicou no botão");
    }
    
    public void runTela(){    
        JFrame janela = new JFrame("Minha Janela");
        JPanel painel = new JPanel();

        
        JButton botao = new JButton("Clique em mim!!");
        botao.addActionListener(new ExemploSwing());

        janela.setSize(800, 600);

        janela.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);

        painel.add(botao);

        janela.add(painel);

        janela.setVisible(true);
    }
    public static void main(String[] args) {
    }
}