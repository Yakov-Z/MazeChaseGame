using UnityEngine;
using System;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed=5f;
    public static event Action OnPlayerCaught;
    public static event Action OnExitReached;
    public static event Action<bool> OnDashStateChanged;

    [Header("Dash Settings")]
    [SerializeField] private float dashSpeedMultiplier = 3f;
    [SerializeField] private float dashDuration = 0.2f; // How long the I-frames last
    [SerializeField] private float dashCooldown = 1.5f; // Time before next dash
    private Rigidbody2D rb;
    private bool isDashing = false;
    private bool canDash = true;
    private Vector2 input;
    private int playerLayer;
    private int dashingLayer;

    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        playerLayer = LayerMask.NameToLayer("Player");
        dashingLayer = LayerMask.NameToLayer("Dashing");
    }
    public void Update()
    {
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");
        input = input.normalized;

        if (Input.GetKeyDown(KeyCode.Space) && canDash && input.magnitude > 0)
            StartCoroutine(DashRoutine());

        if (input != Vector2.zero)
        {
            transform.up = -input; 
        }
    }
    public void FixedUpdate()
    {
        rb.MovePosition(rb.position + input * speed * Time.fixedDeltaTime);
    }

    private IEnumerator DashRoutine()
    {
        // Lock the dash ability and set the dashing state
        canDash = false;
        isDashing = true;

        OnDashStateChanged?.Invoke(false);

        gameObject.layer = dashingLayer;

        // save the original normal speed for restoration
        float originalSpeed = speed;

        // Apply the speed boost
        speed *= dashSpeedMultiplier;

        // Wait for the duration of the dash (I-Frames and boost are active)
        yield return new WaitForSeconds(dashDuration);

        // Revert back to normal speed and end I-frames
        isDashing = false;
        speed = originalSpeed;
        gameObject.layer = playerLayer;

        // Wait for cooldown before allowing another dash
        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
        OnDashStateChanged?.Invoke(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<EnemyController>() != null)
        {
            if (!isDashing)
                OnPlayerCaught?.Invoke();
            else
                Debug.Log("Dodged the enemy with a dash!");
        }
        else if (collision.GetComponent<ExitPoint>() != null)
            OnExitReached?.Invoke();
    }
}