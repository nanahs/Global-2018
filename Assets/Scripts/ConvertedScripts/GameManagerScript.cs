using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour {

	public Text text;
    public LightManager lightManager;
	public SoundManager soundManager;



	// Use this for initialization
	void Start () {
        soundManager = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>();

        Invoke("checkWinConditions", .5f);
    }
	
	// Update is called once per frame
	void Update () {

		
	}
    
    void checkWinConditions()
    {
        text.text = "Lights: " + lightManager.NumLightsLit + " / " + lightManager.TotalLights;

        if (lightManager.IsAllLit)
        {
            soundManager.audioSource.PlayOneShot(soundManager.winning);
            text.text = "LEVEL COMPLETE";
        }
        else
        {
            Invoke("checkWinConditions", .5f);
        }
    }
}
