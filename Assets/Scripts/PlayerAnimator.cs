using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour {
    public float specialTime = 1f; //a ref to the amount of time before we can move when performing a special move!

    private string fighterName = null; //we will pass in a fighter name from other scripts. this allows the animator to know which character anims to play at which times.
    
    private Animator anim; //a ref to the animator obj attached to all players

    private PlayerMotor motor;
    private PlayerController controller;

    //NOTE: we call the correct anims for diff chars by using the same naming conventions for each char's animations. this way, we can just fill in the char's name to retrieve a particular animation for a particular character!

    
	// Use this for initialization
	void Start () {

        anim = GetComponent<Animator>(); //tell unity to seek the animator attached to the player obj.
        motor = GetComponent<PlayerMotor>(); //tell unity to seek the playermotor
        controller = GetComponent<PlayerController>(); //tell unity to seek the player controller
	}
	
	// Update is called once per frame
	void Update ()
    {
        
	}

    public void RunAnim(string fighterName) //this function takes in fighter's name from controller, which tells the game which anim to play.
    {
        if (!anim.GetCurrentAnimatorStateInfo(0).IsName(fighterName + "_punch") && !anim.GetCurrentAnimatorStateInfo(0).IsName(fighterName + "_special")) //as long as we arent in the midst of a punch...
        {
            anim.Play(fighterName + "_run"); //let us run around. in other words, punch interrupts run, but not the other way round
        }
            
    }

    public void IdleAnim(string fighterName) //idling anim.
    {
        if (!anim.GetCurrentAnimatorStateInfo(0).IsName(fighterName + "_punch") && !anim.GetCurrentAnimatorStateInfo(0).IsName(fighterName + "_special")) //as long as we are not punching...
        {
            anim.Play(fighterName + "_idle"); //go idle. we can idle as long as we aren't in the middle of a punching anim.
        }
        
        
    }

    public void PunchAnim(string fighterName) //punching anim.
    {
        if (!anim.GetCurrentAnimatorStateInfo(0).IsName(fighterName + "_punch") && !anim.GetCurrentAnimatorStateInfo(0).IsName(fighterName + "_special")) //as long as we arent already punching...
        {
            anim.Play(fighterName + "_punch"); //play the punch  anim from the designated character.
        }
    }

    public void SpecialAnim(string fighterName) //special move anim.
    {
        if (!anim.GetCurrentAnimatorStateInfo(0).IsName(fighterName + "_punch") && !anim.GetCurrentAnimatorStateInfo(0).IsName(fighterName + "_special"))
        {
            anim.Play(fighterName + "_special"); //perform special anim here
            StartCoroutine(controller.UnlockController(specialTime)); //do not allow the player to hit anything
            StartCoroutine(motor.UnlockMotor(specialTime)); //do not allow the player's character to move
        }
        

    }

    public void FlipSprite(float hInput) //this function allows our char to flip dirs when we move left or right
    {
        if (hInput < -.1f) //if we push left
        {
            transform.localScale = new Vector3(-5, 5, 5); //then our sprite should face left

        }

        if (hInput > .1f) //if we push right
        {
            transform.localScale = new Vector3(5, 5, 5); //then our sprite should face right

        }

    }
}
