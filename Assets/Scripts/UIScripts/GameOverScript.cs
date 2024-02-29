using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameOverScript : MonoBehaviour
{
    public static bool canPause;
    
    public GameObject gameOverPanel;

    public TextMeshProUGUI gameStateText;
    public TextMeshProUGUI missionText;

    public string winText;
    public string loseText;
    public string missionSuccess;
    public string missionFail;
    
    void Start()
    {
        gameOverPanel.SetActive(false);
        canPause = true;
    }
    
    public void EndGame(bool WinGame)
    {
        gameOverPanel.SetActive(true);
        
        if (WinGame) 
        {
            AudioManager.Instance.musicSource.Stop();
            AudioManager.Instance.PlayMusic("Win Music");
            gameStateText.text = winText;
            missionText.text = missionSuccess;
        } else 
        {
            AudioManager.Instance.musicSource.Stop();
            AudioManager.Instance.PlayMusic("Loss Music");
            gameStateText.text = loseText;
            missionText.text = missionFail;
        }

        Cursor.lockState = CursorLockMode.None;
        canPause = false;
        Time.timeScale = 0f;
    }
}
