using UnityEngine;
using TMPro;

public class SignedAngleZController : MonoBehaviour
{
    public Transform target;
    public TextMeshProUGUI angleText;
    [SerializeField] private float rotationSpeed = 5f;

    void Update()
    {
        if (target == null) return;

        // 1. Lấy hướng từ Player tới Target (bỏ qua độ cao Y)
        Vector3 directionToTarget = target.position - transform.position;
        directionToTarget.y = 0;

        // 2. TÍNH GÓC SO VỚI TRỤC Z (Vector3.forward làm gốc 0 độ)
        if (directionToTarget != Vector3.zero)
        {
            // Vector3.forward tương ứng với trục Z (0, 0, 1)
            float angle = Vector3.SignedAngle(Vector3.forward, directionToTarget, Vector3.up);
            
            if (angleText != null)
            {
                angleText.text = $"Góc (Trục Z làm gốc): {angle:F1}°";
            }
        }

        // 3. XOAY PLAYER NHÌN THEO TARGET
        if (directionToTarget.sqrMagnitude > 0.01f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(directionToTarget);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }

        // --- DEBUG GIZMOS (Quan sát trong Scene) ---
        // Đường màu Xanh Dương: Trục Z chuẩn (Góc 0 độ)
        Debug.DrawRay(transform.position, Vector3.forward * 5, Color.blue);
        // Đường màu Xanh Lá: Hướng tới Target hiện tại
        Debug.DrawRay(transform.position, directionToTarget.normalized * 5, Color.green);
    }
}