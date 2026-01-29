using UnityEngine;

public class GlobalAudioController : MonoBehaviour
{
    private bool _isMuted = false;
    private bool _isPaused = false;

    void Update()
    {
        // Phím M: Mute/Unmute (Chỉnh volume tổng)
        if (Input.GetKeyDown(KeyCode.M))
        {
            ToggleMute();
        }

        // Phím P: Pause/Resume (Dừng/Phát tiếp tục toàn bộ)
        if (Input.GetKeyDown(KeyCode.P))
        {
            TogglePause();
        }
    }

    private void ToggleMute()
    {
        _isMuted = !_isMuted;
        
        // Cách 1: Chỉnh volume về 0 hoặc 1
        AudioListener.volume = _isMuted ? 0f : 1f;

        Debug.Log(_isMuted ? "Đã tắt tiếng toàn bộ (Muted)" : "Đã bật tiếng toàn bộ (Unmuted)");
    }

    private void TogglePause()
    {
        _isPaused = !_isPaused;

        // AudioListener.pause dừng tất cả AudioSource đang phát 
        // nhưng không làm thay đổi giá trị volume.
        AudioListener.pause = _isPaused;

        Debug.Log(_isPaused ? "Đã tạm dừng âm thanh (Paused)" : "Đã tiếp tục âm thanh (Resumed)");
    }
}