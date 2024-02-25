using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameBehavior : MonoBehaviour
{
    public int maxItems = 4;
    public bool ShowWinScreen = false;
    private int _itemsCollected = 0;
    public Text crystalText;
    public Text hpText;
    public Text speedText;
    public float timeShown = 5.0f;

    void Start()
    {
        hpText.enabled = false;
        speedText.enabled = false;
    }
    public int Items
    {
        get { return _itemsCollected; }
        set
        {
                _itemsCollected = value;
                Debug.LogFormat("Items: {0}", _itemsCollected);
                if (_itemsCollected >= maxItems)
                {
                    SceneManager.LoadScene("YouWin");
                }
                else
                {
                    CrystalDialog(timeShown);
                }
        }
    }

    private int _playerHP = 10;
    public int HP
    {
        get { return _playerHP; }
        set
        {
                _playerHP = value;
                if(_playerHP <= 0)
                {
                    SceneManager.LoadScene("GameOver");
                }
        }
    }

    public void HealthDialog(float seconds)
    {
        if (speedText.enabled == true)
            speedText.enabled = false;
        hpText.enabled = true;
        hpText.text = "You have gained " + (10 - HP) + " health!";
        Invoke("EndDialog", seconds);
    }

    public void Speed(float seconds)
    {
        if(hpText.enabled == true)
            hpText.enabled = false;
        speedText.enabled = true;
        speedText.text = "You feel adrenaline course through your veins!";
        Invoke("EndDialog", seconds);
    }

    public void LostHealthDialog(float seconds)
    {
        if (speedText.enabled == true)
            speedText.enabled = false;
        hpText.enabled = true;
        hpText.text = "You have lost 3 health!";
        Invoke("EndDialog", seconds);
    }

    public void CrystalDialog(float seconds)
    {
        if (speedText.enabled == true)
            speedText.enabled = false;
        if (hpText.enabled == true)
            hpText.enabled = false;
        crystalText.text = "Crystal found, only " + (maxItems - _itemsCollected) + " more to go!";
        Invoke("EndDialog", seconds);
    }

    private void EndDialog()
    {
        hpText.enabled = false;
        speedText.enabled = false;
        crystalText.enabled = false;
    }

}