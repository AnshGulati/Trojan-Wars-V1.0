using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    AudioManager audioManager;

    public static bool GameIsPaused = false;

    public static bool ControlScreenIsOff = true;

    public GameObject pauseMenuUI;

    private void Awake()
    {
        //audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        audioManager = FindAnyObjectByType<AudioManager>();
    }

    private void Update()
    {
        InputKeysForMenu();
    }

    public void InputKeysForMenu()
    {
        if (ControlScreenIsOff && Input.GetKeyDown(KeyCode.Tab))
        {
            if (GameIsPaused)
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
        ControlScreenIsOff = true;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        ControlScreenIsOff = false;
    }

    public void LoadControls()
    {
        ControlScreenIsOff = false;
        Debug.Log("Controls Loaded");
        /*Time.timeScale = 0f;*/
        /*if (Input.GetKeyDown(KeyCode.Tab))
        {
            return;
        }*/
        //SceneManager.LoadScene("Controls");
    }

    public void ControlScreenBool()
    {
        ControlScreenIsOff = true;
    }

    public void LoadMenu()
    {
        ControlScreenIsOff = true;
        GameIsPaused = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene("StartScreen");
    }

    public void PlayButtonSound()
    {
        audioManager.PlaySFX(audioManager.buttonClick);
    }
}
