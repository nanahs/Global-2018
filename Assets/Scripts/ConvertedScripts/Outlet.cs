using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Outlet : PossesableObject {

	public GameObject otherOutlet;
	public LightScript Light;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        
		if (isPossesed) {

            Light.toggleLight();
            player.transform.position = otherOutlet.transform.position;
            UnPosssessThis();

		}
	}

}
