package Guia_1;



import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;
public class Ejercicio_4 {

	public static void main(String[] args) {
		int numero = 0;
		Scanner sc = new Scanner(System.in);
		List<Integer> lista = new ArrayList<Integer>();
		int i;
		for(i = 0; i < 10; i++) {
			System.out.println("Ingrese un numero");
			numero  = sc.nextInt();
			lista.add(numero);
		}
		sc.close();
		Integer positivos = 0;
		Integer negativos = 0;
		numero = 0;
		i = 0;
		for(Integer numerito:lista) {
			if(numerito > 0) {
				positivos = positivos + numerito;
				numero++;
			}
			else {
				negativos = negativos + numerito;
				i++;
			}
		}
		System.out.println("Promedio de valores positivos: " + positivos/numero);
		System.out.println("Promedio de valores negativos: " + negativos/i);
	}

}
