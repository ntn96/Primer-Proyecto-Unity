using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntrarMini : MonoBehaviour {
	public GameObject texto;
	bool accesible = false;
	bool jugando = false;

	[SerializeField]
	GameObject time;
	[SerializeField]
	GameObject camaraMinijuego;
	[SerializeField]
	GameObject botones;

	ControlTime control;
	GameObject jugador;
	GameObject camaraJugador;

	// Use this for initialization
	void Start () {
		control = time.GetComponent<ControlTime> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (accesible && Input.GetKeyDown (KeyCode.E)) {
			jugando = true;
			botones.SetActive (true);
			texto.SetActive (false);
			control.dt = 0;
			camaraJugador.SetActive (false);
			camaraMinijuego.SetActive (true);
			Cursor.visible = true;
		}
		if (jugando && Input.GetKeyDown (KeyCode.Space)) {
			jugando = false;
			control.dt = 1;
			camaraJugador.SetActive (true);
			camaraMinijuego.SetActive (false);
			Cursor.visible = false;
		}
	}

	void OnTriggerEnter(Collider col){
		jugador = col.gameObject;
		camaraJugador = jugador.transform.Find ("Camara").gameObject;
		texto.SetActive (true);
		accesible = true;
	}

	void OnTriggerExit(Collider col){
		texto.SetActive (false);
		accesible = false;
	}

	public void ganado(){
		Invoke ("nada", 3);
		botones.SetActive (false);
		jugando = false;
		control.dt = 1;
		camaraJugador.SetActive (true);
		camaraMinijuego.SetActive (false);
		Cursor.visible = false;
	}

	void nada(){}
}
