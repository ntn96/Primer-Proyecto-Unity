using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class cogerCaja : MonoBehaviour {
	public GameObject texto;
	bool cerca;
	bool cogido;
	bool cogible = false;
	GameObject prop;
	GameObject equipable;
	Rigidbody rigid;
	public GameObject fusil;
	// Use this for initialization
	void Start () {
		cerca = false;
		cogido = false;

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.E) && cerca == true && cogido == false) {
			rigid.useGravity = false;
			rigid.isKinematic = true;
			prop.transform.Translate (Vector3.forward * 0.5f);
			prop.transform.SetParent (transform);
			Quaternion q = Quaternion.Euler (-90, prop.transform.parent.rotation.eulerAngles.y, 0);
			prop.transform.rotation = q;
			cogido = true;
			cerca = false;
			texto.SetActive (false);
		} else if (Input.GetKeyDown (KeyCode.E) && cerca == false && cogido == true) {
			rigid.useGravity = true;
			rigid.isKinematic = false;
			prop.transform.parent = null;
			cogido = false;
		} else if (Input.GetKeyDown (KeyCode.E) && cogible == true) {
			Destroy (equipable);
			fusil.SetActive (true);
			gameObject.GetComponent<Equipar> ().fusil = true;
			texto.SetActive (false);
		}
	}

	void OnTriggerEnter(Collider col){
		if (col.tag == "Prop" && cogido == false) {
			texto.SetActive (true);
			prop = col.gameObject;
			rigid = prop.GetComponent<Rigidbody> ();
			cerca = true;
		} else if (col.tag == "Equipable") {
			texto.SetActive (true);
			equipable = col.gameObject;
			cogible = true;
		}
	}

	void OnTriggerExit(Collider col){
		if (col.tag == "Prop") {
			texto.SetActive (false);
			cerca = false;
		} else if (col.tag == "Equipable") {
			texto.SetActive (false);
			cogible = false;
		}
	}
}
