using System.Collections;
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


	// Use this for initialization
	void Start () {
		controller = player.GetComponent<PlayerInput> ();
		charRigid = player.GetComponent<Rigidbody2D> ();
		near = controller.nearVacuum;
	}
	
	// Update is called once per frame
	void Update () {
		
		Control ();
	}

	void Control(){
		near = controller.nearVacuum;
		if (wasHitVac) {
			if (near) {
				if (counter == 0) {
				


				}
				counter++;
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



}

