using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthText : MonoBehaviour
{
    public Image ten;
    public Sprite[] spriteArray;
    private GameBehavior _gameManager;
    // Start is called before the first frame update
    void Start()
    {
        _gameManager = GameObject.Find("Game Manager").GetComponent<GameBehavior>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ImageChange()
    {
        ten.sprite = spriteArray[_gameManager.HP - 1];
    }
}
