﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	public GameObject text;	
	public int counter = 0;
	public AudioSource music;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		text.GetComponent<TextMesh> ().text = "Lights: " + counter + " / 8";
		if (counter == 8) {
			print ("Level Complete!");
			music.enabled = false;
			gameObject.GetComponentInChildren<AudioSource> ().enabled = (true);
			text.GetComponent<TextMesh> ().text = "LEVEL COMPLETE";
		}
	}
}
