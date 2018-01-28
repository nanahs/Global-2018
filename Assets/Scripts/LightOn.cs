using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightOn : MonoBehaviour {

	//public GameObject lightObject;
	public GameObject player;
	public PlayerInput controller;
	public GameObject Game;
	Light light;
	public bool wasHit = false;

	// Use this for initialization
	void Start () {
		controller = player.GetComponent<PlayerInput> ();
		light = gameObject.GetComponentInChildren<Light> ();
	}

	// Update is called once per frame
	void Update () {
		if (controller.nearLight && wasHit) {
			if (light.intensity == 0) {
				gameObject.GetComponentInChildren<Light> ().intensity = .5f;
			} else {
				gameObject.GetComponentInChildren<Light> ().intensity = 0;
			}
			controller.nearLight = false;
			wasHit = false;
		}
	}
}




