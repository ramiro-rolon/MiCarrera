package ejercicio_15;

public class Modelo {
	private char[][] juego;
	private char turno;
	
	public char[][] getJuego() {
		return juego;
	}
	public char getTurno() {
		return turno;
	}
	
	public Modelo() {
		juego = new char[3][3];
		turno = 'x';
		inicializar();
	}
	
	public void inicializar() {
		for(int i = 0; i < 3; i++) {
			for(int j = 0; j < 3; j++) {
				juego[i][j] = ' '; 
			}
		}
	}
	
	public void cambiarTurno() {
		turno = (turno == 'x') ? 'o' : 'x';
	}
	
	public boolean jugar(int fila, int col) {
		
		if(juego[fila][col] == ' ') {
			
			juego[fila][col] = this.getTurno();
			cambiarTurno();
			return true;
		}
		
		return false;
	}
	
	public char getCasilla(int fila, int col) {
		return juego[fila][col];
	}
	
	public boolean HayGanador() {
		for(int i = 0; i < 3; i++) {
			// verticales
			
			if(juego[i][0] != ' ' && juego[i][0] == juego[i][1] && juego[i][1] == juego[i][2]) {
				return true;
			}
			
			// laterales
			
			if(juego[0][i] != ' ' && juego[0][i] == juego[1][i] && juego[1][i] == juego[2][i]) {
				return true;
			}
			
		}

		// diagonales
		
		if(juego[1][1] != ' ') {
			if(juego[0][0] == juego[1][1] && juego[2][2] == juego[1][1]) {
				return true; 
			}
			if(juego[0][2] == juego[1][1] && juego[2][0] == juego[1][1]) {
				return true;
			}
		}
		
		return false;
	}
	
	public boolean Empate() {
		for(int i = 0; i < 3; i++) {
			for(int j = 0; j < 3; j++) {
				if(juego[i][j]==' ') {
					return false;
				}
			}
		}
		return true;
	}
	
	public void reiniciar() {
	    inicializar();
	    turno = 'x';
	}
}
