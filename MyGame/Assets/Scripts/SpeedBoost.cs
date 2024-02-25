using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoost : MonoBehaviour
{
    public GameBehavior gameManager;
    public float BoostMultiplier = 1.0f;
    public float BoostSeconds = 5.0f;
    private float timeShown = 5.0f;

    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameBehavior>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Destroy(this.transform.parent.gameObject);
            Debug.Log("You now have a speed boost!");

            PlayerBehavior Player = collision.gameObject.GetComponent<PlayerBehavior>();
            Player.BoostSpeed(BoostMultiplier, BoostSeconds);
            gameManager.Speed(timeShown);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
