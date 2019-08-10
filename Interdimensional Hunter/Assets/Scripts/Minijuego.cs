using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minijuego : MonoBehaviour {
	public GameObject [] lista = new GameObject[25];
	GameObject [,] botones = new GameObject[5,5];
	public float numActivas = 0;
	public GameObject iniciador;
	public AudioSource sonido;

	// Use this for initialization
	void Start () {
		sonido = gameObject.GetComponent<AudioSource> ();
		int fila = 0;
		int columna = 0;
		for (int i = 0; i < 25; i++) {
			lista [i].GetComponent<Renderer> ().material.color = Color.red;
			Numera script = lista [i].GetComponent<Numera> ();
			script.fila = fila;
			script.columna = columna;
			botones [fila,columna] = lista [i];
			columna++;
			if (columna == 5) {
				columna = 0;
				fila++;
			}
		}
	}

	public bool pulsarBoton(int fila, int columna){
		bool resultado;
		for (int i = 0; i < 5; i++) {
			resultado = botones [fila, i].GetComponent<Numera> ().pressButton ();
			if (resultado)
				numActivas++;
			else
				numActivas--;
			resultado = botones [i, columna].GetComponent<Numera> ().pressButton ();
			if (resultado)
				numActivas++;
			else
				numActivas--;
		}
		if (botones [fila, columna].GetComponent<Numera> ().activo)
			numActivas++;
		else
			numActivas--;
		sonido.Play ();
		if (numActivas == 25) {
			return true;
		}
		return false;
	}

	public void ganado(){
		iniciador.GetComponent<EntrarMini> ().ganado ();
	}

	// Update is called once per frame
	void Update () {
		
	}
}
