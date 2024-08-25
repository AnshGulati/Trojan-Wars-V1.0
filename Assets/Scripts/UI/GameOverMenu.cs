using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    AudioManager audioManager;

    private void Awake()
    {
        //audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        audioManager = FindAnyObjectByType<AudioManager>();
    }

    private void Start()
    {
        audioManager.musicSource.Stop();
        audioManager.PlaySFX(audioManager.gameOver);
    }

    private void Update()
    {
        RestartInputKey();
    }
    public void RestartInputKey()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartGame();
        }
    }


    public void RestartGame()
    {
        SceneManager.LoadScene("GamePlay");
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }

    public void PlayButtonSoundOver()
    {
        audioManager.PlaySFX(audioManager.buttonClick);
    }
}
