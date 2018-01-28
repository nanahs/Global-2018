using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PossesableObject : MonoBehaviour {

    public bool isPossesed = false;

    public GameObject player;
    public AmpyController ampyCont;

    public SoundManager soundManager;

	// Use this for initialization
	public virtual void Start () {
        soundManager = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>();
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
        possessAudio();
        isPossesed = true;

        player.transform.parent = this.gameObject.transform;
        player.SetActive(false);
        
    }

    public virtual void UnPosssessThis()
    {
        unpossessAudio();
        isPossesed = false;
        player.SetActive(true);
        player.transform.parent = null;
        removePlayer();
        
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

    public void assignPlayer(Collider2D other)
    {
        player = other.gameObject;
        ampyCont = player.GetComponent<AmpyController>();

        ampyCont.PosObj = this;
    }

    public void removePlayer()
    {
        ampyCont.PosObj = null;
        ampyCont = null;
        player = null;
    }

    public virtual void possessAudio()
    {
        soundManager.audioSource.PlayOneShot(soundManager.possess);
    }

    public virtual void unpossessAudio()
    {
        soundManager.audioSource.PlayOneShot(soundManager.unpossess);
    }
}
