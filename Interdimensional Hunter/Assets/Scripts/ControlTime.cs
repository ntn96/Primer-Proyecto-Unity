using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ControlTime : MonoBehaviour {
	public float dt = 1;
	public GameObject menuOp;
	public GameObject menuPausa;
	public Slider volumen;
	public Text opIlum;
	public GameObject ilum_cost;
	public GameObject ilum_bar;
	public AudioSource musica;

	Control script;

	public float getDt(){
		return dt;
	}

	public void setDt(float num){
		dt = num;
	}

	public void VolverAInicio() {
		GameObject control = GameObject.Find ("Control");
		script = control.GetComponent<Control> ();
		Destroy (control);
		SceneManager.LoadScene (0);
	}

	public void mostrarMenuOpciones(){
		menuOp.SetActive (true);
		menuPausa.SetActive (false);
		GameObject control = GameObject.Find ("Control");
		script = control.GetComponent<Control> ();
		float vol = script.getVolumen();
		volumen.value = vol;
		if (script.getIlum ())
			opIlum.text = "Alta";
		else
			opIlum.text = "Baja";
	}

	public void mostrarMenuPausa(){
		menuOp.SetActive (false);
		menuPausa.SetActive (true);
	}

	public void changeIlum(){
		if (script.getIlum ()) {
			opIlum.text = "Baja";
			script.setIlum (false);
			ilum_cost.SetActive (false);
			ilum_bar.SetActive (true);
		} else {
			opIlum.text = "Alta";
			script.setIlum (true);
			ilum_cost.SetActive (true);
			ilum_bar.SetActive (false);
		}
	}

	public void changeVolu(){
		script.setVolumen(volumen.value);
		musica.volume = volumen.value;
	}
}
