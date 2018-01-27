using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightOn : MonoBehaviour {

	public bool light = false;
	public GameObject lightObject;
	public GameObject player;
	public PlayerInput controller;

	// Use this for initialization
	void Start () {
		controller = player.GetComponent<PlayerInput> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (controller.nearLight && lightObject.GetComponent<Light> ().intensity == 0) {
			lightObject.GetComponent<Light> ().intensity = .5f;
			controller.nearLight = false;
		} else if (controller.nearLight && lightObject.GetComponent<Light> ().intensity == .5f) {
			lightObject.GetComponent<Light> ().intensity = 0;
			controller.nearLight = false;

		} else {
			//lightObject.GetComponent<Light> ().intensity = 0;
		}
		}
}




