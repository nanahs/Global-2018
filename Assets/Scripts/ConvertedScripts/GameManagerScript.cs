using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour {

	public Text text;
    public LightManager lightManager;
	public AudioSource music;



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		text.text = "Lights: " + lightManager.NumLightsLit + " / " + lightManager.TotalLights;
		if (lightManager.IsAllLit) {
			print ("Level Complete!");
			music.enabled = false;
			gameObject.GetComponentInChildren<AudioSource> ().enabled = (true);
			text.text = "LEVEL COMPLETE";
		}
	}
}
