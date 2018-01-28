using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmpyController : MonoBehaviour {

    public PossesableObject PosObj;

    public AudioClip jump;

    private PlatformerMotor2D _motor;
    public AudioSource audioSource;

    private bool alreadyJumped = false;
    

    // Use this for initialization
    void Start () {
        _motor = GetComponent<PlatformerMotor2D>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update ()
    {

        if(PosObj != null)
        {

            if (Input.GetKeyDown(KeyCode.E))
            {
                PosObj.PossessThis();
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

}
