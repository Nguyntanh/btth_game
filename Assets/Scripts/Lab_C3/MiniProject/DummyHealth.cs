using UnityEngine;
using UnityEngine.Events;

public class DummyHealth : MonoBehaviour
{
    public int health = 100;
    public UnityEvent<int> onHealthChanged;
    public UnityEvent onDeath;

    void Update()
    {
        // PHẢI CÓ ĐOẠN NÀY ĐỂ BẮT PHÍM SPACE
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Phím Space đã được nhấn!"); // Log để kiểm tra phím
            TakeDamage(10);
        }
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        health = Mathf.Clamp(health, 0, 100);
        
        Debug.Log("Đang gọi Event! Máu hiện tại: " + health);
        
        // Phát sự kiện đi
        onHealthChanged.Invoke(health);

        if (health <= 0)
        {
            onDeath.Invoke();
        }
    }
}