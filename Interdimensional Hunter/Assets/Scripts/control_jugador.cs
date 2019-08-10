using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class control_jugador : MonoBehaviour {
	[SerializeField]
	float velocidad;
	float velocidadActual;
	float vertical;
	float horizontal;
	[SerializeField]
	GameObject time;
	ControlTime control;
	//float dt = 1;
	Animator animator;

	CharacterController controler;
	Vector3 gravedad;
	[SerializeField] float valorGravedad = 4f;

	[SerializeField]
	GameObject MenuPausa;


	// Use this for initialization
	void Start () {
		control = time.GetComponent<ControlTime> ();
		velocidadActual = velocidad;
		Cursor.visible = false;
		animator = GetComponent<Animator> ();
		controler = GetComponent<CharacterController> ();
		gravedad = Vector3.down * valorGravedad;
	}
	
	// Update is called once per frame
	void Update () {
		horizontal = Input.GetAxis ("Horizontal");
		vertical = Input.GetAxis ("Vertical");
		Quaternion q = Quaternion.Euler (0.0f, transform.rotation.eulerAngles.y, 0.0f);
		Vector3 nuevaPosicion = Vector3.zero;
		if(horizontal != 0 && control.getDt()!=0) {
			nuevaPosicion+=q*Vector3.right * horizontal * velocidadActual * Time.deltaTime;
			animator.SetBool ("Andando", true);
		}
		if(vertical != 0 && control.getDt() !=0) {
			nuevaPosicion+=q*Vector3.forward * vertical * velocidadActual * Time.deltaTime;
			animator.SetBool ("Andando", true);
		}
		else animator.SetBool ("Andando", false);
		if (Input.GetKeyDown (KeyCode.Escape) && control.getDt() == 1) {
			control.dt = 0;
			MenuPausa.SetActive (true);
			Cursor.visible = true;
		} else if (Input.GetKeyDown (KeyCode.Escape))
			reanudar();	
		nuevaPosicion += gravedad * Time.deltaTime;
		controler.Move(nuevaPosicion);
	}

	public void reanudar(){
		if (control.dt == 0) {
			control.dt = 1;
			MenuPausa.SetActive (false);
			Cursor.visible = false;
		}	
	}

	public bool enMovimiento(){
		if (vertical == 0 && horizontal == 0)
			return false;
		return true;
	}

	public void setApuntando(bool apuntando){
		animator.SetBool ("Apuntando", apuntando);
	}
}
/*PROBLEMAS:
1º Minirebotes al chocar la hitbox del personaje con los edificios ARREGLADO
2º Si se insiste con el choque puede atravesar paredes ARREGLADO
3ª La cámara debería rotar solo a la malla del personaje y no a todo el jugador
4º La cámara debería parar de moverse cuando para el personaje no el jugador

Cámara sigue a personaje
Cámara gira a personaje
Personaje se mueve conforme a giro no conforme a ejes globales
Jugador se para en seco con colision
Si el personaje no se mueve, la cámara orbita en torno a él y el personaje no rota
Si el personaje se mueve, la cámara lo sigue a su espalda a la derecha
Si la cámara colisiona con algo hace un zoom hacia el personaje lo suficientemente cercano para no chocar
Un cámara con recupera su posición inicial poco a poco
*/