using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tren : MonoBehaviour {
	[SerializeField]
	float velocidad = 20f;
	[SerializeField]
	float fin = 180f;
	Vector3 inicial;
	bool pasando;
	[SerializeField]
	float tiempo_entre_tren = 5f;
	[SerializeField]
	float retardo = 0f;

	// Use this for initialization
	void Start () {
		Invoke ("resetPosition", retardo);
		inicial = transform.position;
		pasando = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.x <= fin) {
			transform.position += Vector3.right * velocidad * Time.deltaTime;
		}
		else if(pasando==true){
			pasando = false;
			Invoke ("resetPosition",tiempo_entre_tren);
		}
	}

	void resetPosition(){
		transform.position = inicial;
		pasando = true;
	}
}
