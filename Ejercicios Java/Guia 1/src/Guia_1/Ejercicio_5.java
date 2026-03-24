package Guia_1;

import java.util.*;
public class Ejercicio_5 {

	public static void main(String[] args) {
		List<Integer> listarda = new ArrayList<Integer>();
		int numerito;
		for(int i = 0; i < 10; i++) {
			int flag = 0;
			numerito = (int)(Math.random()*100);
			for(int numerardo:listarda) {
				if (numerardo == numerito) {
					flag = 1;
					i--;
				}
			}
			if (flag == 0)
				listarda.add(numerito);
		}
		
		for(int numerardo:listarda) {
			System.out.println(numerardo);
		}
	}

}
