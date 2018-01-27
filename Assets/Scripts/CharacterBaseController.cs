using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBaseController : MonoBehaviour {

	public float speed = 1.0f;
	public bool nearVacuum = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Move ();
		takeControl ();

	}

	void Move(){
		if(Input.GetKey(KeyCode.D)){
			transform.Translate (Vector2.right * Time.deltaTime * speed);
		}
		if(Input.GetKey(KeyCode.A)){
			transform.Translate (Vector2.right * Time.deltaTime * speed * -1);
		}
	}

	void takeControl(){
		if (Input.GetKeyDown (KeyCode.S)) {
			RaycastHit hit;
			Ray ray = new Ray (transform.position, Vector2.right);
			if (Physics.Raycast (transform.position, Vector2.right, 5)) {
				Physics.Raycast (ray, out hit);
				if (hit.collider.CompareTag("VacuumCleaner")) {
					nearVacuum = true;
					gameObject.SetActive (false);
					//Vector3 spawnPoint = new Vector3 (hit.collider.transform.position.x, hit.collider.transform.position.y + 0.5, hit.collider.transform.position.z);
					transform.position = hit.collider.transform.position;


				}

			}
				
		}
	}


}
