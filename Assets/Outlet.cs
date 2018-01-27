using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Outlet : MonoBehaviour {

	public GameObject otherOutlet;
	public GameObject player;
	public Rigidbody2D charRigid;
	public PlayerInput controller;
	public bool wasHitOut = false;

	// Use this for initialization
	void Start () {
		controller = player.GetComponent<PlayerInput> ();
		charRigid = player.GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (wasHitOut) {
			player.transform.position = otherOutlet.transform.position;
			wasHitOut = false;
			charRigid.AddForce(transform.up * 100);
		}
	}
}
