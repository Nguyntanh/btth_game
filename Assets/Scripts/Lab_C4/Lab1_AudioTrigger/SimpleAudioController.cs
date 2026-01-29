using UnityEngine;

public class SimpleAudioController : MonoBehaviour
{
    // Biến lưu trữ component để không phải gọi GetComponent nhiều lần
    private AudioSource _audioSource;

    void Awake()
    {
        // Lấy component AudioSource ngay khi object được khởi tạo
        _audioSource = GetComponent<AudioSource>();

        // Kiểm tra lỗi để tránh NullReferenceException
        if (_audioSource == null)
        {
            Debug.LogError("Object này thiếu component AudioSource rồi bạn ơi!");
        }
    }

    void Update()
    {
        // Nhấn Space để phát âm thanh
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlaySound();
        }

        // Nhấn S để dừng âm thanh
        if (Input.GetKeyDown(KeyCode.S))
        {
            StopSound();
        }
    }

    private void PlaySound()
    {
        if (_audioSource.isPlaying) return; // Nếu đang phát thì không phát đè lên
        _audioSource.Play();
        Debug.Log("Đang phát âm thanh...");
    }

    private void StopSound()
    {
        if (_audioSource.isPlaying)
        {
            _audioSource.Stop();
            Debug.Log("Đã dừng âm thanh.");
        }
    }
}