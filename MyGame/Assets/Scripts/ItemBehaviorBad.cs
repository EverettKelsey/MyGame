using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBehaviorBad : MonoBehaviour
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
            Debug.Log("The gods hate you. You died!");
            gameManager.Items += 1;
            gameManager.HP -= 7;
            gameManager.showBadHPtext = true;
            Destroy(this.transform.parent.gameObject);
        }
    }

    void Update()
    {
        if (gameManager.showBadHPtext)
        {
            timeShown -= Time.deltaTime;
            if (timeShown < 0.0f)
            {
                gameManager.showBadHPtext = false;
            }
        }
    }
}

