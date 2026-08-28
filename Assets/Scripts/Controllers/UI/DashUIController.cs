using UnityEngine;
using UnityEngine.UI;

public class DashUIController : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] private Image dashIcon;
    
    [Header("Colors")]
    [SerializeField] private Color readyColor = Color.white;
    [SerializeField] private Color cooldownColor = new Color(0.3f, 0.3f, 0.3f, 0.5f);

    private void OnEnable()
    {
        PlayerController.OnDashStateChanged += UpdateDashIcon;
    }

    private void OnDisable()
    {
        PlayerController.OnDashStateChanged -= UpdateDashIcon;
    }

    private void UpdateDashIcon(bool isReady)
    {
        if (dashIcon != null)
            dashIcon.color = isReady ? readyColor : cooldownColor;
    }
}