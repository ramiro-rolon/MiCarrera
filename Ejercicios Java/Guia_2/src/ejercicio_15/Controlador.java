package ejercicio_15;
import java.awt.GridLayout;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import javax.swing.JOptionPane;
import ejercicio_15.Modelo;
import ejercicio_15.Ejercicio15;

public class Controlador {
	private Modelo modelo;
	private Ejercicio15 vista;
	
	public Controlador(Modelo m, Ejercicio15 v) {
		modelo = m;
		vista = v;
		
		init();
	}
	
	public void reiniciarVista() {
	    for (int i = 0; i < 3; i++) {
	        for (int j = 0; j < 3; j++) {
	            vista.botones[i][j].setText("");
	            vista.botones[i][j].setEnabled(true);
	        }
	    }
	}
	
	private void init() {
		for (int i = 0; i < 3; i++) {
			for(int j = 0; j < 3; j++) {
				int fila = i;
				int col = j;
				
				vista.botones[i][j].addActionListener(new ActionListener(){
					@Override
					public void actionPerformed(ActionEvent e) {
						if(modelo.jugar(fila, col)) {
							vista.botones[fila][col].setText(String.valueOf(modelo.getCasilla(fila, col)));
						}
						if(modelo.HayGanador()) {
							char ganador = (modelo.getTurno() == 'x') ? 'o' : 'x';
							JOptionPane.showMessageDialog(null, "El ganador es " + ganador);
							modelo.reiniciar();
							reiniciarVista();
						}
						if(modelo.Empate()){
							JOptionPane.showMessageDialog(null, "Hay empate");
							modelo.reiniciar();
							reiniciarVista();
						}
					}
				});
				
			}
		}
		
	}
}
