using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameOverScript : MonoBehaviour
{
    public static bool canPause = true;

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

    // Update is called once per frame
    void Update()
    {
        EndGame();
    }

    private void EndGame()
    {
        if (PLYR_Health.GameOver) 
        {
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.None;
            gameOverPanel.SetActive(true);
            gameStateText.text = loseText;
            missionText.text = missionFail;
            canPause = false;
        } else if (WLD_EndTrigger.WinGame)
        {
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.None;
            gameOverPanel.SetActive(true);
            gameStateText.text = winText;
            missionText.text = missionSuccess;
            canPause = false;
        }
    }
}
