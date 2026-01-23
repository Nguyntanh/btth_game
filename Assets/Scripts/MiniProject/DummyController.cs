using UnityEngine;
using TMPro;

public class DummyController : MonoBehaviour {
    public float speed = 5f;
    public Transform turret; // Kéo Turret_Head vào đây
    public TextMeshProUGUI angleDisplay;

    void Update() {
        // Di chuyển (Lab 2)
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Vector3 move = new Vector3(h, 0, v).normalized;
        transform.Translate(move * speed * Time.deltaTime, Space.World);

        // Tính góc lệch so với Turret (Lab 4)
        if (turret != null) {
            Vector3 dirToTurret = turret.position - transform.position;
            float angle = Vector3.SignedAngle(transform.forward, dirToTurret, Vector3.up);
            angleDisplay.text = $"Góc với Turret: {angle:F0}°";
        }
    }
}