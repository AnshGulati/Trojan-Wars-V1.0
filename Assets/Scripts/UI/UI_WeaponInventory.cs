using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_WeaponInventory : MonoBehaviour
{
    [SerializeField] private WeaponInventoryNew weaponInventory;

    private Transform weaponContainer;
    private Transform weaponTemplate;

    // Sprites for the Gun
    [SerializeField] private Sprite shotgunSprite;
    [SerializeField] private Sprite rifleSprite;
    [SerializeField] private Sprite missileLauncherSprite;

    private void Awake()
    {
        weaponContainer = transform.Find("weaponContainer");
        weaponTemplate = weaponContainer.Find("weaponTemplate");
        weaponTemplate.gameObject.SetActive(false);
    }

    private void Start()
    {
        weaponInventory.OnWeaponChanged += WeaponInventoryNew_OnWeaponChanged;
    }

    private void WeaponInventoryNew_OnWeaponChanged(object sender, System.EventArgs e)
    {
        UpdateVisual();
    }

    private void UpdateVisual()
    {
        // Clean up old weapons
        foreach (Transform child in weaponContainer)
        {
            if (child == weaponTemplate) continue;
            Destroy(child.gameObject);
        }

        // Instantiate current weapon list
        List<WeaponTypeNew.WeaponType> weaponList = weaponInventory.GetWeaponList();
        weaponContainer.GetComponent<RectTransform>().anchoredPosition = new Vector2(-(weaponList.Count - 1) * 0 / 2f, 94);
        for (int i = 0; i < weaponList.Count; i++)
        {
            WeaponTypeNew.WeaponType weaponType = weaponList[i];
            Transform weaponTransform = Instantiate(weaponTemplate, weaponContainer);
            weaponTransform.gameObject.SetActive(true);
            weaponTransform.GetComponent<RectTransform>().anchoredPosition = new Vector2(140 * i, 0);
            Image weaponImage = weaponTransform.Find("Image").GetComponent<Image>();

            // Change the sprite based on the weapon type

            switch (weaponType)
            {
                default:
                case WeaponTypeNew.WeaponType.Shotgun: weaponImage.sprite = shotgunSprite; break;
                case WeaponTypeNew.WeaponType.Rifle: weaponImage.sprite = rifleSprite; break;
                case WeaponTypeNew.WeaponType.MissileLauncher: weaponImage.sprite = missileLauncherSprite; break;
            }
        }
    }
}