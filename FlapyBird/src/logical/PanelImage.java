package logical;

import java.awt.*;

import javax.swing.Icon;
import javax.swing.ImageIcon;
import javax.swing.JPanel;

public class PanelImage extends JPanel {

	private Image image;
	private Icon icon;
	
	@Override
	public void paintComponent(Graphics g) {
		Graphics2D g2d = (Graphics2D)g;
		if(image != null) {
			g2d.drawImage(image, 0, 0, getWidth(), getHeight(),null);
		}
	}
	public void setIcon(Icon icon) {
		this.icon = icon;
		if(icon != null) {
			image = ((ImageIcon)icon).getImage();
		}
	}
	
	public Icon getIcon() {
		return this.icon;
	}
	
	public void setImage(String filoname) {
		setIcon(new ImageIcon(getClass().getResource(filoname)));
	}
	
	public PanelImage() {
		
	}

}
