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

    public void CollectFighterNames(int playerNum, string fighterName)
    {
        if (playerNum == 1)
        {
            p1FighterName = fighterName;
        }

        if (playerNum == 2)
        {
            p2FighterName = fighterName;
        }

        CreateNamePlates();
    }

    public void CreateNamePlates()
    {
        p1Nameplate.text = p1FighterName.ToString();
        //p2Nameplate.text = p2FighterName.ToString();
    }
}
