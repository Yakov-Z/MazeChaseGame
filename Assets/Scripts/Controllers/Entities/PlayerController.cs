using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed=5f;
    public static event Action OnPlayerCaught;
    public static event Action OnExitReached;
    
    private Rigidbody2D rb;
    
    private Vector2 input;

    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    public void Update()
    {
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");
        input = input.normalized;
        if (input != Vector2.zero)
        {
            transform.up = -input; 
        }
    }
    public void FixedUpdate()
    {
        rb.velocity = input * speed;    
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<EnemyController>() != null)
            OnPlayerCaught?.Invoke();
        else if (collision.GetComponent<ExitPoint>() != null)
            OnExitReached?.Invoke();
    }
}