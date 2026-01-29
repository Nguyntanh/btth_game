using UnityEngine;
using UnityEngine.Video; // Thư viện bắt buộc để làm việc với Video

public class VideoController : MonoBehaviour
{
    private VideoPlayer _videoPlayer;

    void Awake()
    {
        // Cache component
        _videoPlayer = GetComponent<VideoPlayer>();
    }

    void Update()
    {
        // Nhấn V để Play
        if (Input.GetKeyDown(KeyCode.V))
        {
            if (!_videoPlayer.isPlaying)
            {
                _videoPlayer.Play();
                Debug.Log("Đang phát Video...");
            }
        }
    }
}