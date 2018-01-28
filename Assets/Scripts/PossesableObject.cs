using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PossesableObject : MonoBehaviour {

    public bool isPossesed = false;

    public GameObject player;
    public AmpyController ampyCont;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (isPossesed) {

            if(Input.GetKey(KeyCode.Space)){

                //Leave possessed object
                UnPosssessThis();
            }

        }

	}

    public virtual void PossessThis()
    {
        isPossesed = true;

        player.transform.parent = this.gameObject.transform;
        player.SetActive(false);
        
    }

    public virtual void UnPosssessThis()
    {
        isPossesed = false;
        player.SetActive(true);
        player.transform.parent = null;
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            assignPlayer(other);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(isPossesed && other.gameObject.CompareTag("Player"))
        {
            return;
        }

        if (other.gameObject.CompareTag("Player"))
        {
            removePlayer();
        }
    }

    void assignPlayer(Collider2D other)
    {
        player = other.gameObject;
        ampyCont = player.GetComponent<AmpyController>();

        ampyCont.PosObj = this;
    }

    void removePlayer()
    {
        ampyCont.PosObj = null;
        ampyCont = null;
        player = null;
    }
}
