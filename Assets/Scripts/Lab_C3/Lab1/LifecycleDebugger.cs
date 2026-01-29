using UnityEngine;

public class LifecycleDebugger : MonoBehaviour
{
    [Header("Settings")]
    public bool showUpdates = false; // Dùng để tắt bớt log cho đỡ rối

    // --- NHÓM KHỞI TẠO ---
    void Awake() 
    {
        // Chạy ngay khi object được load, kể cả khi script đang bị Uncheck
        Debug.Log("<color=cyan>[Awake]</color> " + gameObject.name + " đã được nạp vào bộ nhớ.");
    }

    void OnEnable() 
    {
        // Chạy mỗi khi bạn tích chọn (Enable) script hoặc object
        Debug.Log("<color=green>[OnEnable]</color> Script đã được kích hoạt.");
    }

    void Start() 
    {
        // Chạy 1 lần duy nhất trước khung hình đầu tiên, sau Awake và OnEnable
        Debug.Log("<color=blue>[Start]</color> Trận đấu bắt đầu!");
    }

    // --- NHÓM VÒNG LẶP ---
    void FixedUpdate() 
    {
        // Chạy cố định (thường 50 lần/giây), dùng cho Vật lý (Rigidbody)
        if(showUpdates) Debug.Log("FixedUpdate: Tính toán vật lý...");
    }

    void Update() 
    {
        // Chạy mỗi khung hình (tùy FPS máy), dùng cho Input và di chuyển thường
        if(showUpdates) Debug.Log("Update: Đang xử lý logic game...");
    }

    void LateUpdate() 
    {
        // Chạy sau Update, thường dùng để Camera đi theo nhân vật
        if(showUpdates) Debug.Log("LateUpdate: Cập nhật vị trí Camera...");
    }

    // --- NHÓM KẾT THÚC ---
    void OnDisable() 
    {
        // Chạy khi bạn bỏ tích (Disable) script hoặc object
        Debug.Log("<color=orange>[OnDisable]</color> Script đã tạm dừng.");
    }

    void OnDestroy() 
    {
        // Chạy khi object bị xóa hoàn toàn khỏi Scene
        Debug.Log("<color=red>[OnDestroy]</color> Object đã bị hủy.");
    }
}