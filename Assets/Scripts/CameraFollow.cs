using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	public GameObject defaultTarget;
	Camera cam;
	Vector3 targetPos;

	void Awake(){
		cam = GetComponent<Camera> ();

	}

	// Use this for initialization
	void Start () {
		
		transform.position = defaultTarget.transform.position;
		targetPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (defaultTarget.activeInHierarchy) {
			targetPos = defaultTarget.transform.position;
			targetPos.y += .5f;
			targetPos.z = -10;
		}
		cam.transform.position = Vector3.Lerp (cam.transform.position, targetPos, 0.1f);
	}
}
