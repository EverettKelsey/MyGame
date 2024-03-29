using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Control : MonoBehaviour
{
    public GameObject Castle;
    public GameObject rules;
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        rules.SetActive(false);
    }
    public void NextScene()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void Rules()
    {
        Castle.SetActive(false);
        rules.SetActive(true);
    }

    public void Home()
    {
        Castle.SetActive(true);
        rules.SetActive(false);
    }
}
