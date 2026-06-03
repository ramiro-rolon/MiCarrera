package com.example.demo;

import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;


@Controller
@RequestMapping("/primerspring")
public class HelloController {
	
	String nombre = "Ramita Ramon";
	String apellido = "Rolon Ramirez";
	
	@GetMapping("/hello")
	public String sayHello(Model model) 
	{
		model.addAttribute("apellidovista", apellido);
		model.addAttribute("nombrevista", nombre);
		
		
		return "vista";
	}
}
