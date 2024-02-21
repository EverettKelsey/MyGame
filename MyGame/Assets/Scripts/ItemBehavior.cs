using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBehavior : MonoBehaviour
{
    public GameBehavior gameManager;
    private ItemsText itemstext;
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
            gameManager.HP += (10 - gameManager.HP);
            gameManager.HealthDialog(timeShown);
            Destroy(this.transform.parent.gameObject);
        }
    }
}