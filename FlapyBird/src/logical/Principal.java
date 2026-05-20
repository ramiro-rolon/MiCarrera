package logical;

import java.awt.*;
import java.awt.event.MouseEvent;
import java.awt.event.MouseListener;

import javax.swing.*;

public class Principal extends JFrame {
	JPanel jPanel1;
	PanelImage panelImage1;
	JLabel jSuelo;
	JLabel jFlappy;
	Point posicionFlappy;
	MunFlappy movimiento;
	MunTubos movimientoTubos;
	
	JLabel jTubo_arriba1;
	JLabel jTubo_arriba2;
	JLabel jTubo_abajo1;
	JLabel jTubo_abajo2;
	
	public boolean colision(JLabel tubo) {
		Rectangle rtFlappy = jFlappy.getBounds();
		Rectangle rtTubo = tubo.getBounds();
		if(rtFlappy.intersects(rtTubo))
			return true;
		else
			return false;
	}
	
	MouseListener ml = new MouseListener(){
		@Override
		public void mousePressed(MouseEvent e) {
			movimiento.setSaltar(true);
			jFlappy.requestFocus(true);
		}
		
		@Override
		public void mouseReleased(MouseEvent e) {
			movimiento.setSaltar(false);
			jFlappy.requestFocus(true);
		}

		@Override
		public void mouseClicked(MouseEvent e) {
			// TODO Auto-generated method stub
			
		}

		@Override
		public void mouseEntered(MouseEvent e) {
			// TODO Auto-generated method stub
			
		}

		@Override
		public void mouseExited(MouseEvent e) {
			// TODO Auto-generated method stub
			
		}
		
	};
	
	public void iniciarComponentes() {
		 setDefaultCloseOperation(WindowConstants.EXIT_ON_CLOSE);
		 setResizable(false);		 
		 panelImage1.setBackground(new Color(255, 255, 255));
		 panelImage1.setLayout(null);
		 panelImage1.setIcon(new ImageIcon(getClass().getResource("/Images/MAPA_NRO1.png")));
		 panelImage1.addMouseListener(ml);
		 jSuelo.setIcon(new ImageIcon(getClass().getResource("/Images/piso.png")));
		 panelImage1.add(jSuelo);
		 jSuelo.setBounds(-130, 470, 580, 180);
		 jFlappy.setIcon(new ImageIcon(getClass().getResource("/Images/pezRojo1.png")));
		 panelImage1.add(jFlappy);
		 jFlappy.setBounds(70, 230, 34, 24);
		 jTubo_arriba1.setIcon(new ImageIcon(getClass().getResource("/Images/Tubo_1.png")));
		 panelImage1.add(jTubo_arriba1);
		 jTubo_arriba1.setBounds(70, -120, 52, 320);
		 jTubo_abajo1.setIcon(new ImageIcon(getClass().getResource("/Images/Tubo_2.png")));
		 panelImage1.add(jTubo_abajo1);
		 jTubo_abajo1.setBounds(70, 280, 52, 320);
		 jTubo_arriba2.setIcon(new ImageIcon(getClass().getResource("/Images/Tubo_1.png")));
		 panelImage1.add(jTubo_arriba2);
		 jTubo_arriba2.setBounds(290, -120, 52, 320);
		 jTubo_abajo2.setIcon(new ImageIcon(getClass().getResource("/Images/Tubo_2.png")));
		 panelImage1.add(jTubo_abajo2);
		 jTubo_abajo2.setBounds(290, 280, 52, 320);
		 setContentPane(panelImage1);
		 panelImage1.setPreferredSize(new Dimension(400, 600));
		 pack();
		 setLocationRelativeTo(null);
	}
	
	public Principal() {
		this.setBounds(100, 100, 450, 600);
		jPanel1 = new JPanel();
		panelImage1 = new PanelImage();
		this.setContentPane(jPanel1);
		jFlappy = new JLabel();
		jSuelo = new JLabel();
		jTubo_arriba1 = new JLabel();
		jTubo_arriba2 = new JLabel();
		jTubo_abajo1 = new JLabel();
		jTubo_abajo2 = new JLabel();
		iniciarComponentes();
		
		this.setLocationRelativeTo(null);
		movimiento = new MunFlappy(this);
		movimientoTubos = new MunTubos(this);
		posicionFlappy = jFlappy.getLocation();
		jPanel1.setSize(400, 600);
		movimiento.start();
		movimientoTubos.start();
	}
	
	
}
