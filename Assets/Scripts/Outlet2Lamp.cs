using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Outlet2Lamp : MonoBehaviour {

	public GameObject otherOutlet;
	public GameObject player;
	public Rigidbody2D charRigid;
	public PlayerInput controller;
	public bool wasHitOut2 = false;
	public GameObject standingLamp;
	public GameObject standingLamp2;
	public GameObject Game;

	// Use this for initialization
	void Start () {
		controller = player.GetComponent<PlayerInput> ();
		charRigid = player.GetComponent<Rigidbody2D> ();
	}

	// Update is called once per frame
	void Update () {
		if (wasHitOut2) {
			player.transform.position = otherOutlet.transform.position;
			wasHitOut2 = false;
			charRigid.AddForce(transform.up * 100);
			if (standingLamp != null) {
				if (standingLamp.GetComponentInChildren<Light> ().intensity == 0.0f) {
					standingLamp.GetComponentInChildren<Light> ().intensity = 0.5f;
					standingLamp2.GetComponentInChildren<Light> ().intensity = 0.5f;
				} else {
					standingLamp.GetComponentInChildren<Light> ().intensity = 0.0f;
					standingLamp2.GetComponentInChildren<Light> ().intensity = 0.0f;
				}
			}
		}
	}
}
