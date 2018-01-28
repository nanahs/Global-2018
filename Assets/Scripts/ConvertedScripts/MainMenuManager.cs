using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Begin(){
		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex + 1);
	}

	public void Credits(){
		SceneManager.LoadScene("Credits");
	}

	public void Quit(){
		Application.Quit();
	}
}
