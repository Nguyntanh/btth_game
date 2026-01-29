using UnityEngine;
using UnityEngine.Video;
using TMPro; // QUAN TRỌNG: Thêm thư viện này để dùng TextMeshPro

public class VideoEventHandler : MonoBehaviour
{
    private VideoPlayer _videoPlayer;
    
    // Thay đổi kiểu dữ liệu từ Text thành TextMeshProUGUI
    public TextMeshProUGUI statusText; 

    void Awake()
    {
        _videoPlayer = GetComponent<VideoPlayer>();
        _videoPlayer.prepareCompleted += OnVideoPrepared;
        _videoPlayer.loopPointReached += OnVideoFinished;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            if(statusText != null) statusText.text = "Đang chuẩn bị video...";
            _videoPlayer.Prepare();
        }
    }

    void OnVideoPrepared(VideoPlayer vp)
    {
        if(statusText != null) statusText.text = "Video sẵn sàng! Đang phát...";
        vp.Play();
    }

    void OnVideoFinished(VideoPlayer vp)
    {
        if(statusText != null) statusText.text = "Video đã kết thúc!";
        Debug.Log("Video kết thúc!");
    }

    void OnDestroy()
    {
        _videoPlayer.prepareCompleted -= OnVideoPrepared;
        _videoPlayer.loopPointReached -= OnVideoFinished;
    }
}