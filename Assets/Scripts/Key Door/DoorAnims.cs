using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAnims : MonoBehaviour
{
    private Animator doorAnimator;

    AudioManager audioManager;

    private void Awake()
    {
        doorAnimator = GetComponent<Animator>();
        //audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        audioManager = FindAnyObjectByType<AudioManager>();
    }

    public void OpenDoor()
    {
        audioManager.PlaySFX(audioManager.doorOpen);
        doorAnimator.SetBool("Open", true);
    }

    public void CloseDoor()
    {
        doorAnimator.SetBool("Open", false);
    }

    public void PlayOpenFailAnim()
    {
        audioManager.PlaySFX(audioManager.doorReject);
        doorAnimator.SetTrigger("OpenFail");
    }

    public enum ColorName { Red, Green, Blue }

    /*public void SetColor(ColorName colorName)
    {
        Material doorMaterial = GameAssets.i.m_DoorRed;
        Material doorKeyHoleMaterial = GameAssets.i.m_DoorKeyHoleRed;

        switch (colorName)
        {
            default:
            case ColorName.Red:
                doorMaterial = GameAssets.i.m_DoorRed;
                doorKeyHoleMaterial = GameAssets.i.m_DoorKeyHoleRed;
                break;
            case ColorName.Green:
                doorMaterial = GameAssets.i.m_DoorGreen;
                doorKeyHoleMaterial = GameAssets.i.m_DoorKeyHoleGreen;
                break;
            case ColorName.Blue:
                doorMaterial = GameAssets.i.m_DoorBlue;
                doorKeyHoleMaterial = GameAssets.i.m_DoorKeyHoleBlue;
                break;
        }

        if (transform.Find("DoorLeft") != null) transform.Find("DoorLeft").GetComponent<SpriteRenderer>().material = doorMaterial;
        if (transform.Find("DoorRight") != null) transform.Find("DoorRight").GetComponent<SpriteRenderer>().material = doorMaterial;

        if (transform.Find("DoorKeyHoleLeft") != null) transform.Find("DoorKeyHoleLeft").GetComponent<SpriteRenderer>().material = doorKeyHoleMaterial;
        if (transform.Find("DoorKeyHoleRight") != null) transform.Find("DoorKeyHoleRight").GetComponent<SpriteRenderer>().material = doorKeyHoleMaterial;
    }*/

}
