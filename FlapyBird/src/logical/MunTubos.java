package logical;

import java.awt.Point;

public class MunTubos extends Thread {
	int tbn1;
	int tbn2;
	Point pos1;
	Point pos2;
	
	private Principal principal;
	private int velocidad;
	
	public MunTubos(Principal pr) {
		this.principal = pr;
		velocidad = 7;
	}
	
	public int numAleatorio() {
		int numero = (int)(Math.random()*(0 - (-200)+(-200)));
		return numero;
	}
	
	@Override
	public void run() {
		pos1 = principal.jTubo_arriba1.getLocation();
		pos2 = principal.jTubo_arriba2.getLocation();
		tbn1 = pos1.x;
		tbn2 = pos2.x;
		
		while(true) {
			try {
				Thread.sleep(velocidad);
				tbn1--;
				tbn2--;
				principal.jTubo_arriba1.setLocation(tbn1, pos1.y);
				principal.jTubo_abajo1.setLocation(tbn1, pos1.y + 450);
				principal.jTubo_arriba2.setLocation(tbn2, pos2.y);
				principal.jTubo_abajo2.setLocation(tbn2, pos2.y + 450);
				if(principal.colision(principal.jTubo_arriba1) || principal.colision(principal.jTubo_arriba2)|| principal.colision(principal.jTubo_abajo1)|| principal.colision(principal.jTubo_abajo2)) {
					System.out.println("Chocaste");
				}
				if(tbn1 <= -51) {
					pos1.y = numAleatorio();
					tbn1 = 425;
				}
				if(tbn2 <= -51) {
					pos2.y = numAleatorio();
					tbn2 = 425;
				}
			}
			catch(Exception e){}
		}
		
	}
}
