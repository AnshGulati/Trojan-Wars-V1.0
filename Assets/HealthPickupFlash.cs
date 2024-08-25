using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickupFlash : MonoBehaviour
{
    [SerializeField] private float flashDuration;
    [SerializeField] private Color flashColor;
    [SerializeField] private int numberOfFlashes;

    private SpriteRenderer spriteRenderer;

  

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            spriteRenderer = collision.gameObject.GetComponentInChildren<SpriteRenderer>();

            Debug.Log("Triggered");
            FlashGreen();    
        }
    }

    private void FlashGreen()
    {
        Color startColor = spriteRenderer.color;
        float elapsedFlashTime = 0;
        float elapsedFlashPercentage = 0;

        while (elapsedFlashTime < flashDuration)
        {
            Debug.Log("Pika");
            elapsedFlashTime += Time.deltaTime;
            elapsedFlashPercentage = elapsedFlashTime / flashDuration;

            if (elapsedFlashPercentage > 1)
            {
                elapsedFlashPercentage = 1;
            }

            float pingPongPercentage = Mathf.PingPong(elapsedFlashPercentage * 2 * numberOfFlashes, 1);
            spriteRenderer.color = Color.Lerp(startColor, flashColor, pingPongPercentage);
        }
    }
}
