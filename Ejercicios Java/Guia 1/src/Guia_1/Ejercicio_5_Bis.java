package Guia_1;

import java.util.*;

public class Ejercicio_5_Bis {

    public static void main(String[] args) {
        List<Integer> listarda = new ArrayList<>();
        int numerito;

        for(int i = 0; i < 10; i++) {
            numerito = (int)(Math.random() * 100);

            if (!listarda.contains(numerito)) {
                listarda.add(numerito);
            } else {
                i--;
            }
        }

        for(int numerardo : listarda) {
            System.out.println(numerardo);
        }
    }
}