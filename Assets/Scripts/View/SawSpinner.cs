using UnityEngine;

public class SawSpinner : MonoBehaviour
{
    [SerializeField] private float spinSpeed = -360f; 

    private void Update()
    {
        transform.Rotate(0, 0, spinSpeed * Time.deltaTime);
    }
}