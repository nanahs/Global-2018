using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intro : MonoBehaviour {

    public GameObject text;
    public GameObject ampy;
    public GameObject theLights;
	public GameObject start;
	public GameObject quit;
	public GameObject credits;

	public AudioSource audioSource;

    // Use this for initialization
    void Start() {
		audioSource = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update() {

    }

    public void ShowText()
    {
        text.SetActive(true);
        theLights.SetActive(true);
		audioSource.Play();
		start.GetComponent<MeshRenderer> ().enabled = true;
		credits.GetComponent<MeshRenderer> ().enabled = true;
		quit.GetComponent<MeshRenderer> ().enabled = true;
		    
	}

    public void ShowAmpy()
    {
        ampy.SetActive(true);
    }

}
