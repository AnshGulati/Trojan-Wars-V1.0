using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoClipUI : MonoBehaviour
{
    //public ShootingGunsTraits shooting;
    public Shooting shooting;
    public Text reloadText;

    private void Awake()
    {
        reloadText = GetComponent<Text>();
    }

    private void Start()
    {
        UpdateAmmoText();
    }

    private void Update()
    {
        UpdateAmmoText();
    }

    public void UpdateAmmoText()
    {
        reloadText.text = $"{shooting.currentClip} / {shooting.maxClipSize} | {shooting.currentAmmo} / {shooting.maxAmmoSize}";
    }
}
