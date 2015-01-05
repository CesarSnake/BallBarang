﻿using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	/// <summary>
	/// Aceleración del movimiento de la bola (Default:5).
	/// </summary>
	public float acceleration;
	/// <summary>
	/// Fuerza del salto (Default:350)
	/// </summary>
	public float jumpForce;
	/// <summary>
	/// Estamos en el suelo o en el aire.
	/// </summary>
	public bool isGrounded;

	/// <summary>
	/// Direccion relativa a la camara. 
	/// </summary>
	private Vector3 realDirection;
	/// <summary>
	/// Factor del Power-Up de velocidad
	/// </summary>
	public int speedPowerUpFactor;
	/// <summary>
	/// Nos permite saber si estamos escalando una pared en modo SpikeBall
	/// </summary>
	public bool isClimbing;
	/// <summary>
	/// The just stop climbing. Comprueba si acaba de realizar escalada
	/// </summary>
	public bool justStopClimbing;
	/// <summary>
	/// Transform de la camara.
	/// </summary>
	private Transform anchorCamera;
	/// <summary>
	/// Script comportamiento AnchorCamera
	/// </summary>
	private AnchorBehaviour anchorBehaviour;

	void Start (){
		justStopClimbing = false;
		isClimbing = false;
		//Empezamos en el aire
		isGrounded = false;
		//Obtenemos la camara
		anchorCamera = GameObject.Find ("AnchorCamera").transform;		
		anchorBehaviour = anchorCamera.GetComponent<AnchorBehaviour>();	

	}
	
	// Update is called once per frame
	void Update () {

		if(!isClimbing){

			if (Input.GetAxis ("Jump") != 0 && isGrounded)  
					rigidbody.AddForce (0, jumpForce, 0);

			if (Input.GetAxis ("Horizontal") != 0 || Input.GetAxis ("Vertical") != 0){
				realDirection = anchorCamera.TransformDirection (Input.GetAxis ("Horizontal"), 0, Input.GetAxis ("Vertical"));
				rigidbody.AddForce(realDirection * acceleration);
			}				
		}
		else{
			//Escalando nos movemos tambien en Y
			if (Input.GetAxis ("Horizontal") != 0 || Input.GetAxis ("Vertical") != 0){
				realDirection = anchorCamera.TransformDirection (Input.GetAxis ("Horizontal"), Input.GetAxis ("Vertical"), Input.GetAxis ("Vertical"));
				rigidbody.AddForce(realDirection * acceleration);
			}	
		}
	}

	void OnCollisionEnter(Collision colision)
	{
		if (colision.gameObject.tag == "Ground"){
			isGrounded = true;
			if(justStopClimbing){
				//Anchor se encarga de posicionar la camara
				anchorBehaviour.stopClimbing();
				justStopClimbing = false;
			}
		}	
	}
	void OnCollisionExit(Collision colision){
		if (colision.gameObject.tag == "Ground"){
			isGrounded = false;
		}	
	}
	public void startClimbing(){
		anchorBehaviour.startClimbing();

		rigidbody.useGravity = false;
		isClimbing = true;
		isGrounded = false;
	}
	public void stopClimbing(){
		rigidbody.useGravity = true;
		isClimbing = false;
		justStopClimbing = true;
	}
	

}
