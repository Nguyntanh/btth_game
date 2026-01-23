using UnityEngine;
using TMPro; // Thư viện để điều khiển TextMeshPro

public class HealthDisplay2 : MonoBehaviour
{
    public TextMeshProUGUI healthText; // Kéo Text HP vào đây

    // Hàm này nhận số máu từ PlayerHealth gửi sang
    public void UpdateHealthUI(int currentHealth)
    {
        if (healthText != null)
        {
            healthText.text = "HP: " + currentHealth.ToString();
        }
    }
}