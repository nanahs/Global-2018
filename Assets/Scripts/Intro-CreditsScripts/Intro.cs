using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intro : MonoBehaviour {

    public GameObject text;
    public GameObject ampy;
    public GameObject theLights;

	public AudioSource audioSource;

    // Use this for initialization
    void Start() {
		audioSource = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update() {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

    }

    public void ShowText()
    {
        text.SetActive(true);
        theLights.SetActive(true);
		audioSource.Play();
	}

    public void ShowAmpy()
    {
        ampy.SetActive(true);
    }

}
