using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    AudioManager audioManager;

    [SerializeField] private float moveSpeed = 5f; //Player Move Speed

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Camera cam;

    Vector2 movement; //Movement Input
    Vector2 mousePos; //Variable for storing mouse position
    Vector2 lookDir; //Player Look Direction

    private float activeMoveSpeed;

    [SerializeField] private float dashSpeed = 100f; // Speed of Player dash
    [SerializeField] private float dashLength = 0.5f; // Distance of dash
    [SerializeField] private float dashCoolDown = 1f; // Duration of dash in seconds

    private float dashCounter;
    private float dashCoolCounter; //Cool-down time after one dash

    [SerializeField] private TrailRenderer trailRender;

    private void Awake()
    {
        //audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        audioManager = FindAnyObjectByType<AudioManager>();
    }

    private void Start()
    {
        activeMoveSpeed = moveSpeed;
    }

    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal"); //X-axis Movement
        movement.y = Input.GetAxisRaw("Vertical"); //Y-axis Movement

        // Updating Mouse Position
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        // Dash Mechanism

        if (Input.GetKeyDown(KeyCode.Space))
        {
           // audioManager.PlaySFX(audioManager.playerDash);
            StartCoroutine(PlayerDash());
        }

        if (dashCounter > 0)
        {
            dashCounter -= Time.deltaTime;

            if (dashCounter <= 0)
            {
                activeMoveSpeed = moveSpeed;
                dashCoolCounter = dashCoolDown;
            }
        }

        if (dashCoolCounter > 0)
        {
            dashCoolCounter -= Time.deltaTime;
        }
    }

    private void FixedUpdate()
    {
        // Player Movement
        rb.MovePosition(rb.position + movement * activeMoveSpeed * Time.fixedDeltaTime);


        // Player Rotation according to Mouse Movement
        lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }

    public void OnDamageSoundPlay()
    {
        audioManager.PlaySFX(audioManager.playerDamage);
    }

    private IEnumerator PlayerDash()
    {
        // Dash True then Emit the Trail Effect

        if (dashCoolCounter <= 0 && dashCounter <= 0)
        {
            audioManager.PlaySFX(audioManager.playerDash);
            trailRender.emitting = true;
            activeMoveSpeed = dashSpeed;
            dashCounter = dashLength;
            yield return new WaitForSeconds(dashLength);
            trailRender.emitting = false;
        }
    }
}
