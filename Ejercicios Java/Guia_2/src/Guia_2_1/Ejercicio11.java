package Guia_2_1;

import javax.swing.*;
import javax.swing.JFrame;

import java.awt.*;
import java.awt.FlowLayout;
import javax.swing.JButton;
import javax.swing.JLabel;
import javax.swing.JOptionPane;

import java.awt.GridLayout;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

import javax.swing.BoxLayout;
import java.awt.Dimension;
import java.awt.EventQueue;

public class Ejercicio11 extends JFrame{

	private static final long serialVersionUID = 1L;
	private JFrame contentPane;
	
	public static void main(String[] args) {
		EventQueue.invokeLater(new Runnable() {
			public void run() {
				try {
					Ejercicio11 frame = new Ejercicio11();
					frame.setVisible(true);
				} catch (Exception e) {
					e.printStackTrace();
				}
			}
		});
	}/**
	 * Create the panel.
	 */
	public Ejercicio11() {
	setSize(new Dimension(1000, 600));
		getContentPane().setLayout(new BorderLayout(0, 0));
		
		ActionListener BotonNorte = new ActionListener() {
			@Override
			public void actionPerformed(ActionEvent e) {
				JOptionPane.showMessageDialog(null, "Este es del panel norte");
			}
		};

		ActionListener BotonSur = new ActionListener() {
			@Override
			public void actionPerformed(ActionEvent e) {
				JOptionPane.showMessageDialog(null, "Este es del panel sur");
			}
		};
		ActionListener BotonOeste = new ActionListener() {
			@Override
			public void actionPerformed(ActionEvent e) {
				JOptionPane.showMessageDialog(null, "Este es del panel oeste");
			}
		};
		ActionListener BotonEste = new ActionListener() {
			@Override
			public void actionPerformed(ActionEvent e) {
				JOptionPane.showMessageDialog(null, "Este es del panel este");
			}
		};
		ActionListener BotonCentral = new ActionListener() {
			@Override
			public void actionPerformed(ActionEvent e) {
				JOptionPane.showMessageDialog(null, "Este es del panel central");
			}
		};
		
		JPanel panel = new JPanel();
		getContentPane().add(panel, BorderLayout.NORTH);
		panel.setLayout(new FlowLayout(FlowLayout.CENTER, 5, 5));
		
		JButton btnBoton1 = new JButton("Boton 1");
		btnBoton1.addActionListener(BotonNorte);
		panel.add(btnBoton1);
		
		JButton btnBoton2 = new JButton("Boton 2");
		btnBoton2.addActionListener(BotonNorte);
		panel.add(btnBoton2);
		
		JButton btnBoton3 = new JButton("Boton 3");
		btnBoton3.addActionListener(BotonNorte);
		panel.add(btnBoton3);
		
		JButton btnBoton4 = new JButton("Boton 4");
		btnBoton4.addActionListener(BotonNorte);
		panel.add(btnBoton4);
		
		JPanel panel_1 = new JPanel();
		panel_1.setPreferredSize(new Dimension(200, 400));
		getContentPane().add(panel_1, BorderLayout.WEST);
		panel_1.setLayout(null);
		
		JButton btnNewButton = new JButton("New button");
		btnNewButton.addActionListener(BotonOeste);
		btnNewButton.setBounds(51, 107, 89, 23);
		panel_1.add(btnNewButton);
		
		JPanel panel_2 = new JPanel();
		getContentPane().add(panel_2, BorderLayout.EAST);
		panel_2.setLayout(new BoxLayout(panel_2, BoxLayout.X_AXIS));
		
		JButton btnNewButton_11 = new JButton("New button");
		btnNewButton_11.addActionListener(BotonEste);
		panel_2.add(btnNewButton_11);
		
		JButton btnNewButton_10 = new JButton("New button");
		btnNewButton_10.addActionListener(BotonEste);
		panel_2.add(btnNewButton_10);
		
		JButton btnNewButton_12 = new JButton("New button");
		btnNewButton_12.addActionListener(BotonEste);
		panel_2.add(btnNewButton_12);
		
		JButton btnNewButton_13 = new JButton("New button");
		btnNewButton_13.addActionListener(BotonEste);
		panel_2.add(btnNewButton_13);
		
		JPanel panel_3 = new JPanel();
		getContentPane().add(panel_3, BorderLayout.SOUTH);
		panel_3.setLayout(new GridLayout(1, 0, 0, 0));
		
		JButton btnNewButton_6 = new JButton("New button");
		btnNewButton_6.addActionListener(BotonSur);
		panel_3.add(btnNewButton_6);
		
		JButton btnNewButton_7 = new JButton("New button");
		btnNewButton_7.addActionListener(BotonSur);
		panel_3.add(btnNewButton_7);
		
		JButton btnNewButton_8 = new JButton("New button");
		btnNewButton_8.addActionListener(BotonSur);
		panel_3.add(btnNewButton_8);
		
		JButton btnNewButton_9 = new JButton("New button");
		btnNewButton_9.addActionListener(BotonSur);
		panel_3.add(btnNewButton_9);
		
		JPanel panel_4 = new JPanel();
		getContentPane().add(panel_4, BorderLayout.CENTER);
		panel_4.setLayout(new BorderLayout(0, 0));
		
		JButton btnNewButton_1 = new JButton("New button");
		btnNewButton_1.addActionListener(BotonCentral);
		panel_4.add(btnNewButton_1, BorderLayout.WEST);
		
		JButton btnNewButton_2 = new JButton("New button");
		btnNewButton_2.addActionListener(BotonCentral);
		panel_4.add(btnNewButton_2, BorderLayout.NORTH);
		
		JButton btnNewButton_3 = new JButton("New button");
		btnNewButton_3.addActionListener(BotonCentral);
		panel_4.add(btnNewButton_3, BorderLayout.SOUTH);
		
		JButton btnNewButton_4 = new JButton("New button");
		btnNewButton_4.addActionListener(BotonCentral);
		panel_4.add(btnNewButton_4, BorderLayout.EAST);
		
		JButton btnNewButton_5 = new JButton("New button");
		btnNewButton_5.addActionListener(BotonCentral);
		panel_4.add(btnNewButton_5, BorderLayout.CENTER);
		
	}


}
