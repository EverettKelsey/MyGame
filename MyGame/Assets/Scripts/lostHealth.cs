using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lostHealth : MonoBehaviour
{
     public GameBehavior gameManager;
     public float timeShown = 5.0f;

    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameBehavior>();
    }
    
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            gameManager.HP -= 3;
            gameManager.LostHealthDialog(timeShown);
        }
    }
}

