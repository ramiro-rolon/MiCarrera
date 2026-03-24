package Guia_1;
import java.util.*;

public class Ejercicio_8 {

	public static void main(String[] args) {
		new principal();
	}
	
	public static class principal{
		public principal() {
			List<Coche> lista = new ArrayList();
			Scanner sc = new Scanner(System.in);
			String marca;
			double kilometros;
			Integer modelo;
			
			for(int i = 0; i < 5; i++) {
				System.out.println("Ingrese la marca del auto:");
				marca = sc.next();
				System.out.println("Ingrese los kilometros del auto:");
				kilometros = sc.nextDouble();
				System.out.println("Ingrese el modelo del auto:");
				modelo = sc.nextInt();
				Coche auto = new Coche(marca, kilometros, modelo);
				lista.add(auto);
			}
			
			System.out.println("Autos ingresados:");
			MostrarCoches(lista);
			System.out.println("Ingrese marca para filtrar");
			marca = sc.next();
			MostrarPorMarca(lista, marca);
			
			System.out.println("Ingrese el tope de kilometros por el que quiere mostrar la lista de coches");
			kilometros = sc.nextDouble();
			
			MostrarPorKilometrajeMax(lista, kilometros);
			
			Coche auto = MostrarAlQueMasKilometrosTiene(lista);
			System.out.println("El auto que mas kilometros tiene es " + auto);
			
			OrdenarCoches(lista);
			System.out.println("Lista ordenada:");
			MostrarCoches(lista);
		}
		
		public class Coche{
			@Override
			public String toString() {
				return "Coche [Marca=" + Marca + ", kilometros=" + kilometros + ", modelo=" + modelo + "]";
			}
			public String getMarca() {
				return Marca;
			}
			public void setMarca(String marca) {
				Marca = marca;
			}
			public double getKilometros() {
				return kilometros;
			}
			public void setKilometros(double kilometros) {
				this.kilometros = kilometros;
			}
			public Integer getModelo() {
				return modelo;
			}
			public void setModelo(Integer modelo) {
				this.modelo = modelo;
			}
			public Coche(String marca, double kilometros, Integer modelo) {
				super();
				Marca = marca;
				this.kilometros = kilometros;
				this.modelo = modelo;
			}
			public Coche() {}
			private String Marca;
			private double kilometros;
			private Integer modelo;
			
		}
		
		public void MostrarCoches(List<Coche> listardovich) {
			for(Coche cochecito:listardovich) {
				System.out.println(cochecito.toString());
			}
		}
		
		public void MostrarPorMarca(List<Coche> listarda, String marca) {
			System.out.println("Lista de coches de la marca " + marca);
			for(Coche cochardo:listarda) {
				if(cochardo.getMarca().equals(marca))
					System.out.println(cochardo.toString());
			}
		}
		
		public void MostrarPorKilometrajeMax(List<Coche> lista, double tope) {
			System.out.println("Lista de coches con un maximo de " + tope + " kilometros");
			for(Coche cochardo:lista) {
				if(cochardo.getKilometros() < tope)
					System.out.println(cochardo);
			}
		}
		
		public Coche MostrarAlQueMasKilometrosTiene(List<Coche> list) {
			double maximo = 0;
			Coche elmaspi = new Coche();
			for(Coche coche:list) {
				if(coche.getKilometros() > maximo) {
					maximo = coche.getKilometros();
					elmaspi = coche;
				}
			}
			
			return elmaspi;
		}
		
		public void OrdenarCoches(List<Coche> listita) {
			Collections.sort(listita, new Comparator<Coche>(){
				@Override
				public int compare(Coche c1, Coche c2) {
					return Double.compare(c1.getKilometros(), c2.getKilometros());
				}
			});
		}
		
	}
	
}
