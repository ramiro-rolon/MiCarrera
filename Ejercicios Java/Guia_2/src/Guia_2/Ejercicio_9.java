package Guia_2;

import java.awt.*;

import javax.swing.JFrame;
import javax.swing.JPanel;
import javax.swing.border.EmptyBorder;
import javax.swing.JLabel;
import java.awt.Font;
import java.awt.FlowLayout;
import java.awt.BorderLayout;
import javax.swing.SwingConstants;
import javax.swing.JButton;
import java.awt.event.ActionListener;
import java.awt.event.ActionEvent;

public class Ejercicio_9 extends JFrame {

	private static final long serialVersionUID = 1L;
	private JPanel contentPane;

	/**
	 * Launch the application.
	 */
	public static void main(String[] args) {
		EventQueue.invokeLater(new Runnable() {
			public void run() {
				try {
					Ejercicio_9 frame = new Ejercicio_9();
					frame.setVisible(true);
				} catch (Exception e) {
					e.printStackTrace();
				}
			}
		});
	}

	/**
	 * Create the frame.
	 */
	public Ejercicio_9() {
		setResizable(false);
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		setBounds(100, 100, 1024, 800);
		contentPane = new JPanel();
		contentPane.setBorder(new EmptyBorder(5, 5, 5, 5));
		setContentPane(contentPane);
		contentPane.setLayout(new BorderLayout(0, 0));
		
		JPanel panel = new JPanel();
		contentPane.add(panel, BorderLayout.NORTH);
		
		JLabel lblNewLabel = new JLabel("PROGRAMA EJERCICIO 9 y 10");
		lblNewLabel.setFont(new Font("Tahoma", Font.PLAIN, 69));
		panel.add(lblNewLabel);
		
		JPanel panel_1 = new JPanel();
		contentPane.add(panel_1, BorderLayout.CENTER);
		panel_1.setLayout(null);
		
		JLabel lblNombre1 = new JLabel("Ramiro");
		lblNombre1.setFont(new Font("Tahoma", Font.PLAIN, 16));
		lblNombre1.setBounds(152, 87, 57, 41);
		panel_1.add(lblNombre1);
		
		JLabel lblNombre2 = new JLabel("Ramiro");
		lblNombre2.setFont(new Font("Tahoma", Font.PLAIN, 16));
		lblNombre2.setBounds(152, 132, 57, 41);
		panel_1.add(lblNombre2);
		
		JLabel lblNombre3 = new JLabel("Ramiro");
		lblNombre3.setFont(new Font("Tahoma", Font.PLAIN, 16));
		lblNombre3.setBounds(152, 184, 57, 41);
		panel_1.add(lblNombre3);
		
		JLabel lblColor1 = new JLabel("");
		lblColor1.setBounds(438, 102, 215, 14);
		panel_1.add(lblColor1);
		
		JLabel lblColor2 = new JLabel("");
		lblColor2.setBounds(438, 147, 215, 14);
		panel_1.add(lblColor2);
		
		JLabel lblColor3 = new JLabel("");
		lblColor3.setBounds(438, 199, 215, 14);
		panel_1.add(lblColor3);
		
		JButton btnNombre1 = new JButton("New button");
		btnNombre1.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				// 1. Generar valores aleatorios para Red, Green y Blue (0-255)
				int r = (int)(Math.random() * 256);
				int g = (int)(Math.random() * 256);
				int b = (int)(Math.random() * 256);

				// 2. Crear el objeto Color
				Color colorAzar = new Color(r, g, b);

				// 3. Cambiar el color del texto del Label del nombre
				lblNombre1.setForeground(colorAzar);

				// 4. Mostrar el color elegido (puedes poner el nombre en texto o pintar el fondo)
				lblColor1.setText ("RGB: (" + r + "," + g + "," + b + ")");
				
			}
		});
		btnNombre1.setBounds(260, 96, 89, 23);
		panel_1.add(btnNombre1);
		
		JButton btnNombre2 = new JButton("New button");
		btnNombre2.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				int r = (int)(Math.random() * 256);
				int g = (int)(Math.random() * 256);
				int b = (int)(Math.random() * 256);

				Color colorAzar = new Color(r, g, b);

				lblNombre2.setForeground(colorAzar);

				lblColor2.setText ("RGB: (" + r + "," + g + "," + b + ")");
				
			}
		});
		btnNombre2.setBounds(260, 141, 89, 23);
		panel_1.add(btnNombre2);
		
		JButton btnNombre3 = new JButton("New button");
		btnNombre3.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				int r = (int)(Math.random()*256);
				int g = (int)(Math.random()*256);
				int b = (int)(Math.random()*256);
				
				Color ColorAzar = new Color(r, g, b);
				lblNombre3.setForeground(ColorAzar);
				lblColor3.setText("RGB: (" + r + "," + g + "," + b + ")");
			}
		});
		btnNombre3.setBounds(260, 193, 89, 23);
		panel_1.add(btnNombre3);
		

		
		JPanel panel_2 = new JPanel();
		contentPane.add(panel_2, BorderLayout.SOUTH);
		
		JLabel lblNewLabel_1 = new JLabel("Edicion 1.1");
		panel_2.add(lblNewLabel_1);
		
		JPanel panel_3 = new JPanel();
		contentPane.add(panel_3, BorderLayout.WEST);
		
		JPanel panel_4 = new JPanel();
		contentPane.add(panel_4, BorderLayout.EAST);

	}
	
}
