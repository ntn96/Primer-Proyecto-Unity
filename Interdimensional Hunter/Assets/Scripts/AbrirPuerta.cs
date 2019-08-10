using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbrirPuerta : MonoBehaviour {
	bool alcanzable = false;
	GameObject puerta;
	[SerializeField]
	GameObject texto;
	InfoPuerta info;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (alcanzable && !info.abierta && Input.GetKeyDown(KeyCode.E)) {
			puerta.GetComponentInParent<Animator>().SetBool ("Abrir", true);
			info.abierta = true;
		}
	}

	void OnTriggerEnter(Collider col){
		if (col.tag == "Puerta") {
			alcanzable = true;
			puerta = col.gameObject;
			info = puerta.GetComponent<InfoPuerta>();
			if(!info.abierta) texto.SetActive (true);
		}
	}

	void OnTriggerExit(Collider col){
		if (col.tag == "Puerta") {
			alcanzable = false;
			texto.SetActive (false);
		}
	}
}
