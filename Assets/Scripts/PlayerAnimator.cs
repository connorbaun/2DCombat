using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour {

    public string fighterName = null;

    private Animator anim;

    
	// Use this for initialization
	void Start () {

        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        
	}

    public void RunAnim(string fighterName)
    {
        if (!anim.GetCurrentAnimatorStateInfo(0).IsName(fighterName + "_punch"))
        {
            anim.Play(fighterName + "_run");
        }
            
    }

    public void IdleAnim(string fighterName)
    {  
        if (!anim.GetCurrentAnimatorStateInfo(0).IsName(fighterName + "_punch"))
        {
            anim.Play(fighterName + "_idle");
        }
        
    }

    public void PunchAnim(string fighterName)
    {
        if (!anim.GetCurrentAnimatorStateInfo(0).IsName(fighterName + "_punch"))
        {
            anim.Play(fighterName + "_punch");
        }
    }
}
