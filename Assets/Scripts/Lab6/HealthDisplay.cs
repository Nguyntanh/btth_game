using UnityEngine;
using TMPro;

public class HealthDisplay : MonoBehaviour
{
    public TextMeshProUGUI healthText;

    // Lưu ý: Hàm này PHẢI là public để UnityEvent nhìn thấy
    public void UpdateHealthUI(int healthValue)
    {
        healthText.text = "HP: " + healthValue;
    }
}