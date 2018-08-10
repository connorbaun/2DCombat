using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour {
    public Text p1Nameplate;
    public Text p2Nameplate;

    public Text TitleText;
    public Text InstrucText;

    public Image p1Vic1;
    public Image p1Vic2;
    public Image p2Vic1;
    public Image p2Vic2;

    public Text countdownText;



    private string p1FighterName;
    private string p2FighterName;

    

	// Use this for initialization
	void Start ()
    {
        SelectionUI();
	}
	
	// Update is called once per frame
	void Update ()
    {


    }

    public void SelectionUI()
    {
        TitleText.text = "THE FIGGITY FACEOFF";
        InstrucText.text = "Press X to change fighter. Press OPTIONS to begin";
    }

    public void CollectFighter1Name(string fightName)
    {
        Debug.Log("player 1 is " + fightName.ToString());
        p1Nameplate.text = fightName.ToString();
    }

    public void CollectFighter2Name(string fightName)
    {
        Debug.Log("player 2 is " + fightName.ToString());
        p2Nameplate.text = fightName.ToString();
    }

    public void CollectNames(int playNum, string name)
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

    public IEnumerator CountdownUI(float time)
    {

        countdownText.text = "Get Ready...";
        countdownText.color = Color.white;

        yield return new WaitForSeconds(time);

        countdownText.text = "FIGGITY FIGHT!";
        countdownText.color = Color.red;

        yield return new WaitForSeconds(1);

        countdownText.text = "";

    }

}
