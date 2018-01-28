using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VacuumController : PossesableObject
{

    public bool goingLeft = false;
    private int counter = 0;


    // Use this for initialization
    void Start()
    {
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
            if (counter == 0)
            {


            }
            counter++;
            //controller.transSound.Play ();
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
                pm2.Jump();

                UnPosssessThis();




            }

        }
    }


}
