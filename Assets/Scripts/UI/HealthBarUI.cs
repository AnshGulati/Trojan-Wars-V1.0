using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    [SerializeField] private UnityEngine.UI.Image healthBarForegroundImage;

    public void UpdateHealth(HealthController healthController)
    {
        healthBarForegroundImage.fillAmount = healthController.remainingHealthPercentage;
    }
}
