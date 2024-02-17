using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    public Text healthText;
    private GameBehavior _gameManager;

    void Start()
    {
        _gameManager = GameObject.Find("Game Manager").GetComponent<GameBehavior>();
    }
    void Update()
    {
        healthText.text = "Health : " + _gameManager.HP;

    }
}
