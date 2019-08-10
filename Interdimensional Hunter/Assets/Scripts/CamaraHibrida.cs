using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraHibrida : MonoBehaviour {	//Añadir transiciones suaves con LERP
	[SerializeField]
	Transform target;
	[SerializeField]
	GameObject Time;
	ControlTime control;
	public GameObject personaje;
	float x = 0.0f;
	float y = 0.0f;
	public GameObject cursor;
	public float velocidad = 15.0f;
	public float sensibilidad = 0.1f;
	public float limiteAtrasDefault = 5.0f;
	public float limiteDerechoDefault = 2.5f;
	public float limiteVerticalDefault = -0.5f;
	public float limiteAtrasApuntar = 2.5f;
	public float limiteDerechoApuntar = 2.0f;
	float limiteAtrasActual;
	float limiteDerechoActual;
	float minY = -20f;
	float maxY = 80f;
	control_jugador script;
	bool apuntando;
	Vector3 vectorDistancia;

	// Use this for initialization
	void Start () 
	{
		control = Time.GetComponent<ControlTime> ();
		limiteAtrasActual = limiteAtrasDefault;
		limiteDerechoActual = limiteDerechoDefault;
		vectorDistancia = new Vector3 (limiteDerechoActual, limiteVerticalDefault, -limiteAtrasActual);		//Vector de destancia con los valores de offset
		script = personaje.GetComponent<control_jugador> ();
		apuntando = false;
	}

	void FixedUpdate () 
	{
		if (Input.GetAxis ("Apuntar") == 1 && control.dt!=0) { 	//Si estás apuntando
			personaje.GetComponent<control_jugador>().setApuntando(true); //OJO
			cursor.SetActive (true);			//se puede ver el cursor
			limiteDerechoActual = limiteDerechoApuntar;			//se hace un zoom hacia la izquierda
			limiteAtrasActual = limiteAtrasApuntar;			//y hacia adelante
			vectorDistancia = new Vector3 (limiteDerechoActual, 0.0f, -limiteAtrasActual);		//Vector de destancia con los valores de offset
			apuntando = true; 
		} else if(apuntando && control.dt!=0) {
			personaje.GetComponent<control_jugador>().setApuntando(false); //OJO
			cursor.SetActive (false);			//si no, se vuelve a la disposicion anterior
			limiteDerechoActual = limiteDerechoDefault;
			limiteAtrasActual = limiteAtrasDefault;
			vectorDistancia = new Vector3 (limiteDerechoActual, 0.0f, -limiteAtrasActual);		//Vector de destancia con los valores de offset
			apuntando = false;
		}
		x += Input.GetAxis ("Mouse X") * sensibilidad * velocidad * control.dt;	//obtenemos entrada de ratón
		y -= Input.GetAxis ("Mouse Y") * sensibilidad * velocidad * control.dt;
		y = Mathf.Clamp(y, minY, maxY);
		Quaternion rotation = Quaternion.Euler (y, x, 0);			//La usamos para la rotacion de la cámara entorno a x e y
		if (target && control.dt!=0) {								//Si tenemos pivote
			if (script.enMovimiento () || Input.GetAxis ("Apuntar") == 1) {		//Si nos movemos o apuntamos
				Quaternion personajeRotation = Quaternion.Euler (0, x, 0);		//rotamos el personaje en el eje y junto con la camara
				personaje.transform.rotation = Quaternion.Slerp(personaje.transform.rotation,personajeRotation,0.2f);
			}
			transform.rotation = rotation;												//Colocamos la cámara
			transform.position = rotation * vectorDistancia + target.position;
			RaycastHit hit;
            if (Physics.CheckSphere(transform.position, 0.1f))
            {
                Debug.Log("Colisión detectada");
                if (Physics.Linecast(target.position, transform.position, out hit) && hit.collider.tag != "Player")
                {       //Si choca con algo 
                        //transform.position = hit.point;
                    transform.position = Vector3.Lerp(hit.point, target.position, 0.25f);       //cambiamos a la primera posición que no toque
                }
            }
		} 
	}
}	