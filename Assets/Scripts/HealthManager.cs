using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour {
    public int p1HP = 100;
    public int p2HP = 100;
    public Slider p1Health;
    public Slider p2Health;


    // Use this for initialization
    void Start ()
    {

	}
	
	// Update is called once per frame
	void Update ()
    {
        p1Health.value = p1HP;
        p2Health.value = p2HP;
	}

    public void DealDamage(int playerNum, int damDealt)
    {
        if (playerNum == 1)
        {
            p1HP -= damDealt;
        }

        if (playerNum == 2)
        {
            p2HP -= damDealt;
        }
    }

}
