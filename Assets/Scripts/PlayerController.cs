﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public int playerNumber = 0;
    public int speed; //how fast should we move when we push left or right?
    public bool canInput = false;

    public string _fighterName = null;

    [SerializeField]
    private PlayerMotor motor; //ref to the motor, where we will send our inputs to be applied

    [SerializeField]
    private PlayerAnimator myAnimator; //a ref to the animation script, which will tell our sprite how to animate

    private HUDManager hud;

    private StateManager state;

	// Use this for initialization
	void Start ()
    {
        
        motor = GetComponent<PlayerMotor>(); //tell unity what we mean when we say motor

        myAnimator = GetComponent<PlayerAnimator>(); //tell untiy what we mean when we say anim
        myAnimator.SetStartingDirection(playerNumber); //send the playernum over to anim

        hud = FindObjectOfType<HUDManager>(); //find the HUDMANAGER obj
        hud.CollectNames(playerNumber, _fighterName); //collect player names for nameplates

        state = FindObjectOfType<StateManager>();

    }

    // Update is called once per frame
    void Update ()
    {


        if (canInput) //if player should be allowed to move during this frame...
        {
            //collect inputs in the form of floats
            float hInput = Input.GetAxisRaw(playerNumber + "Horizontal"); //if we push arrow key left/right, we will get -1, 0, or 1

            //Debug.Log(hInput); //make sure it's working, lol.

            //have those inputs affect our direction (transform.right)
            Vector3 _hMov = (transform.right * hInput); //so our horizontal dir will either be 0, left (-1) or right (1)

            //have those inputs be stored in a final "velocity" var which includes speed and time.deltatime
            Vector3 _velocity = (_hMov * speed); //we have a direction and a speed at which to go there

            //send that _velocity vec3 over to motor.
            motor.ReceiveVelocity(_velocity); //since this is in Update, the motor will constantly receive our current _velocity, and move our player based on that value


            if (Input.GetButtonDown("Submit")) //let players restart the round by pressing ps button
            {
                state.RoundCountdown(); //repos players etc
            }


            if (hInput != 0)
            {
                myAnimator.RunAnim(_fighterName);
            }
            else if (hInput == 0)
            {
                myAnimator.IdleAnim(_fighterName);
            }

            myAnimator.FlipSprite(hInput); //send our current hInput over to SpriteAnimator

            if (Input.GetButtonDown(playerNumber + "Fire1"))
            {
                myAnimator.PunchAnim(_fighterName);


            }

            if (Input.GetButtonDown(playerNumber + "Fire2"))
            {
                motor.PerformDash(_hMov);
            }

            if (Input.GetButtonDown(playerNumber + "Fire3"))
            {
                myAnimator.SpecialAnim(_fighterName);
            }
        } else //otherwise just put him in the idle state NOTE This will prob cause problems when death state becomes implemented
        {
            myAnimator.IdleAnim(_fighterName);
        }
       

        /* if (Input.GetButton(playerNumber + "Fire3"))
        {
            motor.PerformJump();
        } */
	} 
   

    public IEnumerator UnlockController(float time)
    {
        canInput = false; //make it so we cannot use the controller

        yield return new WaitForSeconds(time);

        canInput = true;
    }

    public void FreezeController()
    {
        canInput = false;
    }

    public void UnfreezeController()
    {
        canInput = true;
    }
}
