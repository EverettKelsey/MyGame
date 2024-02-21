using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemsText : MonoBehaviour
{
/*    public Image zero;
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
        zero.sprite = spriteArray[_gameManager.Items - 1];
    }
    */
    public Text itemText;
    private GameBehavior _gameManager;
    // Start is called before the first frame update
    void Start()
    {
        _gameManager = GameObject.Find("Game Manager").GetComponent<GameBehavior>();
    }

    // Update is called once per frame
    void Update()
    {
        itemText.text = "" + _gameManager.Items;
    }
}
