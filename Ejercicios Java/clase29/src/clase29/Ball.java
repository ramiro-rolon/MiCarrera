package clase29;

import java.awt.Graphics2D;


public class Ball {
	int y = 0;
	int x = 0;
	int ya = 10;
	int xa = 10;
	Game game;
	
	public Ball(Game game) {
		this.game = game;
	}
	
	public void paint(Graphics2D g) {
		g.fillOval(x, y, 30, 30);
	}
	
	public void moveBall() {
		if(x + xa < 0)
			xa= 10;
		if(x + xa >game.getWidth()-30)
			xa=-10;
		if(y+ya < 0)
			ya = 10;
		if(y + ya > game.getHeight()-30)
			ya = -10;
		
		x = x + xa;
		y = y + ya;
	}
	
}
