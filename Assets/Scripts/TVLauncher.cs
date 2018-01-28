using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TVLauncher : PossesableObject {
    
    public GameObject antennaLauncher;
    public float launchPower = 10;
    
	// Update is called once per frame
	void Update () {
		MoveAntenna ();	
		SpawnOut ();
	}

	void MoveAntenna(){
		if (isPossesed) {

			if (Input.GetKey (KeyCode.D) && (transform.rotation.z > -0.3)) {
                antennaLauncher.transform.Rotate (Vector3.forward * Time.deltaTime * -1 * 40, Space.World);
			}
			if (Input.GetKey (KeyCode.A) && (transform.rotation.z < 0.3)) {
                antennaLauncher.transform.Rotate (Vector3.forward * Time.deltaTime * 40, Space.World);
			}
			
		}
	}

	void SpawnOut(){
		if (isPossesed) {
			if (Input.GetKeyDown (KeyCode.Space)) {

				Vector3 spawnPoint = transform.position;
				spawnPoint.y += 1.1f;
				player.transform.position = spawnPoint;
                //charRigid.gravityScale = 0;

                PlatformerMotor2D pm2 = player.GetComponent<PlatformerMotor2D>();
                
                UnPosssessThis();

                pm2.velocity = antennaLauncher.transform.up * launchPower;

            }	
			
		}
	}

}
