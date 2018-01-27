using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightOn : MonoBehaviour {

	public GameObject lightObject;
	public GameObject player;
	public PlayerInput controller;
	public GameObject Game;
	public bool wasHit = false;

	// Use this for initialization
	void Start () {
		controller = player.GetComponent<PlayerInput> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (controller.nearLight && gameObject.GetComponentInChildren<Light> ().intensity == 0) {
			if (wasHit) {
				lightObject.GetComponent<Light> ().intensity = .5f;
				Game.GetComponent<GameManager> ().counter++;
				controller.nearLight = false;
			}

		} else if (controller.nearLight && gameObject.GetComponentInChildren<Light> ().intensity == 0.5f) {
			if (wasHit) {
				lightObject.GetComponent<Light> ().intensity = 0;
				Game.GetComponent<GameManager> ().counter--;
				controller.nearLight = false;

			}

		} 
	}
}




