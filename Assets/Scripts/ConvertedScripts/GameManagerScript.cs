using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

		if (Input.GetKeyDown (KeyCode.R)) {
			SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
		}

		if (Input.GetKeyDown (KeyCode.Escape)) {
			Application.Quit();
		}

	}
    
    void checkWinConditions()
    {
        text.text = "Lights: " + lightManager.NumLightsLit + " / " + lightManager.TotalLights;

        if (lightManager.IsAllLit)
        {
            soundManager.audioSource.PlayOneShot(soundManager.winning);
            Invoke("winStage", 3.5f);

        }
        else
        {
            Invoke("checkWinConditions", .5f);
        }
    }

	void winStage(){
		
		text.text = "LEVEL COMPLETE";
		Camera.main.GetComponent<AudioSource> ().Pause();


		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex + 1);
	}
}
