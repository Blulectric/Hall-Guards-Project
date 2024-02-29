using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused = false;

    public GameObject pauseMenuUI;

    public Animator pauseTransition;

    public float animationTime = 1f;

    // Update is called once per frame
    void Update()
    {
        if (GameOverScript.canPause) {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (isPaused)
                {
                    Resume();
                } else 
                {
                    Pause();
                }
            }
        }
    }

    public void Resume()
    {
        // Coroutine for animation purposes ^w^ -Liz
        StartCoroutine(UnpauseGame());
    }

    void Pause()
    {
        AudioManager.Instance.PlaySFX("Open Menu");

        Cursor.lockState = CursorLockMode.None;
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    IEnumerator UnpauseGame()
    {
        AudioManager.Instance.PlaySFX("Close Menu");
        Cursor.lockState = CursorLockMode.Locked;
        // Trigger animation
        pauseTransition.SetTrigger("Unpaused");
        // Wait for animation to finish
        yield return new WaitForSecondsRealtime(animationTime);
        // Do stuff
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }
}
