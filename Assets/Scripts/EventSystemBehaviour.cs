﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class EventSystemBehaviour : MonoBehaviour {

	private Button button1;
	private PlayerBehaviour playerBehaviour;
	private GameObject gameOverPanel;
	private GameObject escPanel;

	// Use this for initialization
	void Start () {

		playerBehaviour = GameObject.FindWithTag("Player").GetComponent<PlayerBehaviour>();
		button1 = GameObject.Find("InfoButton1").GetComponent<Button>();
		gameOverPanel = GameObject.Find("GameOverPanel");
		gameOverPanel.SetActive(false);
		escPanel = GameObject.Find("EscPanel");
		escPanel.SetActive(false);
		Screen.showCursor = false;
	}

	void Update () {
		if(Input.GetKeyDown(KeyCode.Return)){
			if(button1.IsActive()){
				button1.Select();
			}
		}
		if(Input.GetKeyDown(KeyCode.Escape)){
			escPanel.SetActive(true);
		}

	}
	void LateUpdate(){
		if(playerBehaviour.life < 1){
			Screen.showCursor = true;
			gameOverPanel.SetActive(true);
		}
	}
}
