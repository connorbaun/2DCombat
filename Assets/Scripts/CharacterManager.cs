using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

public class Fighter
{
    public string name = "missing";
    public int punchDamage = 0;
    public int specialDamage = 0;
    public int moveSpeed = 0;

    public Fighter() { } //default (fallback) constructor

    public Fighter(string nm, int punch, int special, int speed) //the real constructor that lets us make new Fighters
    {
        name = nm;
        punchDamage = punch;
        specialDamage = special;
        moveSpeed = speed;  
    }
}
