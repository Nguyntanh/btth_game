using UnityEngine;

public class PlayerMovement2 : MonoBehaviour
{
    [Header("Cấu hình di chuyển")]
    [SerializeField] private float speed = 5f;
    
    private Vector3 moveDirection; // Lưu hướng để vẽ Gizmos

    void Update()
    {
        // 1. Lấy Input từ bàn phím (W,S,A,D)
        // GetAxisRaw giúp nhân vật dừng lại ngay lập tức khi thả phím (không có độ trễ)
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        // 2. Tạo Vector hướng
        moveDirection = new Vector3(horizontal, 0, vertical);

        // 3. CHUẨN HÓA (Normalization) - PHẦN QUAN TRỌNG NHẤT
        // Nếu không có dòng này, khi nhấn W+D (đi chéo), nhân vật sẽ chạy nhanh gấp 1.41 lần
        if (moveDirection.magnitude > 1)
        {
            moveDirection = moveDirection.normalized;
        }

        // 4. Thực hiện di chuyển
        // Time.deltaTime đảm bảo tốc độ ổn định trên mọi loại máy tính (FPS độc lập)
        transform.Translate(moveDirection * speed * Time.deltaTime, Space.World);
    }

    // 5. Vẽ Gizmos để quan sát vector hướng trong cửa sổ Scene
    private void OnDrawGizmos()
    {
        // Chỉ vẽ khi đang di chuyển
        if (moveDirection != Vector3.zero)
        {
            Gizmos.color = Color.red;
            // Vẽ tia từ tâm nhân vật ra hướng đang đi
            Gizmos.DrawRay(transform.position, moveDirection * 2f);
            
            // Vẽ một khối cầu nhỏ tại đầu tia để dễ nhìn
            Gizmos.DrawSphere(transform.position + moveDirection * 2f, 0.1f);
        }
    }
}