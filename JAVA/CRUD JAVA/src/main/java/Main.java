
import connection.ConnectionDB;
import javax.swing.JFrame;

/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */

/**
 *
 * @author TI
 */
public class Main {
    public static void main(String[] args) {
        ConnectionDB con = new ConnectionDB();
        con.connect();
        // Criar o JFrame
        JFrame frame = new JFrame("Sistema CRUD");
        frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        frame.setSize(600, 400); // Tamanho da janela

        // Adicionar o Panel
        Panel panel = new Panel();
        frame.add(panel);

        // Tornar a janela visível
        frame.setVisible(true);
        
        java.awt.EventQueue.invokeLater(() -> {
            new Panel().setVisible(true);
        });
    }
}