using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryScreen : MonoBehaviour
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
        audioManager.PlaySFX(audioManager.starVictory);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("StartScreen");
    }

    public void QuitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }

    public void PlayButtonSoundVictory()
    {
        audioManager.PlaySFX(audioManager.buttonClick);
    }
}
