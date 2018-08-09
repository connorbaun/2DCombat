using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour {

    private Vector3 velocity = Vector3.zero; //we will store the _velocity from PlayerController here


    [SerializeField]
    private Rigidbody2D rb;

    [SerializeField]
    private float dashForce = 50;

    public float jumpForce = 500;

    private PlayerController controller;


	// Use this for initialization
	void Start ()
    {
        //StartCoroutine(UnlockMotor(3));
        rb = GetComponent<Rigidbody2D>(); //tell unity to seek out the rb attached to the player obj
        controller = GetComponent<PlayerController>();
        
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

    public void PerformDash(Vector3 hMov)
    {
        rb.AddForce(hMov * dashForce);
        
    }

    public void PerformJump()
    {
        rb.AddForce((Vector2.up * jumpForce));
        //NOTE: JUMP IS CURRENTLY DISABLED INSIDE OF PLAYCONTROLLER
    } 


    public IEnumerator UnlockMotor(float time)
    {
        enabled = false; 
        yield return new WaitForSeconds(time);
        enabled = true;
    }
    
    public void FreezeMotor()
    {
        enabled = false;
    }

    public void UnfreezeMotor()
    {
        enabled = true;
    }
}
