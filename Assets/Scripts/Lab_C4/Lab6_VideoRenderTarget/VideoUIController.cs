using UnityEngine;
using UnityEngine.Video;

public class VideoUIController : MonoBehaviour
{
    private VideoPlayer _videoPlayer;

    void Awake()
    {
        _videoPlayer = GetComponent<VideoPlayer>();
        // Đảm bảo video không tự chạy
        _videoPlayer.playOnAwake = false; 
    }

    void Update()
    {
        // Nhấn V để bắt đầu phát
        if (Input.GetKeyDown(KeyCode.V))
        {
            if (!_videoPlayer.isPlaying)
            {
                _videoPlayer.Play();
                Debug.Log("Video đang phát trên UI!");
            }
        }
    }
}