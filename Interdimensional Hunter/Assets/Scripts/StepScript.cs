using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepScript : MonoBehaviour{
	bool colision = false;
	void OnCollisionEnter(Collision collision){
		colision = true;
	}
	void OnCollisionExit(Collision collisionInfo){
		colision = false;
	}

	public bool getColision(){
		return colision;
	}
}
