using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Numera : MonoBehaviour {
	public int fila;
	public int columna;
	public bool activo = false;
	Minijuego script;

	void Start (){
		script = gameObject.GetComponentInParent<Minijuego> ();
	}

	void OnMouseDown() {
		pressButton ();
		bool ganado = script.pulsarBoton (fila, columna);
		script.sonido.Play ();
		if(ganado) {
			Invoke ("ganado", 3f);
		}
	}

	public bool pressButton(){
		if (activo) {
			activo = false;
			gameObject.GetComponent<Renderer> ().material.color = Color.red;
		} else {
			activo = true;
			gameObject.GetComponent<Renderer> ().material.color = Color.green;
		}
		return activo;
	}

	void ganado(){
		script.ganado ();
	}
}
