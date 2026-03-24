package Guia_1;

import java.util.*;

public class Ejercicio_6 {
	
	public static class Figura{
		public Figura(int base, int altura) {
			super();
			this.base = base;
			this.altura = altura;
		}
		public int getBase() {
			return base;
		}
		public void setBase(int base) {
			this.base = base;
		}
		public int getAltura() {
			return altura;
		}
		public void setAltura(int altura) {
			this.altura = altura;
		}
		public int base;
		public int altura;
		
	}
	
	public interface IFigura{
		public double CalcularPerimetro();
		public double CalcularSuperficie();
	}
	
	public static class Rectangulo extends Figura implements IFigura{

		public Rectangulo(int base, int altura) {
			super(base, altura);
		}
		
		public double CalcularSuperficie() {
			return this.getBase() * this.getAltura();
		}
		public double CalcularPerimetro() {
			return this.getBase() * 2 + this.getAltura() * 2;
		}
		
	}

	public static class Circulo extends Figura implements IFigura{

		public Circulo(int base, int altura) {
			super(base, altura);
		}
		
		public double CalcularSuperficie() {
			return this.getBase() * this.getBase() * 2;
		}
		public double CalcularPerimetro() {
			return this.getBase() * 2 * Math.PI;
		}
		
	}	
	
	public static void main(String[] args) {
		
		Scanner sc = new Scanner(System.in);
		int base = 0;
		int altura = 0;
		System.out.println("Ingrese base de un rectangulo");
		
		base = sc.nextInt();
		
		System.out.println("Ingrese base de un rectangulo");

		altura = sc.nextInt();
		
		Rectangulo rectangulito = new Rectangulo(base, altura);
		
		System.out.println("Ingrese el valor de la base de un circulo");
		
		base = sc.nextInt();
		Circulo circulito = new Circulo(base, altura);
		
		System.out.println("Perimetro del rectangulo: " + rectangulito.CalcularPerimetro());
		System.out.println("Superficie del rectangulo: " + rectangulito.CalcularSuperficie());
		System.out.println("Perimetro del circulo: " + circulito.CalcularPerimetro());
		System.out.println("Perimetro del circulo: " + circulito.CalcularSuperficie());
		
		
	}

}
