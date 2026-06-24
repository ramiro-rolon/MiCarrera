package com.example.demo.repository;

import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;

import com.example.demo.entity.Persona;

public interface IPersonaRepository extends JpaRepository <Persona, Long>{
	public List<Persona> findByEdad(Integer edad);
}
