using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Outlet : PossesableObject {

	public GameObject otherOutlet;
	public LightScript lightScript;
    
	
	// Update is called once per frame
	void Update () {
        
		if (isPossesed) {

            if(lightScript)
            {
                lightScript.toggleLight();
            }
            
            player.transform.position = otherOutlet.transform.position;
            UnPosssessThis();

		}
	}

}
