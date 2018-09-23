using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {
    public LayerMask mask;

    private float results;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Attack()
    {
        if (Physics2D.OverlapCircle(transform.position, 1f, mask, results))
        {
            Debug.Log(results);
        }
    }
}
