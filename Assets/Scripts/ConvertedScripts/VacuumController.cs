using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VacuumController : PossesableObject
{

    public AudioClip TurnOn;
    public AudioClip TurnOff;
    public AudioClip Running;

    private AudioSource audioSource;

    public bool goingLeft = false;


    // Use this for initialization
    public override void Start()
    {
        audioSource = this.gameObject.GetComponent<AudioSource>();
        audioSource.clip = Running;
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {

        Control();
    }

    void Control()
    {
        if (isPossesed)
        {

            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(Vector2.right * Time.deltaTime * 4);
                goingLeft = false;
                if (!goingLeft)
                {
                    gameObject.GetComponentInChildren<SpriteRenderer>().flipX = false;
                }
            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(Vector2.right * Time.deltaTime * 4 * -1);
                goingLeft = true;
                if (goingLeft)
                {
                    gameObject.GetComponentInChildren<SpriteRenderer>().flipX = true;
                }
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {

                Vector3 spawnPoint = transform.position;
                spawnPoint.y += 1.1f;

                player.transform.position = spawnPoint;
				PlatformerMotor2D pm2 = player.GetComponent<PlatformerMotor2D>();

                UnPosssessThis();


				pm2.Jump();


            }

        }
    }

    public override void possessAudio()
    {
        audioSource.PlayOneShot(TurnOn);
        audioSource.PlayDelayed(1);
        base.possessAudio();
        
    }

    public override void unpossessAudio()
    {
        audioSource.Stop();
        audioSource.PlayOneShot(TurnOff);

        base.unpossessAudio();
    }
}
