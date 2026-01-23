using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverPanel;

    private void OnEnable()
    {
        PlayerHealth.OnPlayerDeath += HandleGameOver;
    }

    private void OnDisable()
    {
        PlayerHealth.OnPlayerDeath -= HandleGameOver;
    }

    void HandleGameOver()
    {
        Debug.Log("Game Over!");
        gameOverPanel.SetActive(true);
        Time.timeScale = 0; // Dừng game
    }
}