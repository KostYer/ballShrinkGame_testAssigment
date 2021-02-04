
using UnityEngine;

public class GameEndCanvasController : MonoBehaviour
{
    [SerializeField] GameObject gameOverScreen = default;
    [SerializeField] GameObject gameWinScreen = default;
    [SerializeField] GamePlayEventHubSO gamePlayEvents = default;

 
    private bool iPlayerLost = false;
    void Start()
    {
        gamePlayEvents.OnPlayerDied += ShowGameOverScreen;
        gamePlayEvents.OnLevelFinished += ShowLevelFinishedScreen;

        gameOverScreen.SetActive(false);
        gameWinScreen.SetActive(false);
    }

    private void ShowGameOverScreen()
    {
        iPlayerLost = true;
        gameOverScreen.SetActive(true);
        Time.timeScale = 0;
    }

    private void ShowLevelFinishedScreen()
    {
        if (!iPlayerLost)
        {
            gameWinScreen.SetActive(true);
            Time.timeScale = 0;

        }
        
    }
}
