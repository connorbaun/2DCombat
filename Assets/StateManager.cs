using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour {
    public float _countdownTime = 3;

    public GameObject player1;
    public GameObject player2;

    private PlayerController p1Cont;
    private PlayerController p2Cont;

    private PlayerMotor p2Mot;
    private PlayerMotor p1Mot;

    private HealthManager health;


	// Use this for initialization
	void Start ()
    {
        health = FindObjectOfType<HealthManager>();

        p1Cont = player1.GetComponent<PlayerController>();
        p2Cont = player2.GetComponent<PlayerController>();
        p1Mot = player1.GetComponent<PlayerMotor>();
        p2Mot = player2.GetComponent<PlayerMotor>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void RoundCountdown()
    {
        //reset player pos
        player1.transform.position = new Vector3(-10, 0, 0);
        player2.transform.position = new Vector3(10, 0, 0);

        //freeze motor and controller (_countdownTime)
        p1Cont.StartCoroutine(p1Cont.UnlockController(_countdownTime));
        p1Mot.StartCoroutine(p1Mot.UnlockMotor(_countdownTime));

        //freeze motor and controller (_countdownTime)
        p2Mot.StartCoroutine(p2Mot.UnlockMotor(_countdownTime));
        p2Cont.StartCoroutine(p2Cont.UnlockController(_countdownTime));

       

        



        //refill player hp levels
        health.p1HP = 100;
        health.p2HP = 100;

        //refill player stamina
            //Not implemented yet

        //draw countdown to screen
            //Not implemented yet

         //remove countdown UI from screen and let players FIGHT!
            //Not implemented yet ya dang goobis.
    }
}
