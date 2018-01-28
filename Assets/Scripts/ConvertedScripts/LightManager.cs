using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour {

    public LightScript[] AllLightsInScene;

    public bool IsAllLit = false;
    public int TotalLights;
    public int NumLightsLit;

    public Light globalLight;

	// Use this for initialization
	void Start () {

        AllLightsInScene = GameObject.FindObjectsOfType<LightScript>();
        TotalLights = AllLightsInScene.Length;
        Invoke("CheckLightsLamps", .5f);
    }

    // Update is called once per frame
    void Update () {
		
	}

    void CheckLightsLamps()
    {
        NumLightsLit = 0;

        foreach (var l in AllLightsInScene)
        {
            if (l.IsLit)
            {
                NumLightsLit++;
            }
        }

        if(NumLightsLit == TotalLights)
        {
            IsAllLit = true;
        }
        else
        {
            IsAllLit = false;
        }

        globalLight.intensity = (float)NumLightsLit / (float)TotalLights;

        Invoke("CheckLightsLamps", .5f);
    }
}
