﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public int playerNumber = 0;
    public int speed; //how fast should we move when we push left or right?

    [SerializeField]
    private PlayerMotor motor; //ref to the motor, where we will send our inputs to be applied

    [SerializeField]
    private PlayerAnimator anim; //a ref to the animation script, which will tell our sprite how to animate

	// Use this for initialization
	void Start ()
    {
        motor = GetComponent<PlayerMotor>(); //tell unity what we mean when we say motor
        anim = GetComponent<PlayerAnimator>(); //tell untiy what we mean when we say anim
	}
	
	// Update is called once per frame
	void Update ()
    {
        //collect inputs in the form of floats
        float hInput = Input.GetAxisRaw(playerNumber+"Horizontal"); //if we push arrow key left/right, we will get -1, 0, or 1

        //Debug.Log(hInput); //make sure it's working, lol.

        //have those inputs affect our direction (transform.right)
        Vector3 hMov = (transform.right * hInput); //so our horizontal dir will either be 0, left (-1) or right (1)

        //have those inputs be stored in a final "velocity" var which includes speed and time.deltatime
        Vector3 _velocity = (hMov * speed); //we have a direction and a speed at which to go there

        //send that _velocity vec3 over to motor.
        motor.ReceiveVelocity(_velocity); //since this is in Update, the motor will constantly receive our current _velocity, and move our player based on that value
	}
}
