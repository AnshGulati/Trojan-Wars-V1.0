using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("------ Audio Source ------")]
    public AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("------ Audio Clip ------")]
    public AudioClip background;
    public AudioClip buttonClick;
    public AudioClip playerFootsteps;
    public AudioClip heal;
    public AudioClip keyPickup;
    public AudioClip starVictory;
    public AudioClip enemyDeath;
    public AudioClip gunCollect;
    public AudioClip ammoCollect;
    public AudioClip changeGun;
    public AudioClip playerDash;
    public AudioClip playerShoot;
    public AudioClip gunReload;
    public AudioClip doorOpen;
    public AudioClip doorReject;
    public AudioClip turretExplode;
    public AudioClip gameOver;
    public AudioClip turretShoot;
    public AudioClip emptyClipGun;
    public AudioClip playerDamage;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip audioClip)
    {
        SFXSource.PlayOneShot(audioClip);
    }
}
