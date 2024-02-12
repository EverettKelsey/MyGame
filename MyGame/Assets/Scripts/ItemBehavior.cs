using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBehavior : MonoBehaviour
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
            Debug.Log("The gods have had mercy on you! You've gained health.");
            gameManager.Items += 1;
            gameManager.HP += 5;
            gameManager.showHPtext = true;
            Destroy(this.transform.parent.gameObject);
        }
    }

    void Update()
    {
        if (gameManager.showHPtext)
        {
            timeShown -= Time.deltaTime;
            if (timeShown < 0.0f)
            {
                gameManager.showHPtext = false;
            }
        }
    }
}