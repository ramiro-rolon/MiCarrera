package Guia_2_12;

import java.awt.EventQueue;

import javax.swing.JFrame;
import javax.swing.JPanel;
import javax.swing.border.EmptyBorder;
import java.awt.BorderLayout;
import java.awt.Dimension;
import javax.swing.JLabel;
import java.awt.FlowLayout;
import java.awt.Font;
import java.awt.Color;
import javax.swing.border.LineBorder;
import javax.swing.JTextField;
import javax.swing.JButton;
import javax.swing.JComboBox;

public class Ejercicio12 extends JFrame {

	private static final long serialVersionUID = 1L;
	private JPanel contentPane;
	private JTextField txtNombreEntrada;
	private JTextField txtPassword;
	private JTextField txtNombreRegistro;
	private JTextField txtDocumento;
	private JTextField txtTelefono;
	private JTextField txtApellido;
	private JTextField txtDireccion;
	private JTextField textField_7;
	private JTextField txtDescripcion;

	/**
	 * Launch the application.
	 */
	public static void main(String[] args) {
		EventQueue.invokeLater(new Runnable() {
			public void run() {
				try {
					Ejercicio12 frame = new Ejercicio12();
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
	public Ejercicio12() {
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		setBounds(100, 100, 996, 630);
		contentPane = new JPanel();
		contentPane.setBorder(new EmptyBorder(5, 5, 5, 5));
		setContentPane(contentPane);
		contentPane.setLayout(new BorderLayout(0, 0));
		
		JPanel panel = new JPanel();
		contentPane.add(panel);
		panel.setLayout(new BorderLayout(0, 0));
		
		JPanel panelNorte = new JPanel();
		panelNorte.setBackground(new Color(0, 64, 128));
		panelNorte.setPreferredSize(new Dimension(0, 80));
		panel.add(panelNorte, BorderLayout.NORTH);
		panelNorte.setLayout(null);
		
		JLabel lblHILET = new JLabel("HILET");
		lblHILET.setForeground(new Color(255, 255, 255));
		lblHILET.setFont(new Font("Dubai Medium", Font.PLAIN, 43));
		lblHILET.setBounds(60, 24, 173, 38);
		lblHILET.setDoubleBuffered(true);
		panelNorte.add(lblHILET);
		
		JLabel lblNewLabel_1_8 = new JLabel("Tipo");
		lblNewLabel_1_8.setForeground(Color.WHITE);
		lblNewLabel_1_8.setFont(new Font("Tahoma", Font.PLAIN, 14));
		lblNewLabel_1_8.setBounds(370, 24, 80, 27);
		panelNorte.add(lblNewLabel_1_8);
		
		JLabel lblNewLabel_1_9 = new JLabel("Nombre");
		lblNewLabel_1_9.setForeground(Color.WHITE);
		lblNewLabel_1_9.setFont(new Font("Tahoma", Font.PLAIN, 14));
		lblNewLabel_1_9.setBounds(498, 24, 80, 27);
		panelNorte.add(lblNewLabel_1_9);
		
		JLabel lblNewLabel_1_10 = new JLabel("Contraseña");
		lblNewLabel_1_10.setForeground(Color.WHITE);
		lblNewLabel_1_10.setFont(new Font("Tahoma", Font.PLAIN, 14));
		lblNewLabel_1_10.setBounds(642, 24, 80, 27);
		panelNorte.add(lblNewLabel_1_10);
		
		txtNombreEntrada = new JTextField();
		txtNombreEntrada.setBounds(498, 49, 128, 20);
		panelNorte.add(txtNombreEntrada);
		txtNombreEntrada.setColumns(10);
		
		txtPassword = new JTextField();
		txtPassword.setColumns(10);
		txtPassword.setBounds(642, 49, 128, 20);
		panelNorte.add(txtPassword);
		
		JButton btnAcceder = new JButton("Acceder");
		btnAcceder.setBounds(815, 48, 115, 23);
		panelNorte.add(btnAcceder);
		
		String[] Opciones = {"Estudiante", "Profesor", "Administracion"}; 
		
		JComboBox cboTipo = new JComboBox(Opciones);
		cboTipo.setBounds(370, 48, 118, 22);
		
		panelNorte.add(cboTipo);
		
		JPanel panelSur = new JPanel();
		panelSur.setBackground(new Color(0, 64, 128));
		panel.add(panelSur, BorderLayout.SOUTH);
		panelSur.setPreferredSize(new Dimension(0, 30));
		panelSur.setLayout(new FlowLayout(FlowLayout.CENTER, 5, 5));
		
		JLabel lblNewLabel = new JLabel("Desarrollador: Ingenieria del Software II HILET");
		lblNewLabel.setFont(new Font("Tahoma", Font.PLAIN, 16));
		lblNewLabel.setForeground(new Color(255, 255, 255));
		panelSur.add(lblNewLabel);
		
		JPanel panelCentral = new JPanel();
		panelCentral.setBackground(new Color(60, 119, 219));
		panelCentral.setMaximumSize(new Dimension(2000, 2000));
		panel.add(panelCentral, BorderLayout.CENTER);
		panelCentral.setLayout(null);
		
		JPanel panel_1 = new JPanel();
		panel_1.setBackground(new Color(60, 119, 219));
		panel_1.setBorder(new LineBorder(new Color(255, 255, 255)));
		panel_1.setBounds(416, 37, 527, 412);
		panelCentral.add(panel_1);
		panel_1.setLayout(null);
		
		JLabel lblNewLabel_1 = new JLabel("Registro");
		lblNewLabel_1.setForeground(new Color(255, 255, 255));
		lblNewLabel_1.setFont(new Font("Tahoma", Font.BOLD, 15));
		lblNewLabel_1.setBounds(48, 11, 80, 27);
		panel_1.add(lblNewLabel_1);
		
		JLabel lblNewLabel_1_1 = new JLabel("Documento");
		lblNewLabel_1_1.setForeground(Color.WHITE);
		lblNewLabel_1_1.setFont(new Font("Tahoma", Font.PLAIN, 14));
		lblNewLabel_1_1.setBounds(204, 57, 80, 27);
		panel_1.add(lblNewLabel_1_1);
		
		JLabel lblNewLabel_1_2 = new JLabel("Nombre");
		lblNewLabel_1_2.setForeground(Color.WHITE);
		lblNewLabel_1_2.setFont(new Font("Tahoma", Font.PLAIN, 14));
		lblNewLabel_1_2.setBounds(24, 57, 80, 27);
		panel_1.add(lblNewLabel_1_2);
		
		JLabel lblNewLabel_1_3 = new JLabel("Telefono");
		lblNewLabel_1_3.setForeground(Color.WHITE);
		lblNewLabel_1_3.setFont(new Font("Tahoma", Font.PLAIN, 14));
		lblNewLabel_1_3.setBounds(204, 95, 80, 27);
		panel_1.add(lblNewLabel_1_3);
		
		JLabel lblNewLabel_1_4 = new JLabel("Direccion");
		lblNewLabel_1_4.setForeground(Color.WHITE);
		lblNewLabel_1_4.setFont(new Font("Tahoma", Font.PLAIN, 14));
		lblNewLabel_1_4.setBounds(24, 138, 80, 27);
		panel_1.add(lblNewLabel_1_4);
		
		JLabel lblNewLabel_1_5 = new JLabel("Apellido");
		lblNewLabel_1_5.setForeground(Color.WHITE);
		lblNewLabel_1_5.setFont(new Font("Tahoma", Font.PLAIN, 14));
		lblNewLabel_1_5.setBounds(24, 95, 80, 27);
		panel_1.add(lblNewLabel_1_5);
		
		JLabel lblNewLabel_1_6 = new JLabel("Descripcion");
		lblNewLabel_1_6.setForeground(Color.WHITE);
		lblNewLabel_1_6.setFont(new Font("Tahoma", Font.PLAIN, 14));
		lblNewLabel_1_6.setBounds(24, 214, 80, 27);
		panel_1.add(lblNewLabel_1_6);
		
		JLabel lblNewLabel_1_7 = new JLabel("Profesion");
		lblNewLabel_1_7.setForeground(Color.WHITE);
		lblNewLabel_1_7.setFont(new Font("Tahoma", Font.PLAIN, 14));
		lblNewLabel_1_7.setBounds(24, 176, 80, 27);
		panel_1.add(lblNewLabel_1_7);
		
		txtNombreRegistro = new JTextField();
		txtNombreRegistro.setColumns(10);
		txtNombreRegistro.setBounds(107, 62, 86, 20);
		panel_1.add(txtNombreRegistro);
		
		txtDocumento = new JTextField();
		txtDocumento.setColumns(10);
		txtDocumento.setBounds(291, 62, 214, 20);
		panel_1.add(txtDocumento);
		
		txtTelefono = new JTextField();
		txtTelefono.setColumns(10);
		txtTelefono.setBounds(291, 100, 214, 20);
		panel_1.add(txtTelefono);
		
		txtApellido = new JTextField();
		txtApellido.setColumns(10);
		txtApellido.setBounds(108, 102, 86, 20);
		panel_1.add(txtApellido);
		
		txtDireccion = new JTextField();
		txtDireccion.setColumns(10);
		txtDireccion.setBounds(107, 143, 398, 20);
		panel_1.add(txtDireccion);
		
		textField_7 = new JTextField();
		textField_7.setColumns(10);
		textField_7.setBounds(107, 183, 398, 20);
		panel_1.add(textField_7);
		
		txtDescripcion = new JTextField();
		txtDescripcion.setColumns(10);
		txtDescripcion.setBounds(24, 240, 481, 125);
		panel_1.add(txtDescripcion);
		
		JButton btnRegistrar = new JButton("Registrar");
		btnRegistrar.setBounds(416, 378, 89, 23);
		panel_1.add(btnRegistrar);

	}
}
