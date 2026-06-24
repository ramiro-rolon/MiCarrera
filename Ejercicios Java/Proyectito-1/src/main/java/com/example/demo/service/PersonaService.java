package com.example.demo.service;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import com.example.demo.entity.Persona;
import com.example.demo.repository.IPersonaRepository;

@Service
public class PersonaService {
	@Autowired
	IPersonaRepository repo;
	
	public List<Persona> ListarTodos(){
		return repo.findAll();
	}
}
