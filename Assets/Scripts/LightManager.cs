using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour {

    public LightScript[] AllLightsInScene;
    //public LampScript[] AllLampsInScene;

    public bool IsAllLit = false;

	// Use this for initialization
	void Start () {

        AllLightsInScene = GameObject.FindObjectsOfType<LightScript>();
        //AllLampsInScene = GameObject.FindObjectsOfType<LampScript>();

        Invoke("CheckLightsLamps", 1);
    }

    // Update is called once per frame
    void Update () {
		
	}

    void CheckLightsLamps()
    {
        int numLit = 0;

        foreach (var l in AllLightsInScene)
        {
            if (l.IsLit)
            {
                numLit++;
            }
        }

        //foreach (var l in AllLampsInScene)
        //{
        //    if (l.IsLit)
        //    {
        //        numLit++;
        //    }
        //}

        int totalLights = AllLightsInScene.Length;
        //totalLights += AllLampsInScene.Length;

        if(numLit == totalLights)
        {
            IsAllLit = true;
        }
        else
        {
            IsAllLit = false;
        }

        Invoke("CheckLightsLamps", 1);
    }
}
