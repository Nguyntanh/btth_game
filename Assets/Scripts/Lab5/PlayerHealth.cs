using UnityEngine;
using System; // Cần thư viện này để dùng Action

public class PlayerHealth : MonoBehaviour
{
    // Khai báo sự kiện: Action<int> nghĩa là truyền đi 1 số nguyên (lượng máu hiện tại)
    public static event Action<int> OnHealthChanged;
    public static event Action OnPlayerDeath;

    [SerializeField] private int maxHealth = 100;
    private int currentHealth;

    void Awake()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        // Nhấn phím H để tự trừ 10 máu (phục vụ demo)
        if (Input.GetKeyDown(KeyCode.H))
        {
            TakeDamage(10);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        Debug.Log($"Máu hiện tại: {currentHealth}");

        // Phát sự kiện cho tất cả Observer đang nghe
        OnHealthChanged?.Invoke(currentHealth);

        if (currentHealth <= 0)
        {
            OnPlayerDeath?.Invoke();
        }
    }
}