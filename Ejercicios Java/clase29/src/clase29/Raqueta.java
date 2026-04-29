package clase29;

import java.awt.*;
import java.awt.event.KeyEvent;

public class Raqueta {
	int x = 0;
	int xa = 0;
	Game game;
	
	public Raqueta(Game game) {
		this.game = game;
	}
	
	public void paint(Graphics2D g) {
		g.fillRect(x, 330, 60, 10);
	}
	
	public void moveRaquet() {
		if(x + xa > 0 && x + xa < game.getWidth() - 60) {
			x = x + xa;
		}
	}
	
	public void Soltar() {
		xa = 0;
	}
	
	public void presionar(KeyEvent e) {
		if(e.getKeyCode() == KeyEvent.VK_LEFT)
			xa = -5;
		if(e.getKeyCode() == KeyEvent.VK_RIGHT)
			xa = 5;
	}
	
	
}
