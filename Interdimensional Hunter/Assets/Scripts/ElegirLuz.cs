using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElegirLuz : MonoBehaviour {
	[SerializeField]
	GameObject luz_costosa;
	[SerializeField]
	GameObject luz_barata;

	// Use this for initialization
	void Start () {
		GameObject control = GameObject.Find ("Control");
		if (control != null) {
			Control script = control.GetComponent<Control>();
			if (script != null) {
				if (script.getIlum ()) {
					luz_barata.SetActive (false);
					luz_costosa.SetActive (true);
				} else {
					luz_barata.SetActive (false);
					luz_costosa.SetActive (true);
				}
			}
		}
	}
}
