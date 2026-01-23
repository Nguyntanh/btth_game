using UnityEngine;

public class TurretController : MonoBehaviour
{
    public Transform target;        // Kéo Sphere vào đây
    public float rotationSpeed = 5f; // Tốc độ xoay mượt
    public bool useSmoothRotation;  // Toggle để chuyển đổi 2 chế độ

    void Update()
    {
        if (target == null) return;

        // 1. Tính toán hướng vector từ Trụ -> Mục tiêu
        Vector3 direction = target.position - transform.position;
        
        // Giữ cho trụ súng chỉ xoay ngang (khóa trục Y)
        direction.y = 0;

        // 2. Tạo Quaternion đích từ hướng đã tính
        Quaternion targetRotation = Quaternion.LookRotation(direction);

        if (useSmoothRotation)
        {
            // CHẾ ĐỘ 2: XOAY MƯỢT (RotateTowards hoặc Slerp)
            // Slerp giúp nội suy góc xoay theo thời gian
            transform.rotation = Quaternion.Slerp(
                transform.rotation, 
                targetRotation, 
                rotationSpeed * Time.deltaTime
            );
        }
        else
        {
            // CHẾ ĐỘ 1: XOAY TRỰC TIẾP (Tương đương LookAt)
            // Gán thẳng góc xoay đích vào object
            transform.rotation = targetRotation;
        }
    }
}