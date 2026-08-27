using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed=5f;
    
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
}