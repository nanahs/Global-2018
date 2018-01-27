using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VacuumController : MonoBehaviour {

	public GameObject player;
	public CharacterBaseController controller;
	public Rigidbody charRigid;

	// Use this for initialization
	void Start () {
		controller = player.GetComponent<CharacterBaseController> ();
		charRigid = player.GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		Control ();
	}

	void Control(){
		if (controller.nearVacuum) {
			if(Input.GetKey(KeyCode.D)){
				transform.Translate(Vector2.right * Time.deltaTime * controller.speed * 2);
			}
			if(Input.GetKey(KeyCode.A)){
				transform.Translate(Vector2.right * Time.deltaTime * controller.speed * 2 * -1);
			}
			if (Input.GetKeyDown (KeyCode.S)) {

				controller.gameObject.transform.position = transform.position;
				controller.gameObject.SetActive (true);
				charRigid.AddForce(transform.up * 500);
				controller.nearVacuum = false;
			}
		}	
	}

}

