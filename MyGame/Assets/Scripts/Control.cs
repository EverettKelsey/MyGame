using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Control : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;

    [SerializeField] AudioClip clip;
    public void OnMouseUp()
    {
        StartCoroutine(DelayedLoad());
    }

    IEnumerator DelayedLoad()
    {
        GetComponent<AudioSource>().PlayOneShot(clip);
        yield return new WaitForSeconds(clip.length);
        if (gameObject.name == "Rules")
        {
            Rules();
        }
        if (gameObject.name == "Start")
        {
            NextScene();
        }
        if (gameObject.name == "Back")
        {
            Home();
        }
        if (gameObject.name == "ResumeButton")
        {
            Resume();
        }
        if (gameObject.name == "MainMenu")
        {
            Home();
        }
        if (gameObject.name == "Button")
        {
            NextScene();
        }
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void NextScene()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void Rules()
    {
        SceneManager.LoadScene("Rules");
    }

    public void Home()
    {
        SceneManager.LoadScene("Start");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
