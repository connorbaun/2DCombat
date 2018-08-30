using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaminaManager : MonoBehaviour {
    public GameObject player1;
    public GameObject player2;

    public float p1Stamina = 3;
    public float p2Stamina = 3;

    public float maxStamina = 3;
    public float staminaRefillTime = 3f;
    public float p1StaminaTimer = 0;
    public float p2StaminaTimer = 0;

	// Use this for initialization
	void Start ()
    {
        p1Stamina = maxStamina;
        p2Stamina = maxStamina;
	}

    public void Update()
    {
        if (p1Stamina < maxStamina)
        {
            if (p1StaminaTimer < staminaRefillTime)
            {
                p1Stamina += Time.deltaTime;
                Debug.Log(p1StaminaTimer);
            }
            else if (p1StaminaTimer >= staminaRefillTime)
            {
                p1StaminaTimer = 0;
                p1Stamina += 1;
            }
        }

        if (p2Stamina < maxStamina)
        {
            if (p2StaminaTimer < staminaRefillTime)
            {
                p2Stamina += Time.deltaTime;
                Debug.Log(p2StaminaTimer);
            } else if (p2StaminaTimer >= staminaRefillTime)
            {
                p2StaminaTimer = 0;
                p2Stamina += 1;
            }
        }
    }

    // Update is called once per frame
    public void LoseStamina(int playerNum)
    {
        if (playerNum == 1)
        {
            p1Stamina -= 1;
        }

        if (playerNum == 2)
        {
            p2Stamina -= 1;
        }
    }
}
