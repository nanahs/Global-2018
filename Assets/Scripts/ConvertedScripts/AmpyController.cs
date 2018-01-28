using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmpyController : MonoBehaviour {

    public PossesableObject PosObj;

    public AudioClip jump;

    private PlatformerMotor2D _motor;
    public AudioSource audioSource;
	private Animator _animator;

    private bool alreadyJumped = false;
	public bool isMerging = false;
    

    // Use this for initialization
    void Start () {
        _motor = GetComponent<PlatformerMotor2D>();
        audioSource = GetComponent<AudioSource>();
		_animator = this.gameObject.GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update ()
    {
		
		if(PosObj != null && !isMerging)
        {

            if (Input.GetKeyDown(KeyCode.E))
            {
				isMerging = true;
				Invoke ("PossessObj", 1);
            }

        }

        if (_motor.motorState == PlatformerMotor2D.MotorState.Jumping && !alreadyJumped)
        {
            alreadyJumped = true;
            audioSource.PlayOneShot(jump);
        }
        else if(_motor.motorState == PlatformerMotor2D.MotorState.OnGround)
        {
            alreadyJumped = false;
        }
        
    }

	void PossessObj(){

		isMerging = false;
		PosObj.PossessThis();
	}

}
