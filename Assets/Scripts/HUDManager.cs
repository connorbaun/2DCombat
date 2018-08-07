using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour {
    public Text p1Nameplate;
    public Text p2Nameplate;



    private string p1FighterName;
    private string p2FighterName;

    

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
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

}
