using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlarAudio : MonoBehaviour {
	GameObject control;
	Control script;

	// Use this for initialization
	void Start () {
		control = GameObject.Find ("Control");
		if (control == null) {
			control = new GameObject("Control");
			control.AddComponent<Control> ();
			control.GetComponent<Control> ().ilumniacionAlta = true;
		}
		if (control != null) {
			script = control.GetComponent<Control>();
			if (script != null) {
				transform.GetComponent<AudioSource> ().volume = script.getVolumen ();
				if (script.getVolumen () > 0)
					transform.GetComponent<AudioSource> ().Play ();
				else
					transform.GetComponent<AudioSource> ().mute=true;
			}
		}
	}
}
