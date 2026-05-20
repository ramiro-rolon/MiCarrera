package logical;

import java.awt.Point;

public class MunFlappy extends Thread
{
	private Principal principal;
	private boolean saltar;
	
	public boolean isSaltar() {
		return saltar;
	}
	
	public void setSaltar(boolean saltar) {
		this.saltar = saltar;
	}
	
	public MunFlappy(Principal pri) {
		this.principal = pri;
	}
	
	@Override
	public void run()
	{
		while(true) {
			if(saltar) {
				Point pos = principal.jFlappy.getLocation();
				try {
					Thread.sleep(20);
				}
				catch(Exception e) {
					
				}
				pos.y -= 10;
				principal.jFlappy.setLocation(pos);
			}
			else {
				Point pos = principal.jFlappy.getLocation();
				try {
					Thread.sleep(20);
				}
				catch(Exception e) {
					
				}
				pos.y += 5;
				principal.jFlappy.setLocation(pos);
			}
		}
	}
	
}
