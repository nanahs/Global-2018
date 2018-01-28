using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmpyController : MonoBehaviour {

    public PossesableObject PosObj;

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update ()
    {

        if(PosObj != null)
        {

            if (Input.GetKeyDown(KeyCode.E))
            {
                PosObj.PossessThis();
            }

        }
        
    }

}
