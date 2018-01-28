using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intro : MonoBehaviour {

    public GameObject text;
    public GameObject ampy;
    public GameObject theLights;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    public void ShowText()
    {
        text.SetActive(true);
        theLights.SetActive(true);
    }

    public void ShowAmpy()
    {
        ampy.SetActive(true);
    }

}
