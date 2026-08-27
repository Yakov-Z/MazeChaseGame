using UnityEngine;

public class MovementVisualizer : MonoBehaviour
{
    public float speed = 1f;
    [SerializeField]
    private Vector3 targetPos;
    private float epsilon = 0.001f;
    private Rigidbody2D rb;
    public void SetTargetPos(Vector3 target)
    {
        targetPos = target;
    }

    public void Start()
    {
        targetPos = transform.position;
        rb = GetComponent<Rigidbody2D>();
    }

    public void FixedUpdate()
    {
        Vector3 currentPos = transform.position;
        Vector3 offset = currentPos - targetPos;

        if(offset.sqrMagnitude > epsilon * epsilon)
        {
            float step = speed * Time.fixedDeltaTime;
            Vector3 newPos = Vector3.MoveTowards(currentPos, targetPos, step);
            
            rb.MovePosition(newPos);
        }
    }
}