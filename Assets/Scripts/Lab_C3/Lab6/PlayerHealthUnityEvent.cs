using UnityEngine;
using UnityEngine.Events; // Bắt buộc phải có thư viện này để dùng UnityEvent

public class PlayerHealthUnityEvent : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    [Header("Events Configuration")]
    // Sự kiện có truyền tham số (số máu còn lại)
    public UnityEvent<int> onHealthChanged; 
    
    // Sự kiện không truyền tham số (chỉ báo là chết)
    public UnityEvent onDeath;

    void Awake()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        // Sử dụng phím Space để test trừ máu
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(20);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        // Phát sự kiện (Invoke)
        onHealthChanged.Invoke(currentHealth);

        if (currentHealth <= 0)
        {
            onDeath.Invoke();
        }
    }
}