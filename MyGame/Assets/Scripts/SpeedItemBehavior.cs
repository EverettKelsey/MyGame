using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedItemBehavior : MonoBehaviour
{
    public GameBehavior gameManager;
    public float timeShown = 1.0f;

    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameBehavior>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Debug.Log("The gods have had mercy on you! You've gained health.");
            gameManager.Items += 1;
            gameManager.showSpeedtext = true;
            Destroy(this.transform.parent.gameObject);
        }
    }

    void Update()
    {
        if (gameManager.showSpeedtext)
        {
            timeShown -= Time.deltaTime;
            if (timeShown < 0.0f)
            {
                gameManager.showSpeedtext = false;
            }
        }
    }
}