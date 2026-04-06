package ejercicio_15;

import java.awt.EventQueue;

public class Main {
		public static void main(String[] args) {
			EventQueue.invokeLater(new Runnable() {
				public void run() {
					try {
						Ejercicio15 vista = new Ejercicio15();
						Modelo modelo = new Modelo();
						Controlador controlador = new Controlador(modelo, vista);
						
						vista.setVisible(true);
					} catch (Exception e) {
						e.printStackTrace();
					}
				}
			});
		}
	

}
