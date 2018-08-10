using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour {

    public float _countdownTime = 3; //sent to other scripts, this is how long it take for match to countdown

    public GameObject player1; //reference to player1
    public GameObject player2; //reference to player2

    private PlayerController p1Cont; //name for player 1's controller
    private PlayerController p2Cont; //name for player 2's controller

    private PlayerMotor p1Mot; //name for player 1's motor
    private PlayerMotor p2Mot; //name for player 2's motor


    private HealthManager health; //ref to the healthmanager gameobject

    private HUDManager hud;


	// Use this for initialization
	void Start ()
    {
        health = FindObjectOfType<HealthManager>();
        hud = FindObjectOfType<HUDManager>();

        p1Cont = player1.GetComponent<PlayerController>(); //find p1 controller
        p2Cont = player2.GetComponent<PlayerController>(); //find p1 motor
        p1Mot = player1.GetComponent<PlayerMotor>(); //find p2 controller
        p2Mot = player2.GetComponent<PlayerMotor>(); //find p2 motor


        //RoundCountdown();

	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}


    public void RoundCountdown()
    {
        //reset player pos/orientations
        player1.transform.position = new Vector3(-10, 0, 0);
        player2.transform.position = new Vector3(10, 0, 0);
        player1.GetComponent<PlayerAnimator>().SetStartingDirection(1);
        player2.GetComponent<PlayerAnimator>().SetStartingDirection(2);

        player1.GetComponent<PlayerAnimator>().ForceIdle(player1.GetComponent<PlayerController>()._fighterName);
        player2.GetComponent<PlayerAnimator>().ForceIdle(player2.GetComponent<PlayerController>()._fighterName);

        hud.InstrucText.text = "";
        hud.TitleText.text = "";





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
        hud.StartCoroutine(hud.CountdownUI(_countdownTime));
         //remove countdown UI from screen and let players FIGHT!
            //Not implemented yet ya dang goobis.
    }



}
