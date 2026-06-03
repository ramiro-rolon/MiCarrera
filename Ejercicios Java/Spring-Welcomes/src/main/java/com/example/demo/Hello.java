package com.example.demo;

import java.util.HashMap;
import java.util.Map;

import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;


@RestController
@RequestMapping("/primerspring2")
public class Hello {
	
	String nombre = "Ramita Ramon";
	String apellido = "Rolon Ramirez";
	
	@GetMapping("/hello")
	public Map<String, String> sayHello() 
	{
		Map<String, String>datos=new HashMap<String, String>();
		
		datos.put("apellidovista", apellido);
		datos.put("nombrevista", nombre);
		
		
		return datos;
	}
}
