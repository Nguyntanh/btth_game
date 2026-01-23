using UnityEngine;
using TMPro;

public class HealthUI : MonoBehaviour
{
    public TextMeshProUGUI healthText;

    private void OnEnable()
    {
        // Đăng ký nghe sự kiện
        PlayerHealth.OnHealthChanged += UpdateHealthDisplay;
    }

    private void OnDisable()
    {
        // Hủy đăng ký khi object bị ẩn (tránh lỗi bộ nhớ)
        PlayerHealth.OnHealthChanged -= UpdateHealthDisplay;
    }

    void UpdateHealthDisplay(int currentHealth)
    {
        healthText.text = "HP: " + currentHealth;
    }
}