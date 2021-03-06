﻿using UnityEngine;
using System.Collections;

public class CheckpointBehaviour : MonoBehaviour {

	public bool isTeleport;
	// Use this for initialization
	void Start () {
		
	}

	void OnTriggerEnter(Collider colision)
	{
		if (colision.gameObject.tag == "Player" && !isTeleport) {
			colision.gameObject.GetComponent<SpawnBehaviour> ().respawn = transform.position; 
		} else if (colision.gameObject.tag == "Player" && isTeleport) {
				colision.rigidbody.isKinematic = true;
				colision.transform.position = colision.gameObject.GetComponent<SpawnBehaviour> ().respawn;
				colision.rigidbody.isKinematic = false;
		}

		Destroy (gameObject);
	}
	

}
