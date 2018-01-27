using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour {

	public float loopStart = 4;
	public float loopLength = 32;
	AudioSource source;

	// Use this for initialization
	void Start () {
		source = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(source.time > loopStart + loopLength){
			source.time -= loopLength;
		}
	}
}
