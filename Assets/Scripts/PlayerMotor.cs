using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour {

    private Vector3 velocity = Vector3.zero; //we will store the _velocity from PlayerController here


    [SerializeField]
    private Rigidbody2D rb;

    [SerializeField]
    private float dashForce = 50;

	// Use this for initialization
	void Start ()
    {
        rb = GetComponent<Rigidbody2D>(); //tell unity to seek out the rb attached to the player obj
        
	}

    public void ReceiveVelocity(Vector3 _velocity)
    {
        velocity = _velocity;
    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        PerformMovement();
	}

    public void PerformMovement()
    {
        rb.MovePosition(transform.position + velocity * Time.fixedDeltaTime);
    }

    public void PerformDash()
    {
        rb.AddForce(velocity * dashForce);
    }
}
