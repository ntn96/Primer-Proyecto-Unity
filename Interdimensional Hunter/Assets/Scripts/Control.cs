using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour{
	public float volumen = 0.5f;
	public bool ilumniacionAlta = false;

	void Awake(){
		DontDestroyOnLoad (transform.gameObject);
	}

	public void setVolumen(float vol){
		volumen = vol;
	}

	public float getVolumen(){
		return volumen;
	}

	public void setIlum(bool ilum){
		ilumniacionAlta = ilum;
	}

	public bool getIlum(){
		return ilumniacionAlta;
	}
}
