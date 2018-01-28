﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VacuumController : MonoBehaviour {

	public GameObject player;
	public PlayerInput controller;
	public Rigidbody2D charRigid;
	public bool near = false;
	public bool inControl = false;
	public bool goingLeft = false;
	private int counter = 0;
	public bool wasHitVac = false;
	public CameraFollow camScr;
	public Camera cam;
	public GameObject objectPush;
	public Vector3 xMotion;

	// Use this for initialization
	void Start () {
		controller = player.GetComponent<PlayerInput> ();
		charRigid = player.GetComponent<Rigidbody2D> ();
		near = controller.nearVacuum;
		camScr = cam.GetComponent<CameraFollow> ();
	}
	
	// Update is called once per frame
	void Update () {
		
		Control ();
	}

	void Control(){
		near = controller.nearVacuum;
		if (wasHitVac) {
			if (near) {
				camScr.defaultTarget = gameObject;
				//controller.transSound.Play ();
				if (Input.GetKey (KeyCode.D)) {
					transform.Translate (Vector2.right * Time.deltaTime * 4);
					goingLeft = false;
					if (!goingLeft) {
						gameObject.GetComponentInChildren<SpriteRenderer> ().flipX = false;
					}
				}
				if (Input.GetKey (KeyCode.A)) {
					transform.Translate (Vector2.right * Time.deltaTime * 4 * -1);
					goingLeft = true;
					if (goingLeft) {
						gameObject.GetComponentInChildren<SpriteRenderer> ().flipX = true;
					}
				}
				if (Input.GetKeyDown (KeyCode.W)) {

					Vector3 spawnPoint = transform.position;
					spawnPoint.y += 1.1f;
					controller.gameObject.transform.position = spawnPoint;
					controller.gameObject.SetActive (true);
					camScr.defaultTarget = controller.gameObject;
					charRigid.gravityScale = 0;
					charRigid.AddForce (transform.up * 750);
					charRigid.gravityScale = 1;
					controller.unPossSound.Play ();
					controller.nearVacuum = false;
					controller.vacuumRunning.enabled = false;
					controller.vacuumOff.Play ();
					wasHitVac = false;
				}
			}	
		}
	}

	void OnCollisionEnter2D(Collision2D col){
		if(col.gameObject.name == "Box"){
		objectPush = col.gameObject;	
			xMotion = transform.position;
			objectPush.transform.position = new Vector3((float) xMotion.x,(float) xMotion.y,(float) xMotion.z);
		
	}



}
}

