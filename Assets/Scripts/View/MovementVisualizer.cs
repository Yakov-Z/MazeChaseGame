using UnityEngine;

public class MovementVisualizer : MonoBehaviour
{
    public float speed = 1f;
    [SerializeField]
    private Vector3 targetPos;
    private float epsilon = 0.001f;
    public void SetTargetPos(Vector3 target)
    {
        targetPos = target;
    }

    public void Start()
    {
        targetPos = transform.position;
    }

    public void Update()
    {
        Vector3 curPos = transform.position;
        Vector3 offset = curPos - targetPos;
        if(offset.sqrMagnitude > epsilon * epsilon)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, targetPos, step);
        }
    }
}