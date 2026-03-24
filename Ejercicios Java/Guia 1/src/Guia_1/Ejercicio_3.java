package Guia_1;

import java.util.Scanner;

public class Ejercicio_3 {

	public static void main(String[] args) {
		int numerito;
		Scanner sc = new Scanner(System.in);
		
		System.out.println("Ingrese un numero");
		
		numerito = sc.nextInt();
		System.out.println("Doble: " + numerito * 2);
		System.out.println("Triple: " + numerito * 3);

	}

}
