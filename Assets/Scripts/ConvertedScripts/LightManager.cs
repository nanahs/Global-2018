using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour {

    public LightScript[] AllLightsInScene;

    public bool IsAllLit = false;
    public int TotalLights;
    public int NumLightsLit;

	// Use this for initialization
	void Start () {

        AllLightsInScene = GameObject.FindObjectsOfType<LightScript>();
        TotalLights = AllLightsInScene.Length;
        Invoke("CheckLightsLamps", 1);
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

        Invoke("CheckLightsLamps", 1);
    }
}
