using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuInicial: MonoBehaviour {
	[SerializeField]
	GameObject Menu1;
	[SerializeField]
	GameObject Menu2;
	[SerializeField]
	Text textoIluminacion;
	[SerializeField]
	AudioSource musica;
	[SerializeField]
	Slider volumen_slider;
	[SerializeField]
	Control script;

	float menuActual = 1;
	float volumenActual;
	bool iluminacionAlta = true;

	void Start () {
		volumenActual = volumen_slider.value;
		musica.volume = volumenActual;
		Menu1.SetActive (true);
		Menu2.SetActive (false);
	}

	public void Salir(){
		Application.Quit ();
	}

	public void Jugar() {
		script.setIlum (iluminacionAlta);
		script.setVolumen (volumenActual);
		SceneManager.LoadScene (1);
	}

	public void ChangeMenu(){
		if (menuActual == 1) {
			Menu1.SetActive (false);
			Menu2.SetActive (true);
			menuActual = 2;
		} else {
			Menu2.SetActive (false);
			Menu1.SetActive (true);
			menuActual = 1;
		}
	}

	public void ChangeIlumination(){
		if (iluminacionAlta) {
			iluminacionAlta = false;
			textoIluminacion.text = "baja";
		} else {
			iluminacionAlta = true;
			textoIluminacion.text = "alta";
		}
	}

	public void ChangeVolume(){
		volumenActual = volumen_slider.value;
		musica.volume = volumenActual;
	}
}
