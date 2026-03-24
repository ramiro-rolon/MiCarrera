package Guia_1;

import java.util.*;


public class Ejercicio_7 {

	public static void main(String[] args) {
		
		new principal();
		
	}
	
	public static class principal{
		
		public principal() {
			Scanner sc = new Scanner(System.in);
			System.out.println("Ingrese nombre del cliente: ");
			String nombre = sc.next();
			System.out.println("Ingrese edad del cliente: ");
			int edad = sc.nextInt();
			System.out.println("Ingrese contacto del cliente: ");
			Integer contacto = sc.nextInt();
			System.out.println("Ingrese cargos del cliente: ");
			double cargos = sc.nextDouble();
			
			
			Cliente clientito = new Cliente(edad, nombre, contacto, cargos);
			
			System.out.println("Ingrese nombre del proveedor: ");
			nombre = sc.next();
			System.out.println("Ingrese edad del proveedor: ");
			edad = sc.nextInt();
			System.out.println("Ingrese deuda del proveedor: ");
			Integer deuda = sc.nextInt();
			System.out.println("Ingrese que provee el proveedor: ");
			String provee = sc.next();
			
			Proveedor proverdura = new Proveedor(edad, nombre, provee, deuda);
			
			
			CompararEdad(clientito, proverdura);
			
		}		
		
		public void CompararEdad(Persona personita_1, Persona personita_2) {
			int edad_1 = 0;
			int edad_2 = 0;
			
			if(personita_1.getClass() == Cliente.class || personita_1.getClass() == Proveedor.class) 
			{
				if(personita_2.getClass() == Cliente.class || personita_2.getClass() == Proveedor.class) {
					edad_1 = personita_1.getEdad();
					edad_2 = personita_2.getEdad();
				}
			}
			
			if(edad_1 < edad_2)
				System.out.println(personita_2.getNombre() + " es mayor que " + personita_1.getNombre());
			else if(edad_1 == edad_2)
				System.out.println(personita_2.getNombre() + " y " + personita_1.getNombre() + " tienen la misma edad");
			else
				System.out.println(personita_2.getNombre() + " es menor que " + personita_1.getNombre());					
		}
		
		public class Persona{
			public int getEdad() {
				return edad;
			}
			public void setEdad(int edad) {
				this.edad = edad;
			}
			public String getNombre() {
				return nombre;
			}
			public void setNombre(String nombre) {
				this.nombre = nombre;
			}
			public Persona(int edad, String nombre) {
				super();
				this.edad = edad;
				this.nombre = nombre;
			}
			
			public Persona(){}
			
			public int edad;
			public String nombre;
			
		}
		
		public class Cliente extends Persona{
			public int getContacto() {
				return contacto;
			}
			public void setContacto(int contacto) {
				this.contacto = contacto;
			}
			public double getCargos() {
				return cargos;
			}
			public void setCargos(double cargos) {
				this.cargos = cargos;
			}
			public Cliente(int edad, String nombre, Integer contacto, double cargos) {
				super(edad, nombre);
				this.contacto = contacto;
				this.cargos = cargos;
			}
			public Cliente() {}
			public Integer contacto;
			public double cargos;
			
		}
		
		public class Proveedor extends Persona{
			public String getProvee() {
				return provee;
			}
			public void setProvee(String provee) {
				this.provee = provee;
			}
			public Integer getDeuda() {
				return deuda;
			}
			public void setDeuda(Integer deuda) {
				this.deuda = deuda;
			}
			public Proveedor(int edad, String nombre, String provee, Integer deuda) {
				super(edad, nombre);
				this.provee = provee;
				this.deuda = deuda;
			}
			public String provee;
			public Integer deuda;
			
		}
	}
	
	
	
}
