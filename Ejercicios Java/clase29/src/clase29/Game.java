package clase29;

import java.awt.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.event.KeyEvent;
import java.awt.event.KeyListener;

import javax.swing.JFrame;
import javax.swing.JPanel;
import javax.swing.*;

public class Game extends JPanel implements Runnable{
	
	Timer timer;
	Ball ball = new Ball(this);
	Raqueta raqueta = new Raqueta(this);
	void move() {
		ball.moveBall();
		raqueta.moveRaquet();
	}

	@Override
	public void paint(Graphics g) {
		super.paint(g);
		Graphics2D g2d = (Graphics2D)g;
		g2d.setRenderingHint(RenderingHints.KEY_ANTIALIASING, RenderingHints.VALUE_ANTIALIAS_ON);
		ball.paint(g2d);
		raqueta.paint(g2d);
	}
	
	
	public Game() {
		addKeyListener(new KeyListener() {
			
			@Override
			public void keyTyped(KeyEvent e) {
				
			}
			
			@Override
			public void keyReleased(KeyEvent e) {
				raqueta.Soltar();
			}
			
			@Override
			public void keyPressed(KeyEvent e) {
				raqueta.presionar(e);
			}
		});
		setFocusable(true);
	}
	
	@Override
	public void run () {
		timer = new Timer(1,new ActionListener(){
			@Override
			public void actionPerformed(ActionEvent e) {
			move();
			repaint();
			}
			
		});
		timer.start();
	}

	public static void main(String[] args) throws InterruptedException {
		JFrame frame = new JFrame();
		Game game = new Game();
		frame.add(game);
		frame.setLocationRelativeTo(null);
		frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		frame.setVisible(true);
		frame.setSize(300, 400);
		
		game.run();
		
		
	}	
	
	
}

