using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour {
    public Text p1Nameplate; // a reference to player 1's name tag
    public Text p2Nameplate; //a reference to player 2's name tag

    public Text TitleText; //a reference to the onscreen text for game title
    public Text InstrucText; //a reference to the onscreen text for game instructions

    public Image p1Vic1; //icon for p1 victory
    public Image p1Vic2; //icon for p1 second victory
    public Image p2Vic1; //icon for p2 victory
    public Image p2Vic2; //icon for p2 second victory

    public Text countdownText; //ref to "Get Ready..." text



    private string p1FighterName; //we will store p1's fighter's name in this variable which will be used in the nameplate
    private string p2FighterName; //we will store p2's fighter's name in this variable which will be used in the nameplate

    

	// Use this for initialization
	void Start ()
    {
        SelectionUI(); //at the start of the application, we want to go right into selection UI, so players can choose their fighters
	}
	
	// Update is called once per frame
	void Update ()
    {


    }

    public void SelectionUI() //this function is called whenever we want to go back to the main menu and select fighters
    {
        TitleText.text = "THE FIGGITY FACEOFF"; //change title of game here
        InstrucText.text = "Press X to change fighter. Press OPTIONS to begin"; //change instructions here
    }

    public void CollectFighter1Name(string fightName) //NOTE: OBSOLETE
    {
        Debug.Log("player 1 is " + fightName.ToString());
        p1Nameplate.text = fightName.ToString(); //in real time, update the player nameplates
    }

    public void CollectFighter2Name(string fightName) //NOTE: OBSOLETE
    {
        Debug.Log("player 2 is " + fightName.ToString());
        p2Nameplate.text = fightName.ToString(); //in real time, update the player nameplates
    }

    public void CollectNames(int playNum, string name) //From PlayerController, collect fightername and playNum to assign correct nameplate titles
    {
        if (playNum == 1)
        {
            p1Nameplate.text = name.ToString();
        }
        if (playNum == 2)
        {
            p2Nameplate.text = name.ToString();
        }
    }

    public IEnumerator CountdownUI(float time) //this begins the round countdown UI onscreen
    {

        countdownText.text = "Get Ready..."; //change countdown text here
        countdownText.color = Color.white;

        yield return new WaitForSeconds(time); //this value is received from the StateManager script

        countdownText.text = "FIGGITY FIGHT!";
        countdownText.color = Color.red;

        yield return new WaitForSeconds(1); //wait for one sec, then...

        countdownText.text = ""; //take the text offscreen

    }

}
