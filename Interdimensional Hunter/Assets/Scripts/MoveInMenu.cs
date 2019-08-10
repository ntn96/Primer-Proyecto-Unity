using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveInMenu : MonoBehaviour {
	[SerializeField]
	float velocity;
	[SerializeField]
	float retardo;
	[SerializeField]
	bool movY = false;
	[SerializeField]
	bool adelante = true;
	bool movimiento = false;
	public Transform posicion;

	// Use this for initialization
	void Start () {
		Invoke ("StartMove", retardo);
	}
	
	// Update is called once per frame
	void Update () {
		if (movimiento) {
			if (movY && adelante) {
				if (transform.position.y < posicion.position.y)
					transform.position += Vector3.up * velocity * Time.deltaTime;
				else {
					transform.position.Set (transform.position.x, posicion.position.y, transform.position.z);
					Destroy (this);
				}
			}
			if (movY && !adelante) {
				if (transform.position.y > posicion.position.y)
					transform.position -= Vector3.up * velocity * Time.deltaTime;
				else {
					transform.position.Set (transform.position.x, posicion.position.y, transform.position.z);
					Destroy (this);
				}
			}
			if (!movY && adelante) {
				if (transform.position.x < posicion.position.x)
					transform.position += Vector3.right * velocity * Time.deltaTime;
				else {
					transform.position.Set (posicion.position.x, transform.position.y, transform.position.z);
					Destroy (this);
				}
			}
			if (!movY && !adelante) {
				if (transform.position.x > posicion.position.x)
					transform.position -= Vector3.right * velocity * Time.deltaTime;
				else {
					transform.position.Set (posicion.position.x, transform.position.y, transform.position.z);
					Destroy (this);
				}
			}
		}
	}

	void StartMove(){
		movimiento = true;
	}
}
