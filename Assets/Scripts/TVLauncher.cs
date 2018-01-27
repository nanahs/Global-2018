using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TVLauncher : MonoBehaviour {

	//public bool light = false;
	//public GameObject lightObject;
	public GameObject player;
	public PlayerInput controller;
	public Rigidbody2D charRigid;
	//private float timer = 5.0f;
	public bool wasHitTV = false;

	// Use this for initialization
	void Start () {
		controller = player.GetComponent<PlayerInput> ();
		charRigid = player.GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		MoveAntenna ();	
		SpawnOut ();
	}

	void MoveAntenna(){
		if (wasHitTV) {
			if (controller.nearTV) {
				if (Input.GetKey (KeyCode.D) && (transform.rotation.z > -0.3)) {
					transform.Rotate (Vector3.forward * Time.deltaTime * -1 * 40, Space.World);
				}
				if (Input.GetKey (KeyCode.A) && (transform.rotation.z < 0.3)) {
					transform.Rotate (Vector3.forward * Time.deltaTime * 40, Space.World);
				}
			}
		}
	}

	void SpawnOut(){
		if (wasHitTV) {
			if(controller.nearTV){
				if (Input.GetKeyDown (KeyCode.W)) {

					Vector3 spawnPoint = transform.position;
					spawnPoint.y += 1.1f;
					controller.gameObject.transform.position = spawnPoint;
					controller.gameObject.SetActive (true);
					controller.unPossSound.Play ();
					//charRigid.gravityScale = 0;
					charRigid.AddForce(transform.up * 500);
					controller.nearTV = false;
					wasHitTV = false;

				}	
			}

		}
	}

}
